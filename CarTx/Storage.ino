void SaveCalibration()
{
  //min - center - max
  // Channels[0].MinVal
  EEPROM.write(0, Channels[0].MinVal >> 8);
  EEPROM.write(1, Channels[0].MinVal & 0xff);
  
  EEPROM.write(2, Channels[0].Center >> 8);
  EEPROM.write(3, Channels[0].Center & 0xff);
  
  EEPROM.write(4, Channels[0].MaxVal >> 8);
  EEPROM.write(5, Channels[0].MaxVal & 0xff);

  EEPROM.write(6, Channels[1].MinVal >> 8);
  EEPROM.write(7, Channels[1].MinVal & 0xff);
  
  EEPROM.write(8, Channels[1].Center >> 8);
  EEPROM.write(9, Channels[1].Center & 0xff);
  
  EEPROM.write(10, Channels[1].MaxVal >> 8);
  EEPROM.write(11, Channels[1].MaxVal & 0xff);
}

void LoadCalibration()
{
  if (EEPROM.read(0)==255) CalibrationDefaults();
  else {
    Channels[0].MinVal = (EEPROM.read(0) << 8) | EEPROM.read(1);
    Channels[0].Center = (EEPROM.read(2) << 8) | EEPROM.read(3);
    Channels[0].MaxVal = (EEPROM.read(4) << 8) | EEPROM.read(5);
    Channels[1].MinVal = (EEPROM.read(6) << 8) | EEPROM.read(7);
    Channels[1].Center = (EEPROM.read(8) << 8) | EEPROM.read(9);
    Channels[1].MaxVal = (EEPROM.read(10) << 8) | EEPROM.read(11);
  }
}

void CalibrationDefaults()
{
  Channels[0].MaxVal = 1023;
  Channels[0].MinVal = 0;
  Channels[1].MaxVal = 1023;
  Channels[1].MinVal = 0;
  Channels[0].Center = 512;
  Channels[1].Center = 512;
}

void SetModelDefaults()
{
  Channels[0].ExpLeft = 500;
  Channels[0].ExpRight = 500;
  Channels[0].Trimm = 128;
  Channels[0].Revers = 0;
  
  Channels[1].ExpLeft = 500;
  Channels[1].ExpRight = 500;
  Channels[1].Trimm = 128;
  Channels[1].Revers = 0;
  
  dFix = 0;
  
  for (byte i=0;i<4;i++) 
    rf_magic[i] = 1;
  ResetHopChannels();
  CurrentItemID = 255;
  UpdateScreen(0);
}

void SetSel(byte pos, boolean pMode)
{
  if (pos == 10) MyScreen.rect(1, 31, 71, 20);
  else
  if (pos == 11) MyScreen.rect(1, 51, 71, 20);
  else {
    if (pMode) MyScreen.line(1+(pos*12), 21, (pos*12)+14, 21);
    else MyScreen.rect(1+(pos*12), 1, 14, 20);
  }
}

void DrawSymbol(byte pos, char * aStr)
{
  char ss = aStr[pos];
  MyScreen.stroke(0, 0, 0);
  MyScreen.fill(0,0,0);
  MyScreen.drawChar(3+(pos*12), 3, ss, MyScreen.newColor(255,255,255), MyScreen.newColor(0,0,0), 2);
  MyScreen.noFill();
}

void DrawSelection(byte prevPos, byte currPos, boolean pOldMode, boolean pMode)
{
  // стереть старую рамку
  MyScreen.stroke(0, 0, 0);
  SetSel(prevPos, pOldMode);
  // нарисовать новую
  MyScreen.stroke(0, 255, 0);
  SetSel(currPos, pMode);
  MyScreen.stroke(255, 255, 255);
}

