def minSubArrayLenSlidingWindow(target: int, nums: list[int]) -> int:
    left = right = 0
    current_sum = 0
    result = float('inf')
    n = len(nums)

    while right < n:
        current_sum += nums[right]
        while current_sum >= target:
            result = min(result, right - left + 1)
            current_sum -= nums[left]
            left += 1
        right += 1
    return result if result != float('inf') else 0