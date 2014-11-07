#include "Output.h"

volatile uint8_t cnt = 0;
volatile uint8_t curr_chA=1;

void Timers_Init()
{

  TCCR1B   =   0;   //stop timer
  TCCR1A   =   0;
  TCNT1   =    0;   //setup
  TCCR1A   =   0;
  TCCR1B = 0<<CS12 | 1<<CS11 | 0<<CS10;
  TIMSK1 = (1<<OCIE1A) | (1<<OCIE1B);   // Разрешить прерывание по совпадению
  OCR1A = 0;
  OCR1B = 40000;

  /*cnt = 0;
  TCCR2B   =   0;   //stop timer
  TCCR2A   =   0;
  TCNT2   =    0;   //setup
  TCCR2A   =   0;
  TCCR2A = 1<<WGM21;
  TCCR2B = 1<<CS22 | 1<<CS21 | 1<<CS20;
  TIMSK2 = 1<<OCIE2A;
  OCR2A = 155;*/

  TCNT1 = 0;
  UpdateServos();
}

/*ISR(TIMER2_COMPA_vect) {
  cnt++;
  if (cnt>=2){
//    TCNT1=0;
    curr_chA = 0;
    OCR1A = TCNT1 + SET_TIME(curr_chA);
    ServoOn(curr_chA);
    cnt=0;
#ifdef DEBUG
//    Serial.println("output data");
#endif
    dChannelsUpdate();
  }
}*/

ISR (TIMER1_COMPB_vect)
{
//  TCNT1=0;
  curr_chA = 0;
  OCR1A = SET_TIME(curr_chA);
  ServoOn(curr_chA);
  dChannelsUpdate();
}

ISR (TIMER1_COMPA_vect)
{
  UpdateServos();
}

void UpdateServos()
{
  ServoOff(curr_chA);
  curr_chA++;
  if (curr_chA<ACHANNELS_COUNT) {
    OCR1A = TCNT1 + SET_TIME(curr_chA);
    ServoOn(curr_chA);
  }
}

void ServoOn(uint8_t ch)
{
  switch(ch)
  {
    case 0: ACH0_on; break;
    case 1: ACH1_on; break;
    case 2: RSSI_on; break;
    case 10: DCH1_on; break;
    case 11: DCH2_on; break;
    case 12: DCH3_on; break;
    case 13: DCH4_on; break;
  }
}

void ServoOff(uint8_t ch)
{
  switch(ch)
  {
    case 0: ACH0_off; break;
    case 1: ACH1_off; break;
    case 2: RSSI_off; break;
    case 10: DCH1_off; break;
    case 11: DCH2_off; break;
    case 12: DCH3_off; break;
    case 13: DCH4_off; break;
  }
}

void dChannelsUpdate()
{
  uint8_t digi = dChannels;
  for(uint8_t i=0; i<DCHANNELS_COUNT; i++)
  {
    if (digi & 1) ServoOn(i+10);
    else ServoOff(i+10);
    digi >>= 1;
  }
}

void SetChannelValues()
{
  aChannel[0] = ((tx_buf[2]<<8)|tx_buf[1]);
  aChannel[1] = ((tx_buf[4]<<8)|tx_buf[3]);
  dChannels = tx_buf[5];
  if (aChannel[2] == 0) aChannel[2] = rfmGetRSSI();
  else aChannel[2] = aChannel[2]*(1-LPF) + LPF * rfmGetRSSI();// <<2;
  #ifdef DEBUG
/*  Serial.print(aChannel[0]);Serial.print(" "); 
  Serial.print(aChannel[1]);Serial.print(" "); 
  Serial.print(aChannel[2]);Serial.println(" "); */
  #endif
}

void InitOutput()
{
  pinMode(3, OUTPUT); // RSSI
  pinMode(5, OUTPUT); // aChannel 1
  pinMode(6, OUTPUT); // aChannel 2
  pinMode(7, OUTPUT); // dChannel 1
  pinMode(8, OUTPUT); // dChannel 2
  pinMode(9, OUTPUT); // dChannel 3
  pinMode(10, OUTPUT); // dChannel 4
  
  pinMode(11, INPUT); // BUTTON
  digitalWrite(11, HIGH);
  
  pinMode(Green_LED, OUTPUT);
  pinMode(Red_LED, OUTPUT);
}

void SetFailsafe()
{
  FsEn = true;
//  Red_LED_ON
//  Red_LED_OFF
  if (IsPresetFS()) {
    Red_LED_ON; 
    LoadFS();
  }
}

void ResetFailsafe()
{
  FsEn = false;
  Red_LED_OFF;
}

uint32_t lastFSTime = 0;

void PresetFailsafe()
{
  
  uint32_t time = millis();
  if (time - lastFSTime > 10000) {
    Serial.println(" PresetFailsafe ");
    lastFSTime = time;
    if (IsPresetFS()) { ResetFS(); Green_LED_OFF }
    else { SaveFS(); Green_LED_ON }
  }
}
