figure('name', "Task01", 'numbertitle', 'off');
x1 = -1:0.01:1;
plot(x1,tan(x1.^2).*cot(2*x1));
grid on;

figure('name', "Task02.1", 'numbertitle', 'off');
x1 = 0:0.001:1.15;
area(x1,tan(x1.^2).*cot(2*x1));
grid on;
figure('name', "Task02.2", 'numbertitle', 'off');
comet(x1,tan(x1.^2).*cot(2*x1));
grid on;
figure('name', "Task02.3", 'numbertitle', 'off');
view(5,15);
comet3(x1,tan(x1.^2).*cot(2*x1),x1)
grid on;

figure('name', "Task03", 'numbertitle', 'off');
pie3([5 10 15 20 50],[0 0 0 1 0]);
grid on;
axis equal;

figure('name', "Task04", 'numbertitle', 'off');
f = @(x) exp(-x) .* (sin(x) + 0.1 * sin(100 * pi * x));
x1 = 0:0.01:2;
x2 = 0:1/99:2;
hold on;
plot(x1, f(x1), 'r', 'LineWidth', 2);
plot(x2, f(x2), 'b', 'LineWidth', 1);
hold off;

figure('name', "Task05", 'numbertitle', 'off');
x = 0:0.01:5;
f = @(x) log(2*x);
g = @(x) log(x).*cos(x);

subplot(3, 1, 1);
loglog(x, f(x), 'b', 'LineWidth', 2);
hold on;
loglog(x, g(x), 'r', 'LineWidth', 2);
xlabel('x');
ylabel('y');
title('Графики функций f(x) и g(x) на логарифмических осях');
legend('f(x) = ln(2x)', 'g(x) = ln(x) * cos(x)', 'Location', 'Northwest');
grid on;
hold off;

subplot(3, 1, 2);
semilogx(x, f(x), 'b', 'LineWidth', 2);
hold on;
semilogx(x, g(x), 'r', 'LineWidth', 2);
xlabel('x');
ylabel('y');
title('Графики функций f(x) и g(x) по оси x в логарифмическом масштабе');
legend('f(x) = ln(2x)', 'g(x) = ln(x) * cos(x)', 'Location', 'Northwest');
grid on;
hold off;

subplot(3, 1, 3);
semilogy(x, f(x), 'b', 'LineWidth', 2);
hold on;
semilogy(x, g(x), 'r', 'LineWidth', 2);
xlabel('x');
ylabel('y');
title('Графики функций f(x) и g(x) по оси y в логарифмическом масштабе');
legend('f(x) = ln(2x)', 'g(x) = ln(x) * cos(x)', 'Location', 'Northwest');
grid on;
hold off;

figure('name', "Task06", 'numbertitle', 'off');
t = -pi:0.1:pi;
x = @(t) cos(t);
y = @(t) cos(t);
bar(x(t), y(t), 10);

figure('name', "Task07", 'numbertitle', 'off');
f = @(x, y) 4 * sin(2 * pi * x) * cos(1.5 * pi * y) * (1 - y.^2) .* x .* (1 - x);

x = -3:0.05:3;
y = -3:0.05:3;

[X, Y] = meshgrid(x, y);

Z = f(X, Y);
surf(X, Y, Z, 'EdgeColor', 'none', 'FaceAlpha', 0.5);

xlabel('x');
ylabel('y');
zlabel('f(x, y)');
title('Каркасная поверхность f(x, y)');

view(30,5);

figure('name', "Task08", 'numbertitle', 'off');
f = @(x, y) exp(-1./x) .* sin(y);

x = -0.1:0.02:0.05;
y = -3:0.02:3;

[X, Y] = meshgrid(x, y);

Z = f(X, Y);

surf(X, Y, Z, 'EdgeColor', 'none', 'FaceLighting', 'gouraud', 'AmbientStrength', 0.3, 'DiffuseStrength', 0.8, 'SpecularStrength', 0.9);

xlabel('x');
ylabel('y');
zlabel('f(x, y)');

light('Position', [-1, -1, 1], 'Style', 'infinite');
lightangle(-80, 75);

view([-30, 30]);

figure('name', "Task09", 'numbertitle', 'off');
f = @(x, y) sin(x) * cos(y);

x = -3:0.1:3;
y = -3:0.1:3;

[X, Y] = meshgrid(x, y);

Z = f(X, Y);

contourLevels = -1:0.05:1;
contour3(X, Y, Z, contourLevels, 'LineWidth', 2);

xlabel('x');
ylabel('y');
zlabel('f(x, y)');
title('Поверхность из линий уровня функции f(x, y)');

zlim([-1, 1]);

view(10, 20);

colorbar;

figure('name', "Task10", 'numbertitle', 'off');
u = linspace(-2*pi, 2*pi, 100);
v = linspace(-pi, pi, 100);
[U, V] = meshgrid(u, v);

x = cos(U) .* cos(V) + 3 * cos(U) .* (1.5 + 0.5 * sin(1.5 * U));
y = sin(U) .* cos(V) + 3 * sin(U) .* (1.5 + 0.5 * sin(1.5 * U));
z = sin(V) + 2 * cos(1.5 * U);

subplot(2, 2, 1);
plot3(x, y, z, 'LineWidth', 1);
title('Каркасная поверхность');
view(30, 30);

subplot(2, 2, 2);
surf(x, y, z, 'EdgeColor', 'none');
title('Залитая цветом каркасная поверхность');
view(45, 15);

subplot(2, 2, 3);
contour(x, y, z, 'LineWidth', 1);
title('Линии уровня');
view(60, 45);

subplot(2, 2, 4);
surf(x, y, z, 'EdgeColor', 'none', 'FaceLighting', 'gouraud', 'AmbientStrength', 0.3, 'DiffuseStrength', 0.8, 'SpecularStrength', 0.9);
title('Освещенная поверхность');
view(-60, 60);

xlabel('X');
ylabel('Y');
zlabel('Z');

subplot(2, 2, 1);
ylabel('Y');
zlabel('Z');

subplot(2, 2, 2);
ylabel('Y');
zlabel('Z');

subplot(2, 2, 3);
xlabel('X');
ylabel('Y');

subplot(2, 2, 4);
xlabel('X');
ylabel('Y');











