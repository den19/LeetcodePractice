using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapNodesInPairs_24
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        /// <summary>
        /// Iterative Approach - Most Efficient
        /// Time O(N)
        /// Memory O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairsIterative(ListNode head)
        {
            // Create dummy node to simplify edge cases
            var dummy = new ListNode(0);

            dummy.next = head;

            var current = dummy;

            while (current.next != null && current.next.next != null)
            {
                // Nodes to be swapped
                var first = current.next;
                var second = current.next.next;

                // Perform the swap
                first.next = second.next;

                second.next = first;

                current.next = second;

                // Move current pointer two steps forward
                current = current.next.next;
            }

            return dummy.next;
        }

        /// <summary>
        /// Recursive Approach
        /// Time O(N)
        /// Memory O(N)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairsRecursive(ListNode head)
        {
            // Base case: empty list or single node
            if (head == null || head.next == null)
            {
                return head;
            }

            // Nodes to be swapped
            ListNode first = head;
            ListNode second = head.next;

            // Recursively swap the remaining pairs
            first.next = SwapPairsRecursive(second.next);
            second.next = first;

            // Return the new head (second node becomes head)
            return second;
        }

        /// <summary>
        /// Burte Force Approach (Value Swapping - Not Recommended)
        /// Time O(N)
        /// Memory O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairsBruteForce(ListNode head)
        {
            ListNode current = head;

            while (current != null && current.next != null)
            {
                // Swap values (violates problem constraint but works)
                int temp = current.val;
                current.val = current.next.val;
                current.next.val = temp;

                // Move two steps forward
                current = current.next.next;
            }

            return head;
        }
    }

}
