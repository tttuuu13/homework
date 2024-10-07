disp("Task01")
A = [-2 4.5 6 8;
     -4 6 3.2 6;
     4 8 0 3.9;
     8 -2 10 7];
ans = A

disp("Task02")
B = randi([0,10], 4, 4);
ans = B

disp("Task03")
detB = det(B);
ans = detB

disp("Task04")
ans1 = A - 5*B
ans2 = A*B
ans3 = B'

disp("Task05")
C = ones(4,1);
C(1,1) = -1;
C(2,1) = -4;
C(4,1) = 8;
ans = C

disp("Task06")
X = B\C;
ans = X

disp("Task07")
syms x
ans = solve(det([2*sin(x) 2; 1 2*cos(x)]), x);

disp("Task08.1")
M = [1 -1 1; -3 14 2; 10 6 -5];
b = [3 1 2]';
Mx = My = Mz = M;
Mx(:,1) = b;
My(:,2) = b;
Mz(:,3) = b;
x = det(Mx)/det(M);
y = det(My)/det(M);
z = det(Mz)/det(M);
ans = [x,y,z]

disp("Task08.2")
M = [1 -1 0; -3 2 0; 10 6 -5];
b = [3 1 5]';
Mx = My = Mz = M;
Mx(:,1) = b;
My(:,2) = b;
Mz(:,3) = b;
x = det(Mx)/det(M);
y = det(My)/det(M);
z = det(Mz)/det(M);
ans = [x,y,z]

disp("Task09")
A = [1 -1 0; -3 2 0; 10 6 -5];
b = [3 1 5]';
C = [A b];
D = rref(C);
ans = D(:,4)'

disp("Task10")
A = [1 2 3; 4 3 5; 5 7 2];
B = [3 2 4; 3 4 5; 6 5 2];
ans = (2*A)*(2*A)*(2*A) - 4*(B*inv(A) + 2*eye(3))'

disp("Task11")
A = [-2 4.5 6 8; -4 6 3.2 6; 4 8 0 3.9; 8 -2 10 7];
C = [-1 -4 1 8]';
[L,U] = lu(A);
ans = (U\(L\C))
% Проверка
disp([A * ans C])

disp("Task12")
x = randi([0,1],5,6)(end-1,end-1);
ans = x

disp("Task13")
A = [1 -1 1; 2 1 -3; 3 -6 -5];
b = [8 -9 10]';
ans = (A\b)'
