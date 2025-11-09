func MinSubArrayLenBruteForce(target int, nums []int) int {
	n := len(nums)
	result := math.MaxInt32
	totalSum := 0
	for _, num := range nums {
		totalSum += num
	}
	if totalSum < target {
		return 0
	}

	for i := 0; i < n; i++ {
		currentSum := 0
		for j := i; j < n; j++ {
			currentSum += nums[j]
			if currentSum >= target {
				result := min(result, j - i + 1)
				break
			}
		}
	}

	return result
}

func min(a, b int) int {
	if a < b { return a}
	return b
}