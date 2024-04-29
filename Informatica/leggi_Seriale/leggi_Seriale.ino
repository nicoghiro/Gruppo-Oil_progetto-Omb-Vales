int sensorValue1;
int diff;
bool pressed;
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
  sensorValue1=1;
  diff=1;
  pressed=false;
}

// the loop routine runs over and over again forever:
void loop() {
  // read the input on analog pin 0:
  int button = digitalRead(7);

  if(button==1){
    pressed=true;
  }
  if(pressed){
 // print out the value you read:
  int sensorValue = analogRead(A0);
  Serial.print(sensorValue1);
  Serial.print(";");
  Serial.println(sensorValue);
  sensorValue1+=diff;
  if(sensorValue1>90){
    diff=-1;
  } 
  if(sensorValue1<= 0){
    diff=1;
    pressed=false;
  }
  delay(100);  
  } 
}





 