boolean InputString(char * aStr)
{
  boolean res = true;
  char vStr[10];
  for (uint8_t i=0;i<10;i++)
    vStr[i] = aStr[i];
  // очистить экран
  MyScreen.background(0, 0, 0);
  // установить selection на первый символ
  uint8_t currSymbol = 0;
  // установить состояние на перемещение
  boolean editMode = false; 
  // вывести строку
  MyScreen.text(vStr, 3, 3);
  MyScreen.text("Ok", 3, 33);
  MyScreen.text("Cancel", 3, 53);
  DrawSelection(0, 0, editMode, editMode);
  boolean exit = false;
  while (!exit)
  {
    // читаем состояние кнопок
    buttonsRead();
    // цикл по кнопкам
    dLastState = dState;
    for (int i = 0; i < 6; ++i)
    {
      // если кнопку отпустили
      if (dChanged & 1 && dState & 1)
      {
        switch(i)
          {
            // если это кнопка -, то 
            case BUTTON_PREV: {
              // если режим редактирования, изменить символ на предыдущий, перерисовать символ
              if (editMode) {
                vStr[currSymbol]--;
                if (vStr[currSymbol]<32) vStr[currSymbol] = 90;
                DrawSymbol(currSymbol, vStr);
              }
              // иначе сдвинуть позицию влево, перерисовать рамку
              else {
                byte tmp = currSymbol;
                if (currSymbol==0) currSymbol = 11; else currSymbol--;
                DrawSelection(tmp, currSymbol, editMode, editMode);
              }
            }break;
            // если это кнопка +, то 
            case BUTTON_NEXT: {
              // если режим редактирования, изменить символ на следующий, перерисовать символ
              if (editMode) {
                vStr[currSymbol]++;
                if (vStr[currSymbol]>90) vStr[currSymbol] = 32;
                DrawSymbol(currSymbol, vStr);
              }
              // иначе сдвинуть позицию вправо, перерисовать рамку
              else {
                byte tmp = currSymbol;
                if (currSymbol==11) currSymbol = 0; else currSymbol++;
                DrawSelection(tmp, currSymbol, editMode, editMode);
              }
            }break;
            // если это кнопка меню, то
            case BUTTON_MENU: {
              // если позиция на ок, то сохранить результат и выйти
              if (currSymbol == 10) {
                for (uint8_t i=0;i<10;i++)
                  aStr[i] = vStr[i];
                exit = true;
              }
              // иначе если позиция на отмене, то просто выйти
              else if (currSymbol == 11) {exit = true; res = false;}
              // иначе изменить режим, перерисовать рамку и подчеркивание
              else {
                editMode = !editMode;
                DrawSelection(currSymbol, currSymbol, !editMode, editMode);
              }
            }break;
            // если это кнопка отмена, то выйти без сохранения
            case BUTTON_CANCEL: {res = false; exit = true;} break;
          }
      }
      dChanged >>= 1;
      dState >>= 1;
    }
    delay(5);
    // возврат к чтению состояния кнопок
  }
  return res;
}

void LoadModelInfo()
{
  SelectedModel = MenuItems[CurrentItemID].LineID;
  if (EEPROM.read(12) != SelectedModel)
    EEPROM.write(12, SelectedModel);
  uint16_t model_offset = (SelectedModel + 1) * 100;
  for(int i=0;i<12;i++)
  MenuItems[0].menuname[i] = MenuItems[CurrentItemID].menuname[i];
  cli();
  for (byte i=0; i<4; i++)
    rf_magic[i] = EEPROM.read(model_offset + 12 + i);
  dFix = EEPROM.read(model_offset + 16);
  
  Channels[0].ExpLeft = (EEPROM.read(model_offset + 17)<<8) | EEPROM.read(model_offset + 18);
  if (Channels[0].ExpLeft>500) Channels[0].ExpLeft = 500;
  Channels[0].ExpRight = (EEPROM.read(model_offset + 19)<<8) | EEPROM.read(model_offset + 20);
  if (Channels[0].ExpRight>500) Channels[0].ExpRight = 500;
  Channels[0].Trimm = EEPROM.read(model_offset + 21);
  if (Channels[0].Trimm == 255) Channels[0].Trimm = 128;
  Channels[0].Revers = EEPROM.read(model_offset + 22);
  if (Channels[0].Revers>1) Channels[0].Revers = 0;
  
  Channels[1].ExpLeft = (EEPROM.read(model_offset + 23)<<8) | EEPROM.read(model_offset + 24);
  if (Channels[1].ExpLeft>500) Channels[1].ExpLeft = 500;
  Channels[1].ExpRight = (EEPROM.read(model_offset + 25)<<8) | EEPROM.read(model_offset + 26);
  if (Channels[1].ExpRight>500) Channels[1].ExpRight = 500;
  Channels[1].Trimm = EEPROM.read(model_offset + 27);
  if (Channels[1].Trimm == 255) Channels[1].Trimm = 128;
  Channels[1].Revers = EEPROM.read(model_offset + 28);
  if (Channels[1].Revers>1) Channels[1].Revers = 0;
  
  MatchByte = EEPROM.read(model_offset + 29);
  ResetHopChannels();
  rfm_start();
  CurrentItemID = 255;
  UpdateScreen(0);
}

