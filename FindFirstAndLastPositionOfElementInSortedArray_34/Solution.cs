namespace FindFirstAndLastPositionOfElementInSortedArray_34
{
    public class Solution
    {
        /// <summary>
        /// Linear Search
        /// O(n)
        /// O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0 || nums == null)
            {
                return new[] { -1, -1 };
            }

            // Variables for storing first and last found indices
            int startIndex = -1;
            int endIndex = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                // First meet
                if (nums[i] == target && startIndex == -1)
                {
                    startIndex = i;
                }

                // Last meet
                if (nums[i] == target)
                {
                    endIndex = i;
                }
            }

            if(startIndex == -1)
            {
                return new int[] { -1, -1 };
            }

            return new[] { startIndex, endIndex };
        }
    }
}
