clc; clear all; close all;

%% variables globales
Tc = 2.25;
Ts = 0.000050;
Tz = 0.001;
sp = -3000;

%% Constantes del controlador
kp = 0.0012852;
ki = 0.0056137;

a1 = kp + (ki*Tz);
b1 = -kp;

%% Constantes del modelo discreto
Kc = 1.0;
tau = 0.453576;

a = (Ts/tau) * Kc; 
b = (Ts/tau) - 1.0;

%% GRAFICACIÓN
figure;
hold on;
grid on;

sim('bloques_motor.slx', Tc);
plot(t, p1, 'b', 'LineWidth', 2);
plot(t, p2, 'r--', 'LineWidth', 2);

data1 = xlsread('data.csv');
t1 = data1(:, 1)-1.7;
CH1 = (data1(:, 2)-2.5)*(5000/2.5);

plot(t1, CH1, 'Color', [0, 0.8, 0.2], 'LineWidth', 2);

% Estilo de la gráfica izquierda
xlim([0 Tc]);
ylim([-5000 0]);

xlabel('Time [s]', 'FontSize', 15);
ylabel('Velocity [RPM]', 'FontSize', 15);
legend('Continuous', 'Discrete', 'Emulation', 'FontSize', 12);

hold off;

%% exportación en tiff
set(gcf,'PaperUnits','inches','PaperPosition',[0 0 4 3])
print(figure(1),'Motor','-dtiff','-r300');