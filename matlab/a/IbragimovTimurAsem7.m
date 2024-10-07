disp("Task01")
A = [3 2 1; 2 3 2; 1 2 5];
b = [8; 9; 10];

[U, S, V] = svd(A);
x = U * pinv(S) * V' * b;
disp(x);

disp("Task02")
A = [3 2 1; 2 3 2; 1 2 5];
b = [8; 9; 10];

R = chol(A);
y = R' \ b;
x = R \ y;
disp(x);

disp("Task03")
function [x, iter] = richardson_iteration(A, b, tau, max_iter)
    n = length(b);
    x = zeros(n, 1);
    iter = 0;
    r = norm(b - A*x);

    while r > 1e-4 && iter < max_iter
        x = x + tau * (b - A*x);
        iter = iter + 1;
        r = norm(b - A*x);
    end
end

A = [3 2 1; 2 3 2; 1 2 5];
b = [8; 9; 10];

% Параметры метода
tau = 0.1; % Параметр релаксации
max_iter = 1000; % Максимальное число итераций

% Вызов функции для решения системы методом итераций Ричардсона
[x, iter] = richardson_iteration(A, b, tau, max_iter);

% Вывод решения и количества итераций
disp("Решение системы методом итераций Ричардсона:");
disp(x);
disp(["Количество итераций: ", num2str(iter)]);

% Проверка решения
r = norm(b - A*x);
disp("Невязка:");
disp(r);

% Если невязка меньше порога, считаем решение верным
if r < 1e-4
    disp("Решение верно.");
else
    disp("Решение неверно.");
end

disp("Task04")
