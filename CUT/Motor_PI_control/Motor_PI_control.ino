const uint16_t frecuencia = 980;
const uint8_t canal = 0, resolucion = 12;

const uint8_t pwm_pin = 26;
const uint8_t retro = 36;

uint64_t now = 0, lastTime = 0, lastTime2 = 0;

float setPoint = 0.0;
float retroBits = 0.0;

uint32_t sampleTime = 1000;
float Ts = 0.001;

float kp = 0.0012852;
float ki = 0.0056137;

float u = 0.0, u1 = 0.0, un = 0.0;
float e = 0.0, e1 = 0.0;

float kn = 0.0, a = 0.0, b = 0.0, offset = 115.0;

bool flag = false;

void setup() {
  Serial.begin(9600);
  ledcSetup(canal, frecuencia, resolucion);
  ledcAttachPin(pwm_pin, canal);
  ledcWrite(canal, 0);

  a = kp + ki*Ts;
  b = -kp;
  kn = 5000.0/2047.5;
}

void loop() {
  now = micros();
  
  if (Serial.available() > 0) {
    String inputString = Serial.readStringUntil('\n'); // Leer la cadena enviada por el puerto serial
    inputString.trim(); // Eliminar cualquier espacio en blanco adicional
    if(inputString.indexOf("s") != -1){
      setPoint = (inputString.substring(1)).toInt();
      if(setPoint < -2047.5) setPoint = -2047.5;
      if(setPoint > 2047.5) setPoint = 2047.5;
    }
  }

  if (now - lastTime >= sampleTime) {
    retroBits = analogRead(retro) - 2047.5 + offset;
    e = (setPoint - retroBits)*kn;
    u = u1 + a*e + b*e1;
    u1 = u;
    e1 = e;
    lastTime = now;

    if (u > 5.0) u = 5.0;
    if (u < -5.0) u = -5.0;
    /*
    un = (393.5*(u + 5.0)) + 80.0;
    ledcWrite(canal, un);
    */
    flag = !flag;
    if(flag){
      un = (393.5*(u + 5.0)) + 80.0;
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