using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartitionList_86
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

    internal class SolutionBruteForce
    {
        /// <summary>
        /// Brute force solution
        /// O(n^2)
        /// O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int x)
        {
            ListNode dummy = new ListNode(0, head);
            ListNode current = dummy;

            while (current.next != null && current.next.val < x)
            {
                current = current.next;
            }

            ListNode insertPos = current;
            current = current.next;

            while (current != null && current.next != null)
            {
                if (current.next.val < x)
                {
                    // Удаляем узел с значением < x из текущей позиции
                    ListNode smaller = current.next;
                    current.next = current.next.next;

                    // Вставляем его после insertPos
                    smaller.next = insertPos.next;
                    insertPos.next = smaller;
                    insertPos = insertPos.next;
                }
                else
                {
                    current = current.next;
                }
            }

            return dummy.next;
        }
    }
}
