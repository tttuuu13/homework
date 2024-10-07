disp("Task01")
syms x;
limit(sym('(x^2-1)/(2*x+1/6)'),x,-1/3)

disp("Task02")
f = sym('(2+x)^(1/x)');
syms x;
limit(f,x,0,'left')
limit(f,x,0,'right')

disp("Task03")
syms x;
x1 = -4:0.1:4;
plot(x1,((2+x1).^(1./x1)));

disp("Task04")
syms x x0;
diff(acot(x),x,1)
limit((acot(x0)-acot(x))/(x0-x),x,x0)

disp("Task05")
syms x;
diff(sym('(3*sin(2*x^3))^4'),x,1)

disp("Task06")
syms x;
limit(sym('sin(x)/x'),x,0)

disp("Task07")
syms x;
limit(sym('(1-exp(-x))/x'),x,Inf)

disp("Task08")
syms x;
limit(sym('(1-x)/log(x)'),x,1)

disp("Task09")
syms x;
diff(sym('(x^3)*sin(x/3)'),x,6)

disp("Task10")
syms x;
limit(sym('1-exp(-x)/x'),x,Inf)

disp("Task11")
syms x;
diff(sym('exp(-a*x^2)+log(a^n+x^a)'),x,2)

disp("Task12")
figure()
s = quad('cos(x)-x*sin(x)',-3,1,1.0e-05);
x1 = -3:1.0e-05:1;
plot(x1,cos(x1)-x1.*sin(x1));
hold on;
area(x1,cos(x1)-x1.*sin(x1));

disp("Task13")
hold on;
quad('x^2+1',1,3)












