void UpdateDigiChannels()
{
  byte cur_ch = 0;
  dLastState = dState;
  for (int i = 0; i < 7; ++i)
  {
    if (dChanged & 1) // если состояние кнопки изменилось 
    {
      cur_ch = 7;
      switch(i)
      {
          case BUTTON_PREV: cur_ch = 0; break;
          case BUTTON_NEXT: cur_ch = 1; break;
          case BUTTON_CANCEL: cur_ch = 2; break;
          case BUTTON_CH4: cur_ch = 3; break;
          case BUTTON_BIND: cur_ch = 4; break;
      }
      if (dFix>>cur_ch & 1) {
        if (dState & 1 && (dChannels>>cur_ch) & 1) cbi(dChannels, cur_ch);
        else
        if (dState & 1 && !((dChannels>>cur_ch) & 1)) sbi(dChannels, cur_ch);
      }
      else { if (dState & 1) cbi(dChannels, cur_ch); else sbi(dChannels, cur_ch); }
      
    }
    dChanged >>= 1;
    dState >>= 1;
  }
}

void UpdateTxBuffer()
{
  tx_buf[0] = 0xbb;
  tx_buf[1] = Channels[0].chValue & 0xff;
  tx_buf[2] = Channels[0].chValue >> 8;
  tx_buf[3] = Channels[1].chValue & 0xff;
  tx_buf[4] = Channels[1].chValue >> 8;
  tx_buf[5] = dChannels;
  tx_buf[6] = MatchByte;
}

void TxChannelsRequest()
{
  tx_buf[0] = 0xdd;
  tx_buf[6] = MatchByte;
}

void BindMode()
{
  MyScreen.text("Binding...", 0, 0);
  // Save rf address to temp
  byte rf_tmp[4];
  for (byte i=0;i<4;i++) {
    rf_tmp[i] = rf_magic[i];
    rf_magic[i] = 254;
  }
  //  Generate Match Byte
  randomSeed(ADC_Values[2]);
  byte vByte = random();
  // Restart RFM
  rfm_start();
  rx_reset();
  rfmSetChannel(1);
  RF_Mode = Receive;
  boolean binded = false;
  boolean canceled = false;
  while(!binded && !canceled)
  {
    rfm22_need_reboot();
    if (RF_Mode == Received) {
      rfm22_readBuffer();
      if (tx_buf[0] == 0xfa){
        for (byte i=0;i<4;i++) rf_tmp[i] = tx_buf[i+1];
        tx_buf[0] = 0x5d;
        tx_buf[5] = vByte;
        MatchByte = vByte;
        delayMicroseconds(5);
        tx_packet_async(tx_buf, 21);
        while (RF_Mode != Transmitted) ;
        binded = true;
      }
    }
    
    buttonsRead();
    if ((dChanged>>BUTTON_CANCEL) & 1) 
      if (!((dState>>BUTTON_CANCEL) & 1))
        canceled=true;
    dLastState = dState;
    dState = 0;
  }
  CurrentItemID = 255;
  UpdateScreen(0);
  cli();
  for (byte i=0;i<4;i++) {
    rf_magic[i] = rf_tmp[i];
  }
  init_rfm(0);
  rx_reset();
  sei();
  ADC_Init();
}

void UpdateThelemetry()
{
  if (CurrentItemID==255)
  {
    char str[5] = "";
    MyScreen.fill(0,0,0);
    MyScreen.stroke(0, 0, 0);
    MyScreen.rect(75, 20, 127, 42);
    MyScreen.stroke(255, 255, 255);
    String(Thelemetry.rssi).toCharArray(str, 4);
    MyScreen.text(str, 80, 22);
    
    MyScreen.stroke(0, 0, 0);
    MyScreen.rect(75, 40, 127, 62);
    MyScreen.stroke(255, 255, 255);
    String(Thelemetry.tssi).toCharArray(str, 4);
    MyScreen.text(str, 80, 42);
    
/*    MyScreen.stroke(0, 0, 0);
    MyScreen.rect(75, 60, 127, 82);
    MyScreen.stroke(255, 255, 255);
    String(Thelemetry.temp_d).toCharArray(str, 5);
    MyScreen.text(str, 80, 62);*/
    
    MyScreen.noFill();
  }
}

void ResetHopChannels()
{
  for (byte j=0;j<8;j++)
  {
    hopchannel[j] = 0;
  }
}
