.data 
	msg: .asciz "Максимальное значение аргумента: "

	result: .word 0           
	max_value: .word 0x7FFFFFFF  # Максимальное значение для 32-битного целого числа

.text
main:
	la a0, msg               # Выводим текст о максимальном значении аргумента
	li a7, 4
	ecall

	li t1, 1                 # Начальное значение факториала
	li t0, 1                 # Начальное значение n
	lw t3, max_value         # Загружаем максимальное значение в t3
	jal compute_factorial    # Переходим к вычислению факториала

	la t4, result            # Загружаем адрес переменной для результата
	sw t1, 0(t4)             # Сохраняем результат в памяти

	li a7, 1                 # Выводим максимальный аргумент
	ecall
	
	li a7, 10                # Завершение программы
	ecall

compute_factorial:
	addi t0, t0, 1           # Увеличиваем n на единицу
	div t5, t3, t0           # Вычисляем t5 = max_value / n
	bge t1, t5, end_factorial# Если факториал >= t5, завершаем
	mul t1, t1, t0           # Вычисляем текущий факториал
	j compute_factorial      # Повторяем цикл

end_factorial:
	addi t0, t0, -1          # Уменьшаем n для получения корректного значения
	mv a0, t0                # Возвращаем найденный аргумент
	ret       
