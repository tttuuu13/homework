% Заданные точки
x = [1 2 3 4 5 7 10 14 19 25];
y = [0 -1 -3 -2 -4 -3 -6 -4 -10 -20];

% Промежуточные точки
x_interp = linspace(1, 25, 2401);
y_interp = zeros(size(x_interp));

% Линейная интерполяция
y_interp_linear = interp1(x, y, x_interp, 'linear');

% Кубическая интерполяция
y_interp_cubic = interp1(x, y, x_interp, 'pchip');

% Кубическая интерполяция с использованием сплайнов первого порядка
y_interp_cubic_p1 = interp1(x, y, x_interp, 'spline');

% Кубическая интерполяция с использованием сплайнов второго порядка
y_interp_cubic_p2 = interp1(x, y, x_interp, 'cubic');

% Построение графиков
figure;
plot(x, y, 'o', 'MarkerSize', 8); % Точки данных
hold on;
plot(x_interp, y_interp_linear, 'LineWidth', 1.5); % Линейная интерполяция
plot(x_interp, y_interp_cubic, 'LineWidth', 1.5); % Кубическая интерполяция
plot(x_interp, y_interp_cubic_p1, 'LineWidth', 1.5); % Кубическая интерполяция с использованием сплайнов первого порядка
plot(x_interp, y_interp_cubic_p2, 'LineWidth', 1.5); % Кубическая интерполяция с использованием сплайнов второго порядка
hold off;

% Добавление легенды
legend('Точки данных', 'Линейная', 'Кубическая', 'Кубическая с 1-м сплайном', 'Кубическая с 2-м сплайном');

% Добавление подписей к осям и заголовка
xlabel('x');
ylabel('y');
title('Интерполяция сплайнами различных порядков');

