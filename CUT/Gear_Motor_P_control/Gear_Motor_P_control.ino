const uint16_t frecuencia = 980;
const uint8_t canal = 0, resolucion = 12;

const uint8_t pwm_pin = 26;
const uint8_t retro = 36;

uint64_t now = 0, lastTime = 0, lastTime2 = 0;

float setPoint = 0.0;
float retroBits = 0.0;

uint32_t sampleTime = 1000;

float kp = 16.6742;

float u = 0.0, un = 0.0;
float e = 0.0;

float kn = 0.0, offset = 10.0;

bool flag = false;

void setup() {
  Serial.begin(9600);
  ledcSetup(canal, frecuencia, resolucion);
  ledcAttachPin(pwm_pin, canal);
  ledcWrite(canal, 0);

  kn = 180.0/4095.0;
}

void loop() {
  now = micros();

  if (Serial.available() > 0) {
    String inputString = Serial.readStringUntil('\n'); // Leer la cadena enviada por el puerto serial
    inputString.trim(); // Eliminar cualquier espacio en blanco adicional
    if(inputString.indexOf("s") != -1){
      setPoint = (inputString.substring(1)).toInt();
      if (setPoint < 0) setPoint = 0;
      if (setPoint > 180) setPoint = 180;
    }
  }

  if (now - lastTime > sampleTime){
    retroBits = analogRead(retro)*kn + offset;
    e = setPoint - retroBits;
    u = kp*e;
    lastTime = now;

    if (u < -3000.0) u = -3000.0;
    if(u > 3000.0) u = 3000.0;
    /*
    un = (u + 3000.0)*(3935.0/6000.0) + 80.0;
    ledcWrite(canal, un);
    */
    flag = !flag;
    if(flag){
      un = (u + 3000.0)*(3935.0/6000.0) + 80.0;
      ledcWrite(canal, un);
    }
  }
  /*
  if(now - lastTime2 >= 500000){
    Serial.printf("C(s): %.2f, G(s): %.2f\n", u, retroBits);
    lastTime2 = now;
  }
  */
}
