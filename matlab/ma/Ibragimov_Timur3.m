figure('name', "Task01", 'numbertitle', 'off');
line([0,0],[-4,-1]);
line([-2,0],[1,-1]);
line([2,0],[1,-1]);

figure('name', "Task02", 'numbertitle', 'off');
line([1 2 1.5; 2 3 2.5], [0 2 1; 2 0 1]);

figure('name', "Task03", 'numbertitle', 'off');
subplot(5, 1, 1);
line([3,3],[0,0.5]);
subplot(5, 1, 2);
line([3,3],[0.5,0.5]);
subplot(5,1,3);
line([3.5,3.5],[0.5,0]);
subplot(5,1,4);
line([3.5,3],[0,0]);
subplot(5,1,5);
line([3,3],[0,0.5]);
line([3,3],[0.5,0.5]);
line([3.5,3.5],[0.5,0]);
line([3.5,3],[0,0]);

figure('name', "Task04", 'numbertitle', 'off');
hold on;
quiver(3.5,0,0,2,0, 'LineWidth', 4, 'Color', 'blue');
quiver(3.5,1,0.5,1,0, 'LineWidth', 4, 'Color', 'blue');
quiver(4,2,1,0,0, 'LineWidth', 4, 'Color', 'blue');
hold off;

figure('name', "Task05", 'numbertitle', 'off');
hold on;
quiver3(0,0,0,1,0,0,0);
quiver3(0,0,0,0,1,0,0);
quiver3(0,0,0,0,0,1,0);
view(120,30);
hold off;

figure('name', "Task06", 'numbertitle', 'off');
hold on;
line([0 0; 3 0],[0 0; 0 3], 'linewidth', 2, 'color', 'green');
quiver(0,0,0,1,0, 'linewidth', 4, 'color', 'red');
quiver(0,0,1,0,0, 'linewidth', 4, 'color', 'red');
hold off;

figure('name', "Task07", 'numbertitle', 'off');
hold on;
line([0;4],[0;0],[0;0], 'linewidth', 2, 'color', 'blue');
line([0;0],[0;4],[0;0], 'linewidth', 2, 'color', 'blue');
line([0;0],[0;0],[0;4], 'linewidth', 2, 'color', 'blue');
quiver3(0,0,0,0,0,1,0, 'linewidth', 4, 'color', 'red');
quiver3(0,0,0,0,1,0,0, 'linewidth', 4, 'color', 'red');
quiver3(0,0,0,1,0,0,0, 'linewidth', 4, 'color', 'red');
hold off;

figure('name', "Task08", 'numbertitle', 'off');
grid on;
axis equal;
line([4 4 8; 4 8 8],[1 -4 -4; -4 -4 1], 'linewidth', 2, 'color', 'green')
axis([0 12 -5 2]);
text(4,1, '(4,1)');
text(4,-4, '(4,-4)');
text(8,-4, '(8,-4)');
text(8,1, '(8,1)');

figure('name', "Task09", 'numbertitle', 'off')
hold on;
A = [1.5 1];
B = [2 2];
C = [2.5 1];
AB = quiver(1.5,1,B(1)-A(1), B(2)-A(2),0, 'color', 'blue')
BC = quiver(2,2,C(1)-B(1),C(2)-B(1),0,  'color', 'blue')
AC = quiver(1.5,1,C(1)-A(1),C(2)-A(2),0)
text(1.5,1,'(1,1.5)')
text(2,2,'(2,2)')
text(2.5,1,'(2.5,1)')
hold off;

figure('name', "Task10", 'numbertitle', 'off')
A = [1.5 1]
B = [2 2]
C = [2.5 1]
D = [2 0]
hold on
subplot(2,1,1)
hold on
line([A(1) B(1) C(1) D(1);B(1) C(1) D(1) A(1)],
     [A(2) B(2) C(2) D(2);B(2) C(2) D(2) A(2)])
text(A(1),A(2),'(1.5,1)')
plot(A(1),A(2),"*")
text(B(1),B(2),'(2,2)')
plot(B(1),B(2),"*")
text(C(1),C(2),'(2.5,1)')
plot(C(1),C(2),"*")
text(D(1),D(2),'(2,0)')
plot(D(1),D(2),"*")
hold off
subplot(2,1,2)
hold on
AB = quiver(A(1),A(2),B(1)-A(1), B(2)-A(2),0, 'color', 'blue')
AD = quiver(A(1),A(2),D(1)-A(1),D(2)-A(2),0, 'color', 'blue')
AC = quiver(A(1),A(2),C(1)-A(1),C(2)-A(2),0,  'color', 'red')
BC = quiver(B(1),B(2),C(1)-B(1),C(2)-B(2),0,  'color', 'black')
DC = quiver(D(1),D(2),C(1)-D(1),C(2)-D(2),0, 'color', 'black')

figure('name', "Task11", 'numbertitle', 'off')
a1 = [2 2 4]
b1 = [1 1 1]
sum = a1 + b1
a2 = [6 5 4]
b2 = [1 1 1]
diff = a2 - b2
subplot(2,1,1)
hold on
quiver3(0,0,0,2,2,4,0, 'color', 'blue')
text(1,1,2,'\bfa1')
quiver3(2,2,4,1,1,1,0, 'color', 'blue')
text(2.5,2.5,4.5, '\bfb1')
quiver3(0,0,0,sum(1),sum(2),sum(3), 'color', 'red')
text(1.5,1.5,2.5, '\bfa1+b1')
hold off
subplot(2,1,2)
hold on
quiver3(0,0,0,6,5,4,0, 'color', 'blue')
text(3,2.5,2,'\bfa2')
quiver3(6,5,4,-1,-1,-1,0, 'color', 'blue')
text(5.5,4.5,3.5,'\bfb2')
quiver3(0,0,0,diff(1),diff(2),diff(3), 'color', 'red')
text(diff(1)/2,diff(2)/2,diff(3)/2,'\bfa2-b2')
