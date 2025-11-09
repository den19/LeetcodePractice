def minSubArrayLenBruteForce(target: int, nums: list[int]) -> int:
    n = len(nums)
    if sum(nums) < target:
        return 0

    result = float('inf')
    for i in range(n):
        current_sum = 0
        for j in range(i, n):
            current_sum += nums[j]
            if current_sum >= target:
                result = min(result, j - i + 1)
                break
    return result