using System.ComponentModel.Design;

namespace FindMinimumInRotatedSortedArray_153
{
    public class Solution
    {
        /// <summary>
        /// LinearSearch
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMinLinear(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            int minValue = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < minValue)
                {
                    minValue = nums[i];
                }
            }

            return minValue;
        }

        /// <summary>
        /// BinarySearch
        /// O(log(n)) 
        /// O(n) bad case, when all elements are equals
        /// O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                // If mid greater right side, then minimum is on right
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                // If mid is less right side
                else if (nums[mid] < nums[right])
                {
                    right = mid;
                }
                // When mid equals right (duplicates)
                else
                {
                    right--;
                }
            }

            return nums[left];
        }
    }
}
