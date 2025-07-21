clc; clear all; close all;

%% variables globales
Tc = 3.0;
Ts = 0.0001;
Tz = 0.002;
sp = 0.0;

% variables controlador
Kp = 3;

% variables del servomotor
a = 210.90461*(Ts*Ts);
b = 25.65696*Ts - 2.0;
c = 1.0 - 25.65696*Ts + 210.90461*(Ts*Ts);

% variables bola-viga;
e = 2.14036*Ts*Ts;

%% graficación
figure;
hold on;
grid on;

sim('bloques_P.slx', Tc);
plot(t, p1, 'b', 'LineWidth', 2);
plot(t, p2, 'r--', 'LineWidth', 2);

data1 = xlsread('data.csv');
t1 = data1(:, 1)-1.81;
CH1 = (data1(:, 2)-25.6)*0.15/25.6;

plot(t1, CH1, 'Color', [0, 0.8, 0.2], 'LineWidth', 2);  % Puedes ajustar el grosor a tu preferencia

xlim([0 Tc])
ylim([-0.15 0.15]);

xlabel('Time [s]', 'FontSize', 15);
ylabel('Ball Position [m]', 'FontSize', 15);
legend('Continuous', 'Discrete', 'Emulation', 'FontSize', 10);

hold off;

%% EXPORTACIÓN TIFF
set(gcf,'PaperUnits','inches','PaperPosition',[0 0 4 3])
print(figure(1),'experimento','-dtiff','-r300');  % experimento
print(get_param('bloques_P','Handle'), '-dpng', '-r300', 'diagrama');  % diagrama de bloques 
print(get_param('bloques_P/C(z)1', 'Handle'), '-dpng', '-r300', 'controlador');  % diagrama de bloques del controlador
