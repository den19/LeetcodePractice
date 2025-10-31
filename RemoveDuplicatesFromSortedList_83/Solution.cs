using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicatesFromSortedList_83
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
        /// Ordinary method for remove duplicates
        /// O(n)
        /// O(1)
        /// Optimal algorithm
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return head;
            }

            var current = head;

            while (current != null && current.next != null)
            {
                if(current.val == current.next.val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }

            return head;
        }

        /// <summary>
        /// Optimized approach using HashSet
        /// O(n)
        /// O(k), k - number of unique elemnts in HasSet
        /// Not optimal algorithm compared to previous
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicatesSet(ListNode head)
        {
            var seenValues = new HashSet<int>();
            var dummyHead = new ListNode(-1);
            dummyHead.next = head;
            var prev = dummyHead;

            while (head != null)
            {
                if (seenValues.Contains(head.val))
                {
                    prev.next = head.next;
                }
                else
                {
                    seenValues.Add(head.val);
                    prev = head;
                }
                head = head.next;
            }

            return dummyHead.next;
        }
    }


}
