
#include <stdio.h>
#include "pico/stdlib.h"
#include "pico/multicore.h"
#include "hardware/pwm.h"
#include "hardware/irq.h"
#include "hardware/timer.h"
#include "hardware/uart.h"

const uint8_t perturbacion = 15;
const uint8_t calibracion = 14;
const uint8_t pulse = 13;
const uint8_t digital_out = 3;
const uint8_t pulse_out = 2;

uint64_t tiempo_capturado_pulsado = 0;
uint64_t tiempo_capturado_libre = 0;

uint64_t lastTime = 0;
uint64_t lastTimeSend = 0;

const uint16_t s_time = 100; 
const float T = 0.000100;

//entrada para el servomotor
float r_act = 0.0;

//servo
float x_prev1 = 0.0; 
float x_prev2 = 0.0; 
float y_prev1 = 0.0; 
float y_prev2 = 0.0;

float serv_out = 0.0; 

//bv
float y1_prev1 = 0.0; 
float y1_prev2 = 0.0;

float y = 0.0;
float new_y = 0.0;

float pwm_value = 0.0;

float per = 0.0;
float s = 1.0;

bool pulse_state = false;
bool pulse_perturbacion = false;
bool pulse_calibracion = false;

bool aux_pulse = false;
bool aux_digital = false;
bool aux_per = false; 

uint64_t get_time_us(){
    return timer_hw->timerawl;
}

void setup(uint8_t pin, uint8_t slice, uint8_t channel){
    gpio_init(pin);
    gpio_set_function(pin, GPIO_FUNC_PWM);
    pwm_set_clkdiv(slice, 3.052); //31.15 to 980 Hz, 3.052 to 10kHz
    pwm_set_wrap(slice, 4095);
	pwm_set_chan_level(slice, channel, 0);
	pwm_set_enabled(slice, true);
}

void core1_interrupt_handler(){
    int16_t aux_sm = multicore_fifo_pop_blocking();
    uint16_t aux_bv = multicore_fifo_pop_blocking();
    
    printf("G(s):%i;SP:%i\n", aux_bv, aux_sm);
}

void core1_entry(){
    multicore_fifo_clear_irq();
    irq_set_exclusive_handler(SIO_IRQ_PROC1, core1_interrupt_handler);
    irq_set_enabled(SIO_IRQ_PROC1,true);
    while (1){
        tight_loop_contents();
    }
}

int main() {
    stdio_init_all();
    multicore_launch_core1(core1_entry);

    uint8_t slice =  pwm_gpio_to_slice_num(pulse_out);
    uint8_t channel = pwm_gpio_to_channel(pulse_out);
    setup(pulse_out, slice, channel);

    gpio_init(digital_out);
    gpio_set_dir(digital_out, GPIO_OUT);

    gpio_init(pulse);
    gpio_set_dir(pulse, GPIO_IN);
    gpio_pull_up(pulse);

    gpio_init(perturbacion);
    gpio_set_dir(perturbacion, GPIO_IN);
    gpio_pull_up(perturbacion);

    gpio_init(calibracion);
    gpio_set_dir(calibracion, GPIO_IN);
    gpio_pull_up(calibracion);

    const float kn_bv = 8970.0/7.0; // kn = (46.0/490.0)*(2047.5/0.15);

    float a =  210.90461*(T*T);
    float b = 25.65696*T - 2.0;
    float c = 1.0 - 25.65696*T + 210.90461*(T*T);
    
    float e = 2.14036*(T*T)*kn_bv;

    while (true) {
        uint64_t now = get_time_us();

        pulse_state = gpio_get(pulse);
        pulse_perturbacion = gpio_get(perturbacion);
        pulse_calibracion = gpio_get(calibracion);
            
        if (pulse_state && !aux_pulse) {
            tiempo_capturado_pulsado = now;
            aux_pulse = true;
        }
        if (!pulse_state && aux_pulse) {
            tiempo_capturado_libre = now;
            r_act = tiempo_capturado_libre - tiempo_capturado_pulsado - 510.0;
            aux_pulse = false;
        }

        if (now - lastTime >= s_time) {
            gpio_put(digital_out, aux_digital);
            aux_digital = !aux_digital;
            
            serv_out = a*x_prev2 - b*y_prev1 - c*y_prev2;
            y = 2.0*y1_prev1 - y1_prev2 + e*y_prev2;

            if (pulse_perturbacion && !aux_per){
                y = 2047.5*s;
                s *= -1.0;
                aux_per = true; 
            }
            if (!pulse_perturbacion && aux_per) aux_per = false;

            if(!pulse_calibracion) y = 0.0;

            if(y < -2047.5) y = -2047.5;
            if(y > 2047.5) y = 2047.5;

            if (new_y != y){
                new_y = y;
                pwm_value = y + 2047.5;
                pwm_set_chan_level(slice, channel, pwm_value);
            }
            
            //servo
            x_prev2 = x_prev1;
            x_prev1 = r_act;
            y_prev2 = y_prev1;
            y_prev1 = serv_out;

            //bv
            y1_prev2 = y1_prev1;
            y1_prev1 = y;

            lastTime = now;
        }
        if (now - lastTimeSend >= 17000) {
            int16_t aux_sm = (int16_t)(serv_out * 10.0f);
            uint16_t aux_bv = (uint16_t)pwm_value;
            
            multicore_fifo_push_blocking(aux_sm);
            multicore_fifo_push_blocking(aux_bv);
            
            lastTimeSend = now;
        }
    }
    return 0;
}
