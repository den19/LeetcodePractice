using System.Reflection.Metadata.Ecma335;

namespace MinimumSizeSubarraySum_209
{
    public class Solution
    {
        /// <summary>
        /// Brute force
        /// O(N^2)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLenBruteForce(int target, int[] nums)
        {
            var n = nums.Length;
            var result = Int32.MaxValue;

            // If total sum is less than target, no valid solution exists
            if (Enumerable.Sum(nums) < target) return 0;

            for (var i = 0; i < n; ++i)
            {
                var currentSum = 0;

                for (var j = 0; j < n; ++j)
                {
                    currentSum += nums[j];

                    if(currentSum >= target)
                    {
                        result = Math.Min(result, j - i + 1);
                        break;
                    }
                }
            }

            return result;
        }

        public int MinSubArrayLenSlidingWindow(int target, int[] nums)
        {
            var n = nums.Length;
            var result = Int32.MaxValue;
            var left = 0;
            var right = 0;
            var currentSum = 0;

            while (right < n)
            {
                currentSum += nums[right++];

                while (currentSum >= target)
                {
                    result = Math.Min(result, right - left);
                    currentSum -= nums[left++];
                }
            }

            return result == Int32.MaxValue ? 0 : result;
        }
    }
}
