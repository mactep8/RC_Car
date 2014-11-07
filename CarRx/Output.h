#ifndef CH_OUTPUT
#define CH_OUTPUT

#include <Arduino.h>

#define Red_LED 13
#define Green_LED A3
#define Green_LED_ON  PORTC |= _BV(3);
#define Green_LED_OFF  PORTC &= ~_BV(3);    
#define Red_LED_ON  PORTB |= _BV(5);
#define Red_LED_OFF  PORTB &= ~_BV(5);

#define LPF 0.2

#define ACHANNELS_COUNT 3
#define DCHANNELS_COUNT 4
uint16_t aChannel[ACHANNELS_COUNT] = {1500, 1500, 2000};
uint8_t dChannels = 0;

#define SET_TIME(x) (aChannel[x]<<1)

#define  ACH0_on PORTD |= (1<<5) //D5
#define  ACH0_off PORTD &= 0xDF //D5

#define  ACH1_on PORTD |= (1<<6) //D6
#define  ACH1_off PORTD &= 0xBF //D6

#define  RSSI_on PORTD |= (1<<3) //D3
#define  RSSI_off PORTD &= 0xF7 //D3

#define  DCH1_on PORTD |= (1<<7) //D7
#define  DCH1_off PORTD &= 0x7F //D7

#define  DCH2_on PORTB |= 1 //D8
#define  DCH2_off PORTB &= 0xFE //D8

#define  DCH3_on PORTB |= (1<<1) //D9
#define  DCH3_off PORTB &= 0xFD //D9

#define  DCH4_on PORTB |= (1<<2) //D10
#define  DCH4_off PORTB &= 0xFB //D10


#endif



