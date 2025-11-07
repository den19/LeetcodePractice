#!/bin/bash

# Input data as an array of binary digits
binary_array = (1 0 1)

decimal_value = 0

for bit in "${binary_array[@]}"; do
	decimal_value = $((decimal_value * 2 + bit))
done

echo "$decimal_value"
