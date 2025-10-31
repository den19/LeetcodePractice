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
        /// Linear Search
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchLinear(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == target)
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
        /// <param name="terget"></param>
        /// <returns></returns>
        public int Search(int[] nums, int terget)
        {
            int left = 0, right = nums.Length - 1;


        }
    }
}
