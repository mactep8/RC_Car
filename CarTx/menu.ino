
void UpdateScreen(byte ss)
{
  CurrentSelection=ss;
  MyScreen.background(0, 0, 0);
  boolean f=true;
  for(uint8_t i=0;i<MENU_ITEMS_COUNT;i++)
    if (MenuItems[i].ParentID == CurrentItemID)
    {
      //char str[12] = "";
      //MenuItems[i].menuname.toCharArray(str, 11);
      MyScreen.text(MenuItems[i].menuname, 3, MenuItems[i].LineID*20+2);
      if (CurrentSelection == MenuItems[i].LineID) MyScreen.stroke(0, 255, 0);
      else MyScreen.stroke(0, 0, 0);
      MyScreen.rect(0, MenuItems[i].LineID*20, 127, 20);
      MyScreen.stroke(255, 255, 255);
      f=false;
    }
  if (f) CallMenuFunc();
  else UpdateCustomValues();
}

void UpdateCustomValues()
{
  MyScreen.stroke(255, 255, 0);
  switch(CurrentItemID)
  {
    case 255: DrawMainScreen();break;
    case MENU_BUTTONS: DrawDFix(); break;
    case MENU_CHANNELS: DrawChNum(); break;
    case MENU_EXPENSES: DrawExp(); break;
  }
  MyScreen.stroke(255, 255, 255);
}

void DrawDFix()
{
  for (int i =0;i<4;i++)
  {
    if (dFix>>i & 1) MyScreen.text("X", 100, i * 20+2);
    else MyScreen.text("O", 100, i * 20+2);
  }
}

void DrawChNum()
{
  char str[4] = "";
  String(ACurrChannel+1).toCharArray(str, 2);
  MyScreen.text(str, 100, 2);

  String(Channels[ACurrChannel].Trimm).toCharArray(str, 4);
  MyScreen.text(str, 70, 42);

  if (Channels[ACurrChannel].Revers) String("Y").toCharArray(str, 2);
  else String("N").toCharArray(str, 2);
  MyScreen.text(str, 100, 62);
}

void DrawExp()
{
  char str[4] = "";
  String(Channels[ACurrChannel].ExpLeft).toCharArray(str, 4);
  MyScreen.text(str, 65, 2);
  String(Channels[ACurrChannel].ExpRight).toCharArray(str, 4);
  MyScreen.text(str, 65, 22);
}

void CallMenuFunc()
{
  switch(CurrentItemID)
  {
    case MENU_NEW_MODEL: SetModelDefaults(); break;
    case MENU_BIND: BindMode(); break;
    case MENU_CALIBRATE: ADC_Calibration(); break;
    case MENU_NUMBER: ChangeChNumber(); break;
    case MENU_BTN_1: ButtonFixChange(CurrentItemID);break;
    case MENU_BTN_2: ButtonFixChange(CurrentItemID);break;
    case MENU_BTN_3: ButtonFixChange(CurrentItemID);break;
    case MENU_BTN_4: ButtonFixChange(CurrentItemID);break;
    case MENU_REVERSE: ChangeRevers(); break;
  }
}

void ChangeChNumber()
{
  ACurrChannel = !ACurrChannel;
  CurrentItemID = MENU_CHANNELS;
  UpdateScreen(0);
}

void ChangeRevers()
{
  Channels[ACurrChannel].Revers = !Channels[ACurrChannel].Revers;
  CurrentItemID = MENU_CHANNELS;
  UpdateScreen(0);
}

void ButtonFixChange(uint8_t ButtonID)
{
  uint8_t btnBit = ButtonID-12;
  uint8_t dState = (dFix>>btnBit) & 1;
  if (dState) cbi(dFix, btnBit); else sbi(dFix, btnBit);
  CurrentItemID = 6;
  UpdateScreen(btnBit);
}

