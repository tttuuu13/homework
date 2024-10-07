figure('name', "Task01", 'numbertitle', 'off');
t = -100:0.01:100;
x = exp(abs(t-1)/10) .* sin(t);
y = exp(abs(t-1)/10) .* cos(t);
z = t;
plot3(x, y, z);
xlabel('X');
ylabel('Y');
zlabel('Z');
grid on;

figure('name', "Task02", 'numbertitle', 'off');
[u, v] = meshgrid(-2*pi:0.1*pi:2*pi, -2*pi:0.1*pi:2*pi);
x = v .* sin(u);
y = v .* cos(u);
z = u;
surf(x, y, z);
xlabel('X');
ylabel('Y');
zlabel('Z');
grid on;

figure('name', "Task03", 'numbertitle', 'off');
t = 0:0.01*pi:12*pi;
x = sin(t) .* (exp(cos(t)) - 2*cos(4*t) + sin(5*t/12));
y = cos(t) .* (exp(cos(t)) - 2*cos(4*t) + sin(5*t/12));
plot(x, y);
xlabel('X');
ylabel('Y');
grid on;

figure('name', "Task04", 'numbertitle', 'off');
t = 0:0.2:10;
ux0 = 0.5;
uy0 = 0.6;
g = 10;
m = 100;

x = ux0 * t;
y = uy0 * t - (g * t.^2) / (2 * m);

vx = ux0 * ones(size(t));
vy = uy0 - (g * t) / m;

scale_factors = [1, 3, 5];

for i = 1:length(scale_factors)
    subplot(1, 3, i);
    quiver(x, y, vx * scale_factors(i), vy * scale_factors(i), 0);
    title(['Коэфф.: ' num2str(scale_factors(i))]);
    xlabel('X');
    ylabel('Y');
    axis equal;
    grid on;
end
hold on;

disp("Task05")
plot(x, y, 'k', 'LineWidth', 1.5);
xlabel('X');
ylabel('Y');
title('Траектория');
axis equal;
grid on;

figure('name', "Task06", 'numbertitle', 'off');
compass(vx, vy);
hold on;
title('Векторные поля');
axis equal;
grid on;

figure('name', "Task07", 'numbertitle', 'off');
feather(vx, vy);
hold on;
title('Векторные поля');
axis equal;
grid on;

figure('name', "Task08", 'numbertitle', 'off');
u = 0:0.01*pi:2*pi;
v = -1:0.01*pi:1;

[U, V] = meshgrid(u, v);

x = (1 + V/2 .* cos(U/2)) .* cos(U);
y = (1 + V/2 .* cos(U/2)) .* sin(U);
z = V/2 .* sin(U/2);

partial_u = [diff(x, 1, 2), zeros(size(x, 1), 1)] ./ (0.01*pi);
partial_v = [diff(x, 1, 1); zeros(1, size(x, 2))] ./ (0.01*pi);

n_x = -partial_u ./ sqrt(partial_u.^2 + partial_v.^2 + 1);
n_y = -partial_v ./ sqrt(partial_u.^2 + partial_v.^2 + 1);
n_z = 1 ./ sqrt(partial_u.^2 + partial_v.^2 + 1);

surf(x, y, z, 'FaceAlpha', 0.7);
hold on;

quiver3(x, y, z, n_x, n_y, n_z, 'r', 'LineWidth', 1.5);

xlabel('X');
ylabel('Y');
zlabel('Z');
axis equal;
grid on;


figure('name', "Task09", 'numbertitle', 'off');
a = 1;
b = 2;

[x, y] = meshgrid(-5:0.5:5, -5:0.5:5);

z = (x.^2/a^2) - (y.^2/b^2);

partial_x = 2*x/a^2;
partial_y = -2*y/b^2;
partial_z = ones(size(x));

lengths = sqrt(partial_x.^2 + partial_y.^2 + partial_z.^2);
unit_x = partial_x ./ lengths;
unit_y = partial_y ./ lengths;
unit_z = partial_z ./ lengths;

surf(x, y, z, 'FaceAlpha', 0.7);
hold on;

quiver3(x, y, z, unit_x, unit_y, unit_z, 'r', 'LineWidth', 1.5);

xlabel('X');
ylabel('Y');
zlabel('Z');
axis equal;
grid on;


figure('name', "Task10", 'numbertitle', 'off');
a = 1;
b = 1;
c = 2;

[x, y, z] = meshgrid(-5:0.5:5, -5:0.5:5, -5:0.5:5);

hyperboloid = x.^2/a^2 + y.^2/b^2 - z.^2/c^2 + 2;

isosurface(x, y, z, hyperboloid, 0);
hold on;

partial_x = 2*x/a^2;
partial_y = 2*y/b^2;
partial_z = -2*z/c^2;

lengths = sqrt(partial_x.^2 + partial_y.^2 + partial_z.^2);
unit_x = partial_x ./ lengths;
unit_y = partial_y ./ lengths;
unit_z = partial_z ./ lengths;

quiver3(x, y, z, unit_x, unit_y, unit_z, 'r', 'LineWidth', 1.5);

xlabel('X');
ylabel('Y');
zlabel('Z');
axis equal;
grid on;

figure('name', "Task11", 'numbertitle', 'off');
[u, v] = meshgrid(0:0.1:3, 0:0.1:3);

x = cos(u) .* cos(v);
y = sin(u) .* sin(v);
z = u .* v;

partial_u = -sin(u) .* cos(v);
partial_v = -cos(u) .* sin(v);
partial_w = v;

lengths = sqrt(partial_u.^2 + partial_v.^2 + partial_w.^2);
unit_u = partial_u ./ lengths;
unit_v = partial_v ./ lengths;
unit_w = partial_w ./ lengths;

surf(x, y, z, 'FaceAlpha', 0.7);
hold on;

quiver3(x, y, z, unit_u, unit_v, unit_w, 'r', 'LineWidth', 1.5);

xlabel('X');
ylabel('Y');
zlabel('Z');
axis equal;
grid on;

figure('name', "Task12", 'numbertitle', 'off');
[u, v] = meshgrid(0:0.1:4*pi, 0.001:0.1:2);

x = cos(u) .* sin(v);
y = sin(u) .* sin(v);
z = cos(v) + log(tan(v/2)) + 0.2*u - 4;

surf(x, y, z, 'FaceAlpha', 0.7);

xlabel('X');
ylabel('Y');
zlabel('Z');
title('Parametric Surface');
axis equal;
grid on;

figure('name', "Task13", 'numbertitle', 'off');
[u, v] = meshgrid(-pi:0.01*pi:pi, -pi:0.01*pi:pi);

x = cos(u) .* (cos(v) + 3);
y = sin(u) .* (cos(v) + 3);
z = sin(v);

partial_u = -sin(u) .* (cos(v) + 3);
partial_v = -cos(u) .* sin(v);
partial_w = cos(u) .* (cos(v) + 3);

lengths = sqrt(partial_u.^2 + partial_v.^2 + partial_w.^2);
unit_u = partial_u ./ lengths;
unit_v = partial_v ./ lengths;
unit_w = partial_w ./ lengths;

quiver3(x, y, z, unit_u, unit_v, unit_w, 'r', 'LineWidth', 1.5);
hold on;
surf(x, y, z, 'FaceAlpha', 0.7);

xlabel('X');
ylabel('Y');
zlabel('Z');
title('Vector Field on Parametric Surface');
axis equal;
grid on;






