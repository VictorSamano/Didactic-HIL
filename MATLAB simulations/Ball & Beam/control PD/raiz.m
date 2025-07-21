clc; clear all; close all;

%% variables globales
Tc = 6;
Ts = 0.0001;
Tz = 0.002;
sp = 0.0;

% constantes controlador
kp = 3.23162;
kd = 1.49135;
g1 = kp + (kd/Tz);
g2 = kd/Tz;
limit = 46;

% constantes servomotor
a = 210.90461*(Ts*Ts);
b = 25.65696*Ts - 2.0;
c = 1.0 - 25.65696*Ts + 210.90461*(Ts*Ts);

% constantes bola-viga;
e = 2.14036*(Ts*Ts);

%% GRAFICACIÓN
hold on;
grid on;

sim('bloques_PD.slx', Tc);
plot(t, p3, 'b', 'LineWidth', 2);
plot(t, p4, 'r--', 'LineWidth', 2);

data2 = xlsread('data.csv');
t2 = data2(:, 1);
CH2 = data2(:, 2);

plot(t2-1.85, ((CH2-1.7)/1.7) * 0.15, 'Color', [0, 0.8, 0.2], 'LineWidth', 2);

xlim([0 Tc]);
ylim([-0.15 0.15]);

xlabel('Time [s]', 'FontSize', 15);
ylabel('Ball Position [m]', 'FontSize', 15);
legend('Continuous', 'Discrete', 'Emulation', 'FontSize', 12);

hold off;

%% exportación en tiff
set(gcf,'PaperUnits','inches','PaperPosition',[0 0 4 3])
print(figure(1),'experimento','-dtiff','-r300');  % experimento
print(get_param('bloques_PD','Handle'), '-dpng', '-r300', 'diagrama');  % diagrama de bloques
print(get_param('bloques_PD/C(z)1', 'Handle'), '-dpng', '-r300', 'controlador');  % diagrama de bloques del controlador
