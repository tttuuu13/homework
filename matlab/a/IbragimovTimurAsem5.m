disp("Task01")
a = [1; 2; 3];
b = [4; 6; 5];
result = cross(a, b);
disp(result);

disp("Task02")
a = [1; 2; 3];
b = [4; 6; 5];
ab = cross(a, b);
ba = cross(b, a);
result = ab + ba;
disp(result);

disp("Taslk03")
a = [3, 1, 1];
b = [0.5, 2, 1];
c = [-1, -2, 3];
result = dot(cross(a, b), c);
disp(result);

disp("Task04")
b = [0.5, 2, 1];
c = [-1, -2, 3];
result = dot(b, c);
disp(result);

disp("Task05")
a = [1, 2, 3];
b = [4, 5, 6];
c = [3, 3, 4];
volume = abs(dot(cross(a, b), c));
disp(volume);

disp("Task06")
a = [1, 2];
b = [2, 3];
c = a' * b;
disp(c);

% Task07
% Пункт 7: Построение конических сечений в полярной системе координат
epsilon_values = [0.5, 1, 2];
a_values = [2, 4, 8];
phi = -pi:0.1*pi:pi;

figure;
hold on;
for phi_idx = 1:length(phi)
    phi_val = phi(phi_idx);
    for i = 1:length(epsilon_values)
        epsilon = epsilon_values(i);
        a = a_values(i);
        rho = (1 - epsilon * cos(phi_val)) / a;
        [x, y] = pol2cart(phi_val, rho); % Преобразование в декартовы координаты
        plot(x, y, '-o', 'DisplayName', ['ɛ=' num2str(epsilon) ', a=' num2str(a) ', \phi=' num2str(phi_val)]);
    end
end
title('Конические сечения в декартовой системе координат');
legend;
hold off;


%Task08
% Пункт 8: Построение трехмерного графика в цилиндрической системе координат
phi = -pi:0.05*pi:pi;
rho = linspace(0, 2, 100);

figure;
hold on;
for phi_idx = 1:length(phi)
    phi_val = phi(phi_idx);
    X = rho .* cos(phi_val);
    Y = rho .* sin(phi_val);
    Z = repmat(phi_val, size(X)); % z = phi
    surf(X, Y, Z, 'DisplayName', ['\phi=' num2str(phi_val)]);
end
hold off;
title('График в декартовой системе координат (цилиндрические)');
xlabel('X');
ylabel('Y');
zlabel('Z');
legend;







