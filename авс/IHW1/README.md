# main.asm
```Assembly
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
