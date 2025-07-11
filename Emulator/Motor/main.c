
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
const uint8_t digital_out = 27;
const uint8_t pulse_out = 2;

uint64_t tiempo_capturado_pulsado = 0;
uint64_t tiempo_capturado_libre = 0;

uint64_t lastTime = 0;
uint64_t lastTimeSend = 0;

const uint16_t s_time = 46; 
const float T = 0.000046; // 100us in seconds

float c_act_per = 0.0;
float c_act = 0.0;
float c_ant = 0.0;
float m_act = 0.0;
float m_ant = 0.0;

const float Kc = 1.0;
const float tau = 0.453576;

float per = 0.0;

bool pulse_state = false;
bool pulse_perturbacion = false;
bool pulse_calibracion = false;

bool aux_pulse = false;
bool aux_digital = false;

float deadzoneInput = 0.0;
float pwm_value = 0.0;

uint64_t get_time_us(){
    return timer_hw->timerawl;
}

void setup(uint8_t pin, uint8_t slice, uint8_t channel){
    gpio_init(pin);
    gpio_set_function(pin, GPIO_FUNC_PWM);
    pwm_set_clkdiv(slice, 3.052);
    pwm_set_wrap(slice, 4095);
	pwm_set_chan_level(slice, channel, 0);
	pwm_set_enabled(slice, true);
}

void core1_interrupt_handler(){
    uint16_t aux_c = multicore_fifo_pop_blocking();
    uint16_t aux_m = multicore_fifo_pop_blocking();
    float aux_c2 = (float)((aux_c - 510.0)*(2047.5/490.0));
    float aux_m2 = (float)(aux_m - 2047.5);
    printf("G(s):%i;SP:%i\n", (int16_t)aux_m2, (int16_t)aux_c2);
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

    const float kn = (2047.5/490.0);
    const float a = (T / tau) * Kc * kn; 
    const float b = (T / tau) - 1.0;

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
            c_act = tiempo_capturado_libre - tiempo_capturado_pulsado - 510.0;

            if(c_act <= -49.0) deadzoneInput = 1.111111111*c_act + 54.44444444;
            else if(c_act >= 49.0) deadzoneInput = 1.111111111*c_act - 54.44444444;
            else deadzoneInput = 0.0;

            aux_pulse = false;
        }

        if (now - lastTime >= s_time) {
            gpio_put(digital_out, aux_digital);
            aux_digital = !aux_digital;

            m_act = a * c_ant - b * m_ant;

            if(!pulse_perturbacion && m_act > 0) per = -100.0;
            else if(!pulse_perturbacion && m_act < 0) per = 100.0;
            else per = 0.0;

            if(!pulse_calibracion) m_act = 0.0;

            pwm_value = m_act + 2047.5;
            pwm_set_chan_level(slice, channel, pwm_value);
            
            c_ant = deadzoneInput + per;
            m_ant = m_act;

            lastTime = now;
        }
        if (now - lastTimeSend >= 17000){
            uint16_t aux_c = (uint16_t)(c_act + 510.0);
            uint16_t aux_m = (uint16_t)(pwm_value);
            
            multicore_fifo_push_blocking(aux_c);
            multicore_fifo_push_blocking(aux_m);
            
            lastTimeSend = now;
        }
    }
    return 0;
}