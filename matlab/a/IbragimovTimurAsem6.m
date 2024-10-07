disp("Task01")
a = [1, 2, 3, 4, 5];
b = a(end:-1:1);
disp(a);
disp(b);

disp("Task02")
a = [10, 7, 25, 4, 15, 8, 30];
b = a(mod(a, 5) == 0);
c = a(mod(a, 5) != 0);
disp(b);
disp(c);

disp("Task03")
a = [-3, 0, 5, -2, 0, 7, 8];
b = sum(a(a >= 0));
disp(b);
sum_zero = sum(a(a == 0));
disp(sum_zero);

disp("Task04")
a = [10, 20, 30, 40, 50];
m = mean(a);
a(abs(a - m) > 0.5 * m) = m;
disp(a);

disp("Task05")
result = nthroot(1953125, 9);
disp(result);

pkg load statistics;
disp("Task06")
a = [10, 20, 30, 20, 50];
m = geomean(a);
a(a == max(a)) = m;
disp(a);

disp("Task07")
input_matrix = [1, 6, -9; 12, -3, 7; 4, -15, 9];
positive_divisible_by_3 = sum(sum(input_matrix > 0 & mod(input_matrix, 3) == 0));
negative_divisible_by_3 = sum(sum(input_matrix < 0 & mod(input_matrix, 3) == 0));
disp(positive_divisible_by_3);
disp(negative_divisible_by_3);

disp("Task08")
A = [2 3 3; 4 2 3; 6 5 6];
b = [8; 7; 7];
x = A\b;
disp(x);
cond_A = cond(A);
rank_A = rank(A);
r = 1/cond(A);
disp(cond_A);
disp(rank_A);
disp(r);
x_gauss = linsolve(A, b);
disp(x_gauss);

disp("Task09")
t = [0 0.1 0.2 0.3 0.4 0.5];
y = [4.25 3.95 3.64 3.41 3.21 3.04];

A = [exp(t); t]';
b = y';

x = (A' * A) \ (A' * b);
a = x(1);
b = x(2);

figure;
plot(t, y, 'o', 'MarkerSize', 8, 'MarkerFaceColor', 'b', 'MarkerEdgeColor', 'b');
hold on;
fplot(@(t) a * exp(t) + b * t, [0, 0.5], 'r', 'LineWidth', 2);
hold off;
xlabel('t');
ylabel('y');
title('Title09');
legend('y(t)', 'y(t) = a * e^t + b * t');
grid on;

disp("Task10")
A = [4 2 3; 3 4 3];
b = [2; 2];

x = A \ b;
disp(x');

result = A * x;
disp(result');

disp("Task11")
A = [2 3 3; -2 -3 -3];
b = [8; 7];

x = linsolve(A, b);
disp(x');

result = A * x;
disp(result');

cond_A = cond(A);
rank_A = rank(A);
disp(cond_A);
disp(rank_A);

disp("Task12")
A = [2 3 3; -2 -3 -3];
b = [8; 7];

[Q, R] = qr(A);
x = R \ (Q' * b);

disp(x);

disp("Task13")
A = [4 4 5; 3 5 7; 6 5 2];

[V, D] = eig(A);

disp("Третий собственный вектор:");
disp(V(:, 3)');
disp("Соответствующее ему собственное число:");
disp(D(3, 3));























