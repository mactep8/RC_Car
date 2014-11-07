//#define DEBUG

#include "Output.h"
#include "config.h"

uint32_t lastSent = 0;
uint32_t lastRxTime = 0;
uint8_t  errCount = 0;
boolean FsEn = false;

byte Mode = HIGH;
byte MatchByte = 255;
byte sndThelemetry = 0;

void setup()
{
  aChannel[2] = 0;
  #ifdef DEBUG
  Serial.begin(9600);
  #endif
  setupSPI();
  InitOutput();
  Mode = GetButton();
  LoadRFMAddress();
  rfm_start();
  RF_Mode = Receive;
  if (!Mode) {
//    Green_LED_OFF
    DoBind(); 
//    Red_LED_ON
  }
//  else Green_LED_ON
  Timers_Init();
#ifdef SENSORS
  TempC_Init();
#endif
  #ifdef DEBUG
  Serial.println("Started");
  #endif
  ScanChannels();
  rfmSetChannel(1);
  sndThelemetry = 0;
  errCount = 101;
  SetFailsafe();
  if (IsPresetFS()) Green_LED_ON else Green_LED_OFF
}

boolean channel_change = false;
void loop()
{
  rfm22_need_reboot(); //reboot rfm if needed
//  Red_LED_ON
//  Red_LED_OFF
  // if data recieved on rfm
  
  uint32_t time = micros();

  if (RF_Mode == Received) {
    rfm22_readBuffer();
    #ifdef DEBUG
    //Serial.print("recive data = ");Serial.println(tx_buf[6]);
    #endif
    if (tx_buf[6] == MatchByte){
      // Update Channels Values
      if (tx_buf[0] == 0xbb) SetChannelValues(); 
      if (tx_buf[0] == 0xdd) {
        SendHopChannels(); //Serial.print(" get request ");
      }
      if (tx_buf[0] == 0xbb && tx_buf[5]>>4 & 1) PresetFailsafe(); 
      #ifdef DEBUG
      //Serial.println(dChannels);
      #endif
      errCount = 0;
      ResetFailsafe();
      sndThelemetry++;

      //Serial.print("rx time = ");Serial.println(time - lastRxTime);
      lastRxTime = time;
      channel_change = true;
    }
    RF_Mode = Receive;
    rx_reset();
  }
  
  if (sndThelemetry > 8) {//(time - lastSent) >= getInterval() && 
    lastSent = time;
    SendTelemetry();
    sndThelemetry = 0;
    channel_change = false;
  } 
  
  if (RF_Mode == Transmitted) {
    RF_Mode = Receive;
    rx_reset();
    channel_change = true;
  }
  
  if ((time - lastRxTime) > getInterval() * 4) {
    if (errCount>25) SetFailsafe(); else errCount++;
    lastRxTime = time;
    channel_change = true;
    if (RF_Mode == Transmit){
      RF_Mode = Receive;
      rx_reset();
    }
  }

  if (channel_change)
  {
    RF_channel++;
//    Serial.print("RF_channel 2 = ");Serial.println(RF_channel);
    if (RF_channel==8 && errCount>25) rfmSetChannel(1);
    else 
    {
      if (RF_channel>7) RF_channel=0;
      rfmSetChannel(hopchannel[RF_channel]);
    }
    channel_change = false;
  }
  
}
