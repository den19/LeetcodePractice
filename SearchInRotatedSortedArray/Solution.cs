using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInRotatedSortedArray_3
{
    internal class Solution
    {
        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchLinear(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
            }
                return -1;
        }

        /// <summary>
        /// Binary Search
        /// O(log(n))
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchBS(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                // If found target element
                if (nums[mid] == target)
                {
                    return mid;
                }

                // Left side sorted
                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        // Target is on left side
                        right = mid - 1;
                    }
                    else
                    {
                        right = mid + 1;
                    }
                }
                // Right side sorted
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        // Target is on right side
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }
    }
}
