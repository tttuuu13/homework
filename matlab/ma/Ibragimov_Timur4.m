disp("Task01")
a = [1 1 3];
b = [2 2 5];
an = 2;
bn = 4;
if isequal([isequal(an*(a+b),an*a+an*b) isequal((an+bn)*a,an*a+bn*a) isequal(an*(bn*a),(an*bn)*a)], [1 1 1])
  disp("Everything is right")
else
  disp("There is a mistake")
end

disp("Task02")
a = [1 1 -1];
ax = (dot([1 0 0],a)/norm(a));
ay = (dot([0 1 0],a)/norm(a));
az = (dot([0 0 1],a)/norm(a));
if 0.999 < ax^2+ay^2+az^2 < 1.001
  "Fine"
end

b = [6 4];
ax = dot([1 0],b)/norm(b);
ay = dot([0 1],b)/norm(b);
if 0.999 < ax^2+ay^2 < 1.001
  "Fine"
end

disp("Task03")
a = [1 2 3];
b = [2 3 4];
c = [2 4 6];
if [(a+b==b+a) ((a+b)+c==a+(b+c))] == [1 1 1 1 1 1]
  disp("Everything is right")
else
  disp("There is a mistake")
end

if isequal([isequal(a+b,b+a) isequal((a+b)+c,a+(b+c))], [1 1])
  disp("Everything is right for the second time")
else
  disp("There is a mistake")
end

disp("Task04")
a = [2 2 3];
len_a=sqrt(a(1)^2+a(2)^2+a(3)^2)
len_a = norm(a)

b = [4 5];
len_b=sqrt(b(1)^2+b(2)^2)
len_b = norm(b)

disp("Task05")
a = [1 -2 0];
b = [0 1 2];
c = [1 2 1];
if det([a' b' c']') != 0
  disp("Векторы некомпланарны")
end
hold on
a=quiver3(0,0,0,1,-2,0,0)
b=quiver3(0,0,0,0,1,2,0)
c=quiver3(0,0,0,1,2,1,0)
x=quiver3(0,0,0,1,0,0,0, 'color', 'red', 'linewidth', 3)
y=quiver3(0,0,0,0,1,0,0, 'color', 'red', 'linewidth', 3)
z=quiver3(0,0,0,0,0,1,0, 'color', 'red', 'linewidth', 3)
orta=[1 -2 0]/norm([1 -2 0]);
orta=quiver3(0,0,0,orta(1),orta(2),orta(3),0, 'linewidth', 2)
ortb=[0 1 2]/norm([0 1 2]);
ortb=quiver3(0,0,0,ortb(1),ortb(2),ortb(3),0, 'linewidth', 2)
ortc=[1 2 1]/norm([1 2 1]);
ortc=quiver3(0,0,0,ortc(1),ortc(2),ortc(3),0, 'linewidth', 2)
view(70,15)
hold off;

disp("Task06")
p = [2 -2];
q = [3 2];
s=[5 4];
if (p./q)(1) != (p./q)(2)
  disp("Векторы неколлинеарны.")
end
figure()
hold on;
quiver(0,0,2,-2,0)
quiver(0,0,3,2,0)
mp = p*([2 -2;3 2]\s')(1);
nq = q*([2 -2;3 2]\s')(2);
quiver(0,0,5,4,0)
quiver(0,0,mp(1),mp(2),0)
quiver(0,0,nq(1),nq(2),0)
