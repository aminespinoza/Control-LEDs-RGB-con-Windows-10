#include <Wire.h>

#define redLightRight 13
#define greenLightRight 12
#define blueLightRight 11
#define redLightCenter 10
#define greenLightCenter 9
#define blueLightCenter 8
#define redLightLeft 7
#define greenLightLeft 6
#define blueLightLeft 5

String primeraCadena, segundaCadena, terceraCadena;
String dataReceived = "";
int redRight, redCenter, redLeft;
int greenRight, greenCenter, greenLeft;
int blueRight, blueCenter, blueLeft;
String data = "";

void setup()
{
  Wire.begin(0x40);
  Wire.onReceive(receiveEvent);
  pinMode(redLightRight, OUTPUT);
  pinMode(greenLightRight, OUTPUT);
  pinMode(blueLightRight, OUTPUT);
  pinMode(redLightCenter, OUTPUT);
  pinMode(greenLightCenter, OUTPUT);
  pinMode(blueLightCenter, OUTPUT);
  pinMode(redLightLeft, OUTPUT);
  pinMode(greenLightLeft, OUTPUT);
  pinMode(blueLightLeft, OUTPUT);
}

void loop()
{

}

void receiveEvent(int howMany)
{
  char pos = (char)Wire.read();

  data = "";
  while( Wire.available())
  {
    data += (char)Wire.read();
  }

  switch(pos)
  {
  case 'l':
    redLeft = (getStringPartByNr(data, ',', 0)).toInt();
    greenLeft = (getStringPartByNr(data, ',', 1)).toInt();
    blueLeft = (getStringPartByNr(data, ',', 2)).toInt();
    analogWrite(redLightLeft, redLeft);
    analogWrite(greenLightLeft, greenLeft);
    analogWrite(blueLightLeft, blueLeft);
    break;

  case 'c':
    redCenter = (getStringPartByNr(data, ',', 0)).toInt();
    greenCenter = (getStringPartByNr(data, ',', 1)).toInt();
    blueCenter = (getStringPartByNr(data, ',', 2)).toInt();
    analogWrite(redLightCenter, redCenter);
    analogWrite(greenLightCenter, greenCenter);
    analogWrite(blueLightCenter, blueCenter);
    break;

  case 'r':
    redRight = (getStringPartByNr(data, ',', 0)).toInt();
    greenRight = (getStringPartByNr(data, ',', 1)).toInt();
    blueRight = (getStringPartByNr(data, ',', 2)).toInt();
    analogWrite(redLightRight, redRight);
    analogWrite(greenLightRight, greenRight);
    analogWrite(blueLightRight, blueRight);
    break;
  }
}

String getStringPartByNr(String data, char separator, int index)
{
    int stringData = 0; 
    String dataPart = "";
    
    for(int i = 0; i<data.length(); i++) 
    {  
      if(data[i]==separator) 
      {
        stringData++;  
      }else if(stringData==index) 
      {
        dataPart.concat(data[i]); 
      }else if(stringData>index) 
      {
        return dataPart;
        break;
      }
    }
    return dataPart;
}