void SaveModelInfo()
{
  //char str[12];
  //MenuItems[CurrentItemID].menuname.toCharArray(str, 11);
  if (InputString(MenuItems[CurrentItemID].menuname)) {
    //MenuItems[CurrentItemID].menuname = String(str);
    for(int i=0;i<12;i++)
    MenuItems[0].menuname[i] = MenuItems[CurrentItemID].menuname[i];
    SelectedModel = MenuItems[CurrentItemID].LineID;
    uint16_t model_offset = (SelectedModel + 1) * 100;
    for (byte i=0;i<12;i++)
      EEPROM.write(model_offset + i, MenuItems[CurrentItemID].menuname[i]);
    for (byte i=0; i<4; i++)
      EEPROM.write(model_offset + 12 + i, rf_magic[i]);
    EEPROM.write(model_offset + 16, dFix);
    
    EEPROM.write(model_offset + 17, Channels[0].ExpLeft>>8);
    EEPROM.write(model_offset + 18, Channels[0].ExpLeft & 0xff);
    EEPROM.write(model_offset + 19, Channels[0].ExpRight>>8);
    EEPROM.write(model_offset + 20, Channels[0].ExpRight & 0xff);
    EEPROM.write(model_offset + 21, Channels[0].Trimm);
    EEPROM.write(model_offset + 22, Channels[0].Revers);
    
    EEPROM.write(model_offset + 23, Channels[1].ExpLeft>>8);
    EEPROM.write(model_offset + 24, Channels[1].ExpLeft & 0xff);
    EEPROM.write(model_offset + 25, Channels[1].ExpRight>>8);
    EEPROM.write(model_offset + 26, Channels[1].ExpRight & 0xff);
    EEPROM.write(model_offset + 27, Channels[1].Trimm);
    EEPROM.write(model_offset + 28, Channels[1].Revers);
    
    EEPROM.write(model_offset + 29, MatchByte);
    CurrentItemID = MenuItems[CurrentItemID].ParentID;
    UpdateScreen(0);
  }
  else {
    CurrentItemID = MenuItems[CurrentItemID].ParentID;
    UpdateScreen(CurrentSelection);
  }
}

void LoadModelList(byte pParentID)
{
  uint16_t model_offset = 0;
  uint8_t model_no = 0;
  //char str[12];
  for (byte i = MENU_ITEMS_COUNT-8; i<MENU_ITEMS_COUNT;i++)
  {
    model_no = i + 8 - MENU_ITEMS_COUNT;
    model_offset = (model_no + 1) * 100;
    for (byte j=0;j<12;j++)
    {
      MenuItems[i].menuname[j] = EEPROM.read(model_offset + j);
      if (MenuItems[i].menuname[j]>127 || MenuItems[i].menuname[j] < 32) MenuItems[i].menuname[j]='.';
    }
      
//    MenuItems[i].menuname = "...";//String(str);
    MenuItems[i].ParentID = pParentID;
    MenuItems[i].Children = 0;
    MenuItems[i].LineID = i + 8 - MENU_ITEMS_COUNT;
  }
}