void LoadMenu()
{
  String("   Main    ").toCharArray(MenuItems[MENU_MAIN].menuname,12);
  MenuItems[MENU_MAIN].ParentID = 255;
  MenuItems[MENU_MAIN].Children = 6;
  MenuItems[MENU_MAIN].LineID = 0;
  
  String("Settings   ").toCharArray(MenuItems[MENU_SETTINGS].menuname,12);
  MenuItems[MENU_SETTINGS].ParentID = MENU_MAIN;
  MenuItems[MENU_SETTINGS].Children = 2;
  MenuItems[MENU_SETTINGS].LineID = 0;
  
  String("Clr Model  ").toCharArray(MenuItems[MENU_NEW_MODEL].menuname,12);
  MenuItems[MENU_NEW_MODEL].ParentID = MENU_MAIN;
  MenuItems[MENU_NEW_MODEL].Children = 0;
  MenuItems[MENU_NEW_MODEL].LineID = 1;
  
  String("Load Model ").toCharArray(MenuItems[MENU_LOAD_MODEL].menuname,12);
  MenuItems[MENU_LOAD_MODEL].ParentID = MENU_MAIN;
  MenuItems[MENU_LOAD_MODEL].Children = 8;
  MenuItems[MENU_LOAD_MODEL].LineID = 2;
  
  String("Save Model ").toCharArray(MenuItems[MENU_SAVE_MODEL].menuname,12);
  MenuItems[MENU_SAVE_MODEL].ParentID = MENU_MAIN;
  MenuItems[MENU_SAVE_MODEL].Children = 8;
  MenuItems[MENU_SAVE_MODEL].LineID = 3;
  
  String("Channels   ").toCharArray(MenuItems[MENU_CHANNELS].menuname,12);
  MenuItems[MENU_CHANNELS].ParentID = MENU_MAIN;
  MenuItems[MENU_CHANNELS].Children = 4;
  MenuItems[MENU_CHANNELS].LineID = 4;
  
  String("Buttons    ").toCharArray(MenuItems[MENU_BUTTONS].menuname,12);
  MenuItems[MENU_BUTTONS].ParentID = MENU_MAIN;
  MenuItems[MENU_BUTTONS].Children = 4;
  MenuItems[MENU_BUTTONS].LineID = 5;
  
  String("Binding    ").toCharArray(MenuItems[MENU_BIND].menuname,12);
  MenuItems[MENU_BIND].ParentID = MENU_SETTINGS;
  MenuItems[MENU_BIND].Children = 0;
  MenuItems[MENU_BIND].LineID = 0;
  
  String("Calibrate  ").toCharArray(MenuItems[MENU_CALIBRATE].menuname,12);
  MenuItems[MENU_CALIBRATE].ParentID = MENU_SETTINGS;
  MenuItems[MENU_CALIBRATE].Children = 0;
  MenuItems[MENU_CALIBRATE].LineID = 1;
  
  String("Number     ").toCharArray(MenuItems[MENU_NUMBER].menuname,12);
  MenuItems[MENU_NUMBER].ParentID = MENU_CHANNELS;
  MenuItems[MENU_NUMBER].Children = 0;
  MenuItems[MENU_NUMBER].LineID = 0;
  
  String("Expenses   ").toCharArray(MenuItems[MENU_EXPENSES].menuname,12);
  MenuItems[MENU_EXPENSES].ParentID = MENU_CHANNELS;
  MenuItems[MENU_EXPENSES].Children = 2;
  MenuItems[MENU_EXPENSES].LineID = 1;
  
  String("Trim       ").toCharArray(MenuItems[MENU_TRIMMERS].menuname,12);
  MenuItems[MENU_TRIMMERS].ParentID = MENU_CHANNELS;
  MenuItems[MENU_TRIMMERS].Children = 0;
  MenuItems[MENU_TRIMMERS].LineID = 2;
  
  String("Btn 1      ").toCharArray(MenuItems[MENU_BTN_1].menuname,12);
  MenuItems[MENU_BTN_1].ParentID = MENU_BUTTONS;
  MenuItems[MENU_BTN_1].Children = 0;
  MenuItems[MENU_BTN_1].LineID = 0;
  
  String("Btn 2      ").toCharArray(MenuItems[MENU_BTN_2].menuname,12);
  MenuItems[MENU_BTN_2].ParentID = MENU_BUTTONS;
  MenuItems[MENU_BTN_2].Children = 0;
  MenuItems[MENU_BTN_2].LineID = 1;
  
  String("Btn 3      ").toCharArray(MenuItems[MENU_BTN_3].menuname,12);
  MenuItems[MENU_BTN_3].ParentID = MENU_BUTTONS;
  MenuItems[MENU_BTN_3].Children = 0;
  MenuItems[MENU_BTN_3].LineID = 2;
  
  String("Btn 4      ").toCharArray(MenuItems[MENU_BTN_4].menuname,12);
  MenuItems[MENU_BTN_4].ParentID = MENU_BUTTONS;
  MenuItems[MENU_BTN_4].Children = 0;
  MenuItems[MENU_BTN_4].LineID = 3;
  
  String("Left       ").toCharArray(MenuItems[MENU_EXP_LEFT].menuname,12);
  MenuItems[MENU_EXP_LEFT].ParentID = MENU_EXPENSES;
  MenuItems[MENU_EXP_LEFT].Children = 0;
  MenuItems[MENU_EXP_LEFT].LineID = 0;
  
  String("Right      ").toCharArray(MenuItems[MENU_EXP_RIGHT].menuname,12);
  MenuItems[MENU_EXP_RIGHT].ParentID = MENU_EXPENSES;
  MenuItems[MENU_EXP_RIGHT].Children = 0;
  MenuItems[MENU_EXP_RIGHT].LineID = 1;

  String("Reverse    ").toCharArray(MenuItems[MENU_REVERSE].menuname,12);
  MenuItems[MENU_REVERSE].ParentID = MENU_CHANNELS;
  MenuItems[MENU_REVERSE].Children = 0;
  MenuItems[MENU_REVERSE].LineID = 3;
  
  LoadModelList(MENU_LOAD_MODEL);
}

