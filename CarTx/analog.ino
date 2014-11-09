uint8_t ADC_REF = DEFAULT;
volatile uint8_t cur_in;
volatile bool ADC_update = false;

void ADC_Init()
{
  sbi(ADCSRA,ADPS2);
  cbi(ADCSRA,ADPS1);
  cbi(ADCSRA,ADPS0);

  ADC_Values[3] = analogRead(A6);
/*  cur_in = 4;
  ADMUX = (ADC_REF << 6) | (cur_in & 0x07);
 
  sbi(ADCSRA,ADATE);
  sbi(ADCSRA,ACIE);
  sbi(ADCSRA,ADSC);*/
}

/*ISR(ADC_vect)
{
  if (ADC_update){
    ADC_Values[cur_in-4] = ADCL|(ADCH << 8);
    if(cur_in>5)cur_in=4;
    else cur_in++;

    ADMUX = (ADC_REF << 6) | (cur_in & 0x07);
    ADC_update = false;
  }
  else
    ADC_update    = true;    
}*/

void ADC_Update(uint8_t indx, uint16_t ADC_Value)
{
  uint16_t tmpValue=0;
  // калибровка
  uint8_t aState=1;
  if (ADC_Value >Channels[indx].Center+4 ){
    tmpValue=map(ADC_Value, Channels[indx].Center, Channels[indx].MaxVal, 1500, 2000);
    aState = 2;
  }
  else
  if (ADC_Value <Channels[indx].Center-4 ) {
    tmpValue=map(ADC_Value, Channels[indx].MinVal, Channels[indx].Center, 1000, 1500);
    aState = 0;
  }
  else tmpValue = 1500;
  
  //реверс
  if (Channels[indx].Revers) { 
    tmpValue=map(tmpValue, 1000, 2000, 2000, 1000);
    
    if (aState == 2) aState = 0;
    else
    if (aState == 0) aState = 2;
  }
  
  // расходы
  if (aState>1) tmpValue=map(tmpValue, 1500, 2000, 1500, 1500 + Channels[indx].ExpRight);
  if (aState<1) tmpValue=map(tmpValue, 1000, 1500, 1500 - Channels[indx].ExpLeft, 1500);

  // триммирование
  Channels[indx].chValue=tmpValue + Channels[indx].Trimm - aTrimConst;
}

void aChannelsGet()
{
  ADC_Values[0] = analogRead(A4);
  ADC_Values[1] = analogRead(A5);
  ADC_Update(0, ADC_Values[0]);
  ADC_Update(1, ADC_Values[1]);
  SerialSendChannelsValues();
}

void ADC_Calibration()
{
  boolean bb=true;
  MyScreen.text("Set center and",0,0);
  MyScreen.text("press menu button",0,20);
  //Set center and press menu button - step 1
  while (bb) {
    buttonsRead();
    dLastState = dState;
    if (((dChanged>>BUTTON_MENU) & 1) && ((dState>>BUTTON_MENU) & 1)) {
      Channels[0].Center = ADC_Values[0];
      Channels[1].Center = ADC_Values[1];
      bb = false;
    }
    else
    if (((dChanged>>BUTTON_CANCEL) & 1) && ((dState>>BUTTON_CANCEL) & 1)) return;
  }
  //update endpoints and press menu 
  MyScreen.background(0, 0, 0);
  MyScreen.text("Update endpoints and",0,0);
  MyScreen.text("press menu button",0,20);
  Channels[0].MaxVal = Channels[0].Center;
  Channels[0].MinVal = Channels[0].Center;
  Channels[1].MaxVal = Channels[1].Center;
  Channels[1].MinVal = Channels[1].Center;
  bb=true;
  while (bb) {
    if (Channels[0].MaxVal<ADC_Values[0]) Channels[0].MaxVal=ADC_Values[0];
    if (Channels[0].MinVal>ADC_Values[0]) Channels[0].MinVal=ADC_Values[0];
    
    if (Channels[1].MaxVal<ADC_Values[1]) Channels[1].MaxVal=ADC_Values[1];
    if (Channels[1].MinVal>ADC_Values[1]) Channels[1].MinVal=ADC_Values[1];
    
    buttonsRead();
    dLastState = dState;
    if (((dChanged>>BUTTON_MENU) & 1) && ((dState>>BUTTON_MENU) & 1)) bb = false;
    else
    if (((dChanged>>BUTTON_CANCEL) & 1) && ((dState>>BUTTON_CANCEL) & 1)) return;
  }
  // save
  SaveCalibration();
  // update screen
  CurrentItemID = MENU_SETTINGS;
  UpdateScreen(1);
}

