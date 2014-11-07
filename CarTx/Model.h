#ifndef MODEL
#define MODEL

#define LPF 0.2
#define aTrimConst 128
#define CHANNELS_COUNT 2
byte ACurrChannel = 0;

typedef struct {
  uint16_t ExpLeft;
  uint16_t ExpRight;
  uint8_t Trimm;
  uint8_t Revers;
  
  uint16_t Center;
  uint16_t MaxVal;
  uint16_t MinVal;
  uint16_t chValue;
} tChannel;

typedef struct {
  byte rssi;
  byte tssi;
  float temp_d;
//  byte temp_f;
  byte U;
} tThelemetry;
tThelemetry Thelemetry;

volatile uint16_t ADC_Values[3];
tChannel Channels[CHANNELS_COUNT];
uint8_t dChannels = 0;

#define MENU_MAIN 0
#define MENU_SETTINGS 1
#define MENU_NEW_MODEL 2
#define MENU_LOAD_MODEL 3
#define MENU_SAVE_MODEL 4
#define MENU_CHANNELS 5
#define MENU_BUTTONS 6
#define MENU_BIND 7
#define MENU_CALIBRATE 8
#define MENU_NUMBER 9
#define MENU_EXPENSES 10
#define MENU_TRIMMERS 11
#define MENU_BTN_1 12
#define MENU_BTN_2 13
#define MENU_BTN_3 14
#define MENU_BTN_4 15
#define MENU_EXP_LEFT 16
#define MENU_EXP_RIGHT 17
#define MENU_REVERSE 18

#define TFT_CS   9
#define TFT_DC   7
#define TFT_RST  6
#define TFT_BL   5

#define MENU_ITEMS_COUNT 27

TFT MyScreen = TFT(TFT_CS, TFT_DC, TFT_RST);

typedef struct {
  char menuname[12];
  byte ParentID;
  byte Children;
  byte LineID;
} tMenuItem;

tMenuItem MenuItems[MENU_ITEMS_COUNT];
uint8_t CurrentSelection = 0;
uint8_t CurrentItemID = 255;

#define BUTTONS_SPI 8

#define BUTTON_PREV 0
#define BUTTON_NEXT 1
#define BUTTON_CANCEL 2
#define BUTTON_MENU 3
#define BUTTON_BIND 4
#define BUTTON_CH4  5

#define ANALOG_CHANNEL_0 4
#define ANALOG_CHANNEL_1 5

uint8_t dLastState = 63;
uint8_t dState = 63;
uint8_t dChanged = 0;

uint8_t dFix = 0;

#ifndef cbi
#define cbi(sfr, bit) (_SFR_BYTE(sfr) &= ~_BV(bit))
#endif

#ifndef sbi
#define sbi(sfr, bit) (_SFR_BYTE(sfr) |= _BV(bit))
#endif

uint8_t SelectedModel = 255;
uint8_t MatchByte = 255;

#endif MODEL
