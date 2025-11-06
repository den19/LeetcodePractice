namespace FindPeakElement_162
{
    public class Solution
    {
        /// <summary>
        /// Linear approach
        /// O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int FindPeakElementLinear(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                bool prevSmaller = true;
                bool nextSMaller = true;

                if(i > 0 && nums[i - 1] > nums[i])
                {
                    prevSmaller = false;
                }

                if(i < nums.Length - 1 && nums[i + 1] >= nums[i])
                {
                    nextSMaller = false;
                }

                if(prevSmaller && nextSMaller)
                {
                    return i;
                }
            }

            throw new Exception("No peak found");
        }

        public int FindPeakElementBinarySearch(int[] nums)
        {
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > nums[mid + 1])
                {
                    right = mid; // Move board left
                }
                else
                {
                    left = mid + 1; // Move right
                }
            }

            return left;
        }
    }
}
