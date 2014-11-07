#include <EEPROM.h>

byte GetButton()
{
  return ((PINB & 0x08) == 0x08);
}

void LoadFS()
{
  if (IsPresetFS()){
    aChannel[0] = ((EEPROM.read(8)<<8)|EEPROM.read(7));
    aChannel[1] = ((EEPROM.read(10)<<8)|EEPROM.read(9));
    dChannels = EEPROM.read(11);
  }
}

void SaveFS()
{
  EEPROM.write(6, 1);
  EEPROM.write(7, aChannel[0] & 0xff);
  EEPROM.write(8, aChannel[0] >> 8);
  EEPROM.write(9, aChannel[1] & 0xff);
  EEPROM.write(10, aChannel[1] >> 8);
  EEPROM.write(11, dChannels);
}

void ResetFS()
{
  EEPROM.write(6, 0);
}

byte IsPresetFS()
{
  byte fs = EEPROM.read(6);
  if (fs!=1) fs = 0;
  return fs;
}

void LoadRFMAddress()
{
  if (Mode) {
    // read address from EEPROM
    for (byte i = 0; i< 4; i++)
      rf_magic[i] = EEPROM.read(i);
  }
  else {
    // BIND
    // Generate new address
    randomSeed(analogRead(7));
    for (byte i = 0; i< 4; i++)
    {
      bind_magic[i] = random();
      //EEPROM.write(i, rf_magic[i]);
    }
  }
  MatchByte = EEPROM.read(5);
#ifdef DEBUG
  Serial.print("Address=");
  Serial.print(rf_magic[0]);
  Serial.print(".");
  Serial.print(rf_magic[1]);
  Serial.print(".");
  Serial.print(rf_magic[2]);
  Serial.print(".");
  Serial.println(rf_magic[3]);
  Serial.print("MatchByte=");
  Serial.println(MatchByte);
#endif
}

void DoBind()
{
  #ifdef DEBUG
  Serial.println("binding");
  #endif
  uint16_t btime=0;
  // set bind address
  for (byte i = 0; i< 4; i++)
    rf_magic[i] = 254;
  // start rfm
  init_rfm(0);
  rx_reset();
  // generate tx buffer
  for (byte i = 0; i< 4; i++)
   tx_buf[i+1] = bind_magic[i];
  tx_buf[0] = 0xfa;
  // while mode is bind
  while (!Mode) {
    // to tx mode
    #ifdef DEBUG
    Serial.println("sending");
    #endif

    rfm22_need_reboot();
//    Red_LED_ON
//    Red_LED_OFF
  
    uint32_t time = micros();

    if ((time - lastSent) >= getInterval()) {
      lastSent = time;
      rfmSetChannel(1);
      tx_packet_async(tx_buf, 21);
    }
    
    // read button
    Mode = GetButton();
    // if recieve then set mode to normal & led_on
    if (RF_Mode == Received) {
      #ifdef DEBUG
      Serial.println("recieving");
      #endif
      rfm22_readBuffer();
      if (tx_buf[0] == 0x5d)
      {
        Mode = HIGH;
        for (byte i = 0; i< 4; i++){
          rf_magic[i] = bind_magic[i];
          EEPROM.write(i, rf_magic[i]);
          #ifdef DEBUG
          Serial.print(rf_magic[i]);
          Serial.print(".");
          #endif
        }
        MatchByte = tx_buf[5];
        EEPROM.write(5, MatchByte);
        #ifdef DEBUG
        Serial.println("");
        Serial.print("MatchByte="); Serial.println(MatchByte);
        #endif
        rfm_start();
      }
      RF_Mode = Receive;
    }
    
    if (RF_Mode == Transmitted) {
      RF_Mode = Receive;
      rx_reset();
    }

  }
  // return;
#ifdef DEBUG
  Serial.println("OUT");
#endif
}

void ScanChannels()
{
  int rssi = 0;
  byte ch[8];
  byte rs[8] = {255,255,255,255,255,255,255,255};
  for (int i=2;i<255;i++)
  {
    rfmSetChannel(i);
    rssi=0;
    for (byte j=2;j<10;j++)
      rssi += rfmGetRSSI();
    rssi = round(rssi / 10);
#ifdef DEBUG
  //Serial.print("Channel=");Serial.print(i);
//  Serial.print(" RSSI=");Serial.println(rssi);
#endif
    byte k=8;
    for (byte j=8;j>0;j--)
      if (rs[j-1]>rssi) k=j-1;
    if (k<8)
    {
      byte j=7;
      #ifdef DEBUG
      //Serial.print("k=");Serial.print(k);
      #endif
      while (j>k)
      {
        rs[j] = rs[j-1];
        ch[j] = ch[j-1];
        j--;
      }
      rs[k]=rssi;
      ch[k]=i;
    }
  }
#ifdef DEBUG
  Serial.println("Channels list:");
#endif
  for (byte j=0;j<8;j++)
  {
    #ifdef DEBUG
    Serial.print("Channel=");Serial.print(ch[j]);
    Serial.print(" RSSI=");Serial.println(rs[j]);
    #endif
    hopchannel[j] = ch[j];
  }
  rfmSetChannel(1);

}

void SendTelemetry()
{
  tx_buf[0] = 0x11;
  tx_buf[1] = 1;
  tx_buf[2] = aChannel[2] & 0xff;
#ifdef SENSORS
  int t = GetTempValue();
  for(byte j=0;j<4;j++)
  {
    tx_buf[j+3] = t & 0xff;
    t = t >> 8;
  }
#endif SENSORS
#ifdef DEBUG
  //Serial.print("send data = ");
#endif
  tx_packet_async(tx_buf, 6);
}

void SendHopChannels()
{
  uint32_t time = micros();

  while ((time - lastSent) >= getInterval()) 
    lastSent = time;
  
  tx_buf[0] = 0xda;
  
  for (byte j=0;j<8;j++)
    tx_buf[j+1] = hopchannel[j];
    
  tx_packet_async(tx_buf, 21);
  Serial.println(" send responce ");
  while (RF_Mode != Transmitted) ;
  RF_channel = 0;
}
