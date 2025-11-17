namespace MinimumPairRemovalToSortArrayI_3507
{
    public class Solution
    {
        /// <summary>
        /// Approach 3: Greedy With Stack (Optimal)
        /// Time: O(N)
        /// Memory: O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinPairRemovalOptimal(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            Stack<int> stack = new Stack<int>();
            int removals = 0;

            foreach(int num in nums)
            {
                // While stack has elements and current number is smaller than top
                while(stack.Count > 0 && num < stack.Peek())
                {
                    // Remove the violating pair
                    stack.Pop(); // Remove the larger element
                    removals++;

                    // If stack becomes empty after pop then break
                    if (stack.Count == 0) break;
                }
                stack.Push(num);                
            }
            return removals;
        }
    }
}
