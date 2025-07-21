clc; clear all; close all;

%% variables globales
Tc = 1;
Ts = 0.0001;
Tz = 0.001;
sp = 100;

% constantes del controlador
Kp = 16.6742;

% constantes del modelo
a = 12.650058*Ts*Ts;
b = 20.8968*Ts - 2;
c = 1 - 20.8968*Ts;

%% GRAFICACIÓN
figure;
hold on;
grid on;

sim('bloques', Tc);
plot(t, r1, 'b', 'LineWidth', 2);
plot(t, r2, 'r--', 'LineWidth', 2);

data1 = xlsread('data.csv');
t1 = data1(:, 1)-0.390;
CH1 = (data1(:, 2)/3.3)*217;

plot(t1, CH1, 'Color', [0, 0.8, 0.2], 'LineWidth', 1.5);

ylim([0 180]);
xlim([0 Tc]);

xlabel('Time [s]', 'FontSize', 15);
ylabel('Rotor Position [°]', 'FontSize', 15);
legend('Continuous', 'Discrete', 'Emulation', 'FontSize', 12);

hold off;

%% exportación en tiff
set(gcf,'PaperUnits','inches','PaperPosition',[0 0 4 3])

print(figure(1),'experimento','-dtiff','-r300');  % experimento
print(get_param('bloques','Handle'), '-dpng', '-r300', 'diagrama');  % diagrama de bloques
print(get_param('bloques/C(z)1', 'Handle'), '-dpng', '-r300', 'controlador');  % diagrama del controlador
