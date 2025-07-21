const uint16_t frecuencia = 980;
const uint8_t canal = 0, resolucion = 12;

const uint8_t pwm_pin = 26;
const uint8_t retro = 36;

uint64_t now = 0, lastTime = 0, lastTime2;

int16_t setPoint = 0;
float retroBits = 0.0;

uint32_t sampleTime = 2000;

float kp = 3.23162;

float u = 0.0, un = 0.0;
float e = 0.0, e1 = 0.0;

float kn = 0.0, a = 0.0, b = 0.0, offset = 120.0;
bool flag = false;

void setup() {
  Serial.begin(9600);
  ledcSetup(canal, frecuencia, resolucion);
  ledcAttachPin(pwm_pin, canal);
  ledcWrite(canal, 2047.5);

  kn = (0.15/2047.5)*(1967.5/46.0); // kn = 787.0/251160.0;
}

void loop() {
  now = micros();
  
  if (now - lastTime >= sampleTime){
    retroBits = analogRead(retro) - 2047.5 + offset;
    e = (setPoint - retroBits)*kn;
    u = kp*e;
    lastTime = now;

    un = u + 2047.5;
    ledcWrite(canal, un);
    /*
    flag = !flag;
    if(flag){
      un = u + 2047.5;
      ledcWrite(canal, un);
    }
    */
  }
  /*
  if(now - lastTime2 >= 500000){
    Serial.printf("C(s): %.2f, G(s): %.2f\n", u, retroBits);
    lastTime2 = now;
  }
  */
}