void ScreenInit()
{
  MyScreen.begin();
  MyScreen.background(0, 0, 0);
  MyScreen.stroke(255, 255, 255);
  MyScreen.setTextSize(2);
  MyScreen.setRotation(2);
}

void buttonsInit()
{
  SPI.begin();
  pinMode(BUTTONS_SPI, OUTPUT);
  digitalWrite(BUTTONS_SPI, HIGH);
}

void buttonsRead()
{

  digitalWrite(BUTTONS_SPI, LOW);
  digitalWrite(BUTTONS_SPI, HIGH);
  dState = SPI.transfer(0);
  dChanged = dState ^ dLastState;

}

void ButtonPress()
{
  dLastState = dState;
  for (int i = 0; i < 7; ++i)
    {
      if (dChanged & 1 && dState & 1) // если состояние кнопки изменилось на 1
      {
        switch(i)
        {
          case BUTTON_PREV: 
            if (CurrentItemID==MENU_EXP_LEFT) {
              if (Channels[ACurrChannel].ExpLeft>0) Channels[ACurrChannel].ExpLeft--;
              MyScreen.fill(0,0,0);
              MyScreen.rect(60, CurrentSelection*20, 50, 20);
              MyScreen.noFill();
              DrawExp();
            }
            else
            if (CurrentItemID==MENU_EXP_RIGHT) {
              if (Channels[ACurrChannel].ExpRight>0) Channels[ACurrChannel].ExpRight--;
              MyScreen.fill(0,0,0);
              MyScreen.rect(60, CurrentSelection*20, 50, 20);
              MyScreen.noFill();
              DrawExp();
            }
            else
            if (CurrentItemID==MENU_TRIMMERS) {
              if (Channels[ACurrChannel].Trimm>0) Channels[ACurrChannel].Trimm--;
              MyScreen.fill(0,0,0);
              MyScreen.rect(60, CurrentSelection*20, 50, 20);
              MyScreen.noFill();
              DrawChNum();
            }
            else
            if (CurrentSelection>0) {
            {
              CurrentSelection--;
              UpdateSelection();
            }
          }break;
    
          case BUTTON_NEXT: 
            if (CurrentItemID==MENU_EXP_LEFT) {
              if (Channels[ACurrChannel].ExpLeft<500) Channels[ACurrChannel].ExpLeft++;
              MyScreen.fill(0,0,0);
              MyScreen.rect(60, CurrentSelection*20, 50, 20);
              MyScreen.noFill();
              DrawExp();
            }
            else
            if (CurrentItemID==MENU_EXP_RIGHT) {
              if (Channels[ACurrChannel].ExpRight<500) Channels[ACurrChannel].ExpRight++;
              MyScreen.fill(0,0,0);
              MyScreen.rect(60, CurrentSelection*20, 50, 20);
              MyScreen.noFill();
              DrawExp();
            }
            else
            if (CurrentItemID==MENU_TRIMMERS) {
              if (Channels[ACurrChannel].Trimm<255) Channels[ACurrChannel].Trimm++;
              MyScreen.fill(0,0,0);
              MyScreen.rect(60, CurrentSelection*20, 50, 20);
              MyScreen.noFill();
              DrawChNum();
            }
            else
            if (CurrentSelection<MenuItems[CurrentItemID].Children-1) {
            {
              CurrentSelection++;
              UpdateSelection();
            }
          }break;
    
          case BUTTON_CANCEL: {
            if (CurrentItemID !=255) 
            {
              byte prev_id = CurrentItemID;
              CurrentItemID = MenuItems[CurrentItemID].ParentID;
              UpdateScreen(MenuItems[prev_id].LineID);
            }
          }break;
    
          case BUTTON_MENU: {
            if (CurrentItemID==MENU_EXP_LEFT || CurrentItemID==MENU_EXP_RIGHT || CurrentItemID==MENU_TRIMMERS) return;
            for(uint8_t i=0;i<MENU_ITEMS_COUNT;i++)
            if ((CurrentItemID == MenuItems[i].ParentID) && (MenuItems[i].LineID == CurrentSelection))
            {
              CurrentItemID = i;//MenuItems[i].ID;
              break;
            }
            if (CurrentItemID > (MENU_ITEMS_COUNT - 9))
            {
              if (MenuItems[CurrentItemID].ParentID == MENU_LOAD_MODEL) LoadModelInfo();
              if (MenuItems[CurrentItemID].ParentID == MENU_SAVE_MODEL) SaveModelInfo();
              return;
            }
            switch(CurrentItemID)
            {
              case MENU_EXP_LEFT:
              case MENU_EXP_RIGHT:
              case MENU_TRIMMERS: SetExpSelection(); break;
              case MENU_LOAD_MODEL:
              case MENU_SAVE_MODEL: {
                LoadModelList(CurrentItemID);
                if (SelectedModel<8) UpdateScreen(SelectedModel); else UpdateScreen(0);
              }break;
              default: UpdateScreen(0);
            }
            
          }break;
        }
        dChanged = 0;
      }
      dChanged >>= 1;
      dState >>= 1;
    }
    delay(5);
}

void UpdateSelection()
{
  for(uint8_t i=0;i<MENU_ITEMS_COUNT;i++)
    if (MenuItems[i].ParentID == CurrentItemID)
    {
      if (CurrentSelection == MenuItems[i].LineID) MyScreen.stroke(0, 255, 0);
      else MyScreen.stroke(0, 0, 0);
      MyScreen.rect(0, MenuItems[i].LineID*20, 127, 20);
    }
  MyScreen.stroke(255, 255, 255);
}

void SetExpSelection()
{
  MyScreen.stroke(0, 0, 0);
  MyScreen.rect(0, CurrentSelection*20, 127, 20);
  MyScreen.stroke(0, 255, 0);
  MyScreen.rect(60, CurrentSelection*20, 50, 20);
  MyScreen.stroke(255, 255, 255);
}

void DrawMainScreen()
{
  MyScreen.text("RSSI:", 3, 22);
  MyScreen.text("TSSI:", 3, 42);
  MyScreen.text("Temp:", 3, 62);
}
