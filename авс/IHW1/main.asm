.include "macros.asm"

main:
	# Save filtered array to B and save B's length to a0
	filter_array a1 a2 a3 a4
	
	# Print array B
	print_array a3 a0
	ret