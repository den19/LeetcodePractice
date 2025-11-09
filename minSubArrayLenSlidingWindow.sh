min_subarray_len_sliding_window() {
	local target = $1
	shift
	local nums = ("$@")
	local n = ${#nums[@]}
	local left = 0
	local right = 0
	local current_sum = 0
	local result = "INF"

	while [[ $right - lt $n]]; do
		let current_sum += ${nums[$right]}

		while [[ $current_sum -ge $target && $left -le $right ]]; do
			local temp_result = $(($right - $left + 1))
			if [[ "$temp_result" -lt "$result" || "result" == "INF" ]]; then
				result = $temp_result
			fi

			let current_sum -= ${nums[$left]}
			let left += 1
		done

		let right += 1
	done

	if [[ "$result" = "INF" ]]; then
		echo 0
	else
		echo $result
	fi
}

#Example usage
min_sub_array_len_sliding_window 7 2 3 1 2 4 3