# main.asm
```
.data
	array_a: .space 40
	array_b: .space 40
	enter_n_prompt: .asciz "Please enter N(0 <= N <= 10): "
	enter_x_prompt: .asciz "Please enter X: "
	enter_num_prompt: .asciz "Please enter number: "
	input_out_of_range_msg: .asciz "ERROR: input is out of range, restarting the program...\n"
.include "macros.asm"
.text
main:
	# Store register's values on stack
	addi sp sp, -16
	sw s0 (sp)
	sw s1 4(sp)
	sw s2 8(sp)
	sw s3 12(sp)
	
	# Get N
	input_number enter_n_prompt
	
	# Validate input
	blez a0 input_out_of_range
	li t0 10 # upper bound
	bgt a0 t0 input_out_of_range
	mv s0 a0 # store N
	
	# Get X
	input_number enter_x_prompt
	mv s1 a0 # store X
	
	# Get array
	mv a0 s0
	la a1 array_a
	input_array a1 a0
	
	# Filter array and save to B
	la a0 array_a
	mv a1 s0
	la a2 array_b
	mv a3 s1
	filter_array a0 a1 a2 a3 # sets a0 to B's length
	
	# Print array B
	print_array a2 a0
	
	# Restore registers
	lw s0 (sp)
	lw s1 4(sp)
	lw s2 8(sp)
	lw s3 12(sp)
	addi sp sp 16
	j exit
	
input_out_of_range:
	la a0 input_out_of_range_msg
	li a7 4
	ecall
	j main

exit:
	li a7 10
	ecall
```
# macros.asm
```
.data
	enter_number_prompt: .asciz "\nEnter number: "
	whitespace: .asciz " "

.macro input_number %prompt
	# Display prompt
	la a0 %prompt
	li a7 4
	ecall
	# Read input
	li a7 5
	ecall
.end_macro 

.macro input_array %array_ref %length
	# Store register's values on stack
	addi sp sp -12
	sw s0 (sp)
	sw s1 4(sp)
	sw s2 8(sp)
	
	# Configure variables
	li s0 0
	mv s1 %length
	mv s2 %array_ref
	
	# Read N elements
	insert_elem:
		input_number enter_number_prompt
		sw a0 0(s2)
		addi s0 s0 1
		addi s2 s2 4
		blt s0 s1 insert_elem
		
	# Restore registers
	lw s0 (sp)
	lw s1 4(sp)
	lw s2 8(sp)
	addi sp sp 12
.end_macro

.macro filter_array %source_array_ref %source_length %dest_array_ref %x
	# Store register's values on stack
	addi sp sp -28
	sw s0 (sp)
	sw s1 4(sp)
	sw s2 8(sp)
	sw s3 12(sp)
	sw s4 16(sp)
	sw s5 20(sp)
	sw s6 24(sp)
	
	# Configure variables
	li s0 0 # source index
	mv s1 %source_array_ref
	mv s2 %source_length
	li s3 0 # destination index
	mv s4 %dest_array_ref
	mv s5 %x
	
	# Iterate through array
	loop:
		lw s6 0(s1)
		bne s6 s5 not_equal
		j continue
		not_equal:
			sw s6 0(s4)
			addi s3 s3 1
			addi s4 s4 4
		continue:
			addi s0 s0 1
			addi s1 s1 4
			blt s0 s2 loop
	
	# Load destination array's length to a0
	mv a0 s3
	
	# Restore registers
	lw s0 (sp)
	lw s1 4(sp)
	lw s2 8(sp)
	lw s3 12(sp)
	lw s4 16(sp)
	lw s5 20(sp)
	lw s6 24(sp)
	addi sp sp 28
.end_macro		

.macro print_array %array_ref %length
	# Store register's values on stack
	addi sp sp -16
	sw s0 (sp)
	sw s1 4(sp)
	sw s2 8(sp)
	sw s3 12(sp)
	
	mv s0 %array_ref
	li s1 0 # index
	mv s2 %length
	
	print_loop:
		lw s3 (s0)
		mv a0 s3
		li a7 1
		ecall
		la a0 whitespace
		li a7 4
		ecall
		addi s1 s1 1
		addi s0 s0 4
		blt s1 s2 print_loop

	# Restore registers
	lw s0 (sp)
	lw s1 4(sp)
	lw s2 8(sp)
	lw s3 12(sp)
	addi sp sp 16
.end_macro
```
# 4 - 5 баллов
* Решение приведено выше, ввод осуществляется с клавиатуры, вывод осуществляется на дисплей. Пример ввода-вывода программы:
	```
	Please enter N(0 <= N <= 10): 3
	Please enter X: 2
	Enter number: 1
	Enter number: 2
	Enter number: 3
	1 3 
	-- program is finished running (0) --
	```
 * Комментарии на месте
 * Тесты будут дальше
