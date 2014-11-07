#ifdef SENSORS
#include <OneWire.h>
#include <DallasTemperature.h>

// Data wire is plugged into port 2 on the Arduino
#define ONE_WIRE_BUS A4

// Setup a oneWire instance to communicate with any OneWire devices (not just Maxim/Dallas temperature ICs)
OneWire oneWire(ONE_WIRE_BUS);

// Pass our oneWire reference to Dallas Temperature. 
DallasTemperature TempC(&oneWire);
uint32_t TempTime = 0;

void TempC_Init()
{
  TempC.begin();
  TempC.setResolution(12);
  TempC.setWaitForConversion(false);  // makes it async
  TempC.requestTemperatures();
  TempTime = millis();
}

int GetTempValue()
{
  int val = round(TempC.getTempCByIndex(0) * 10); 
  if (TempC.isConversionAvailable(0))
  {
    TempC.requestTemperatures();
  }
  return val;
}
#endif SENSORS

