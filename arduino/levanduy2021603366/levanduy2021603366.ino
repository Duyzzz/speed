long t = 0;
int pulse = 0;
bool enable = false;
int speed = 0;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  attachInterrupt(0, count, FALLING);
}
void count(){
  pulse++;
}
void caculate(){
  if(enable == true){
    if(millis() - t > 200){
      speed = pulse;
      pulse = 0;
      Serial.println(speed);
      t = millis();
    }
  }
}
void loop() {
  // put your main code here, to run repeatedly:
  while(Serial.available() > 0){
  char command = "";
    command = Serial.read();
    Serial.println(command);
    if(command == 'o') enable = true;
    if (command == 'n') enable = false;
  }
    
    //Serial.println(enable);
    caculate();
}
