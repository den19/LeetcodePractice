using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveLinkedListElements_203
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
        /// Ordinary Linear Scan
        /// O(n)
        /// O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode RemoveElementsLinearScan(ListNode head, int val)
        {
            // Create dummy node for simplicity with first element
            var dummyHead = new ListNode(-1);
            dummyHead.next = head;

            var current = dummyHead;

            while (current != null && current.next != null)
            {
                if (current.next.val == val)
                {
                    // If next node has needed value, then skip it
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return dummyHead.next;
        }

        /// <summary>
        /// Optimized solution
        /// O(n)
        /// O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode RemoveElements(ListNode head, int val)
        {
            // Fictive node
            var dummyHead = new ListNode(-1);
            dummyHead.next = head;

            var prev = dummyHead;

            while (prev.next != null)
            {
                if (prev.next.val == val)
                {
                    // Just move the link, skipping needed node value
                    prev.next = prev.next.next;
                }
                else
                {
                    // Goto next node
                    prev = prev.next;
                }
            }

            return dummyHead.next;
        }
    }
}
