void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);

}

// the loop routine runs over and over again forever:
void loop() {
  // read the input on analog pin 0:
  int sensorValue = analogRead(A0);
   int sensorValue1 = analogRead(A1);
 // print out the value you read:
  Serial.print(sensorValue);
  Serial.print(";");
  Serial.println(sensorValue1);
  delay(500);  
  
}





 
