#include <TFT.h>  // Arduino LCD library
#include <SPI.h>
#include <EEPROM.h>
#include "config.h"
#include "Model.h"

uint32_t lastSent = 0;

void setup()
{
  Serial.begin(115200);
  
  for(byte i = 0;i<8;i++) hopchannel[i] = 0;

  setupSPI();
  LoadCalibration();
  ScreenInit();
  ADC_Init();
  buttonsInit();
  LoadMenu();
  SetModelDefaults();
  rfm_start();
  
  Thelemetry.tssi = 0;
  
  byte SelectedModel = EEPROM.read(12);
  if (SelectedModel<8)
  {
    CurrentItemID = SelectedModel + MENU_ITEMS_COUNT - 8;
    LoadModelInfo();
  }
  else UpdateScreen(0);
}

void loop()
{
  if (Serial.available()) SPortRead();
  aChannelsGet();
  boolean SendFS = false;
  buttonsRead();
  if (dChanged) {
    if (((dChanged>>BUTTON_BIND) & 1) && ((dState>>BUTTON_BIND) & 1)) {
      CurrentItemID = MENU_BIND;
      BindMode();
      
      UpdateDigiChannels();
      dChanged = 0;
      SendFS = true;
    }
    else 
    if ((CurrentItemID>=0 && CurrentItemID<MENU_ITEMS_COUNT) ||
    (((dChanged>>BUTTON_MENU) & 1) && ((dState>>BUTTON_MENU) & 1))) ButtonPress();
    else {
      UpdateDigiChannels();
    }
  }

  rfm22_need_reboot(); //reboot rfm if needed
  if (RF_Mode == Received) {
    RF_Mode = Receive;
    rfm22_readBuffer();
    if (tx_buf[0] == 0x11) {
      Thelemetry.rssi = tx_buf[2];
/*      int val = 0;
      for (byte j = 4;j>0;j--)
      {
        val = val <<8;
        val = val | tx_buf[j+2];
      }
      Thelemetry.temp_d = val / 10.0;*/
//      Thelemetry.temp_f = abs(val) - (abs(Thelemetry.temp_d) * 10);
      if (Thelemetry.tssi == 0) Thelemetry.tssi = rfmGetRSSI();
      else Thelemetry.tssi = Thelemetry.tssi*(1-LPF) + LPF * rfmGetRSSI();// <<2;
      UpdateThelemetry();
    }
    
    if (tx_buf[0] == 0xda) {
      for(byte j=0;j<8;j++) {
        hopchannel[j] = tx_buf[j+1];
      }
      RF_channel = 0;
    }
  }

  uint32_t time = micros();

 if ((time - lastSent) >= getInterval()) {
    lastSent = time;
    
    if (hopchannel[RF_channel]<2)
      TxChannelsRequest();
    else
    {  
      cli();
      UpdateTxBuffer();
      if (SendFS) tx_buf[0] = 0xff;
      sei();
    }
    
    RF_channel++;
    if (RF_channel>7) RF_channel = 0;
    if (hopchannel[RF_channel]>1)
      rfmSetChannel(hopchannel[RF_channel]);
    else
      rfmSetChannel(1);
    tx_packet_async(tx_buf, 7);
  }

  if (RF_Mode == Transmitted) {
    RF_Mode = Receive;
    rx_reset();
  }

}
