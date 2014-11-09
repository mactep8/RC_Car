#include <EEPROM.h>

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

/*uint8_t ReseiveDataByte()
{
  uint8_t data = Serial.read();
  if (data==0x5d) data = Serial.read() ^ 0x60;
  return data;
}*/

byte cmd = 0;
byte cmd_pos = 0;
byte cmd_buff[100];
boolean do_xor = false;

void SPortRead()
{
  while(Serial.available())
  {
    byte data = Serial.read();
    if (data == 0x5e)
    {
      if (cmd>0)
      switch (cmd)
      {
        case 0x02: SendCalibration(); break;
        case 0x03: SendModelFromEEPROM(cmd_buff[0]); break;
        case 0x04: SendModelList(); break;
        case 0x05: UpdateCalibration(); break;
        case 0x06: UpdateModel(); break;
        default: cmd_pos = 0;
      }
      cmd = 0;
      cmd_pos = 0;
      do_xor = false;
    }
    else if (cmd_pos == 0)
    {
      cmd = data;
      cmd_pos++;
    }
    else
    {
      if (data == 0x5d) do_xor = true;
      else
      {
        if (do_xor) cmd_buff[cmd_pos - 1] = data^0x60;
        else cmd_buff[cmd_pos - 1] = data;
        do_xor = false;
        cmd_pos++;
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

void SendModelFromEEPROM(byte model_no)
{
  SendHeader();
  SendDataByte(0x03);
  uint16_t model_offset = (model_no + 1) * 100;
  for (int i=0;i<30;i++)
    SendDataByte(EEPROM.read(model_offset + i));
  SendHeader();
}

void SendModelList()
{
  SendHeader();
  SendDataByte(0x04);
  uint16_t model_offset = 0;
  uint8_t model_no = 0;
  for (byte i = 0; i<8;i++)
  {
    model_offset = (i + 1) * 100;
    for (byte j=0;j<12;j++)
    {
      SendDataByte(EEPROM.read(model_offset + j));
//      delay(5);
    }
  }
  SendHeader();
}

void UpdateCalibration()
{
  for (byte i=0;i<12;i++)
    EEPROM.write(i, cmd_buff[i]);
    
  LoadCalibration();
}

void UpdateModel()
{
  uint16_t model_offset = (cmd_buff[0] + 1) * 100;
  for (byte i=1;i<31;i++)
    EEPROM.write(model_offset+i-1, cmd_buff[i]);
  //DrawTextI(10, 100, cmd_buff[20]);  
    
  LoadModelList(MENU_LOAD_MODEL);
  
  if (EEPROM.read(12) == cmd_buff[0])
  {
    CurrentItemID = SelectedModel + MENU_ITEMS_COUNT - 8;
    LoadModelInfo();
  }
}
