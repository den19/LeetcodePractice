using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInRotatedSortedArray2
{
    public class Solution
    {
        /// <summary>
        /// Linear Search O(n)
        /// O(n)
        /// O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchLinear(int[] nums, int target)
        {
            foreach (var num in nums)
            {
                if(num == target) return true;
            }
            return false;
        }

        /// <summary>
        /// Optimal solution - modified binary search
        /// O(log(n))
        /// O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                // Step 1. Case with a duplicates
                while(left < right && nums[left] == nums[right])
                {
                    left++;
                }
                
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return true;

                // Check left side
                if(nums[left] <= nums[mid])
                {
                    if(target >= nums[left] && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                // Check right side
                {
                    if (target > nums[mid] && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return false;
        }
    }
}
