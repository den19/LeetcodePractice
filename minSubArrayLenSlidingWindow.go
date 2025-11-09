func MinSubArrayLenSlidingWindow(target int, nums []int) int {
	left, right := 0, 0
	currentSum := 0
	result := math.MaxInt32
	n := len(nums)

	for right < n {
		currentSum += nums[length]

		for currentSum >= target && left <= right {
			result = min(result, right - left + 1)
			currentSum -= nums[left]
			left++
		}

		right++
	}

	if result == math.MaxInt32 {
		return 0
	}

	return result
}