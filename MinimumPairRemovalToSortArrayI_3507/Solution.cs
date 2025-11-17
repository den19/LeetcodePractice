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
        // Approach 3: Greedy using Stack - Most efficient
        // Time: O(n) Space: O(n)
        public int MinPairRemovalOptimal(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            Stack<int> stack = new Stack<int>();
            int removals = 0;

            foreach (int num in nums)
            {
                // While stack has elements and current number is smaller than top
                while (stack.Count > 0 && num < stack.Peek())
                {
                    // Remove the violating pair
                    stack.Pop(); // Remove the larger element
                    removals++;

                    // If stack becomes empty after pop, break
                    if (stack.Count == 0) break;
                }

                stack.Push(num);
            }

            return removals;
        }
        // Approach 1: Brute Force - Try all possible removals
        // Time: O(2^n) Space: O(n)
        public int MinPairRemovalBruteForce(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            // Check if already sorted
            if (IsSorted(nums.ToList())) return 0;

            return Backtrack(nums.ToList(), 0);
        }

        private int Backtrack(List<int> current, int removals)
        {
            // Base case: if array is sorted, return number of removals
            if (IsSorted(current)) return removals;

            int minRemovals = int.MaxValue;

            // Try removing each adjacent pair
            for (int i = 0; i < current.Count - 1; i++)
            {
                // Remove pair at position i, i+1
                int removed1 = current[i];
                int removed2 = current[i + 1];

                current.RemoveAt(i);
                current.RemoveAt(i); // i+1 becomes i after first removal

                minRemovals = Math.Min(minRemovals, Backtrack(current, removals + 1));

                // Backtrack: restore removed elements
                current.Insert(i, removed1);
                current.Insert(i + 1, removed2);
            }

            return minRemovals;
        }

        private bool IsSorted(List<int> arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (arr[i] > arr[i + 1]) return false;
            }
            return true;
        }


        // Approach 2: DP - Find Longest Non-Decreasing Subsequence
        // Time: O(n^2) Space: O(n)
        public int MinPairRemovalDP(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            int[] dp = new int[n];

            // Each element is a subsequence of length 1
            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
            }

            // Find longest non-decreasing subsequence
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] <= nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            int longestSubsequence = dp.Max();

            // Minimum removals = total elements - longest valid subsequence
            // Since we remove pairs, we need to calculate how many pair removals
            // are needed to achieve this subsequence
            int elementsToRemove = n - longestSubsequence;

            // Each removal removes 2 elements, but we might have odd numbers
            // So we calculate the actual pair removals needed
            return (elementsToRemove + 1) / 2;
        }

        // Approach 4: Two Pointers - Find valid subsequence
        // Time: O(n) Space: O(1)
        public int MinPairRemovalTwoPointers(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int validCount = 1; // First element is always valid
            int lastValid = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] >= lastValid)
                {
                    validCount++;
                    lastValid = nums[i];
                }
            }

            int elementsToRemove = nums.Length - validCount;
            return (elementsToRemove + 1) / 2;
        }
    }
}
