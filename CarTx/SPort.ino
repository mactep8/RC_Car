void SendHeader()
{
  Serial.write(0x5e);
}

void SendDataByte(uint8_t data)
{
  if (data==0x5e)
  {
    Serial.write(0x5d);
    Serial.write(0x3e);
  }
  else if (data==0x5e)
  {
    Serial.write(0x5d);
    Serial.write(0x3d);
  }
  else Serial.write(data);
}

void SendTwoDataByte(uint16_t data)
{
  SendDataByte(data >> 8);
  SendDataByte(data & 0xff);
}

uint8_t ReseiveDataByte()
{
  uint8_t data = Serial.read();
  if (data==0x5d) data = Serial.read() ^ 0x60;
  return data;
}

byte cmd = 0;
byte cmd_pos = 0;
byte cmd_buff[20];

void SPortRead()
{
  while(Serial.available())
  {
    byte data = Serial.read();
    if (data == 0x5e)
    {
      cmd = 0;
      cmd_pos = 0;
    }
    else if (cmd_pos == 0)
    {
      cmd = data;
      cmd_pos++;
    }
    else
    {
      cmd_buff[cmd_pos - 1] = data;
      cmd_pos++;
    }
    
    if (cmd>0)
    {
      if (cmd == 0x02) // запрос калибровочных значений
      {
        SendCalibration();
        cmd = 0;
        cmd_pos = 0;
      }
    }
  }
}

void SerialSendChannelsValues()
{
  SendHeader();
  SendDataByte(0x01);
  for(uint8_t i=0;i<2;i++)
    SendTwoDataByte(Channels[i].chValue);
  SendHeader();
}

void SendCalibration()
{
  SendHeader();
  SendDataByte(0x02);
  for(uint8_t i=0;i<2;i++)
  {
    SendTwoDataByte(Channels[i].MinVal);
    SendTwoDataByte(Channels[i].Center);
    SendTwoDataByte(Channels[i].MaxVal);
  }
  SendHeader();
}
