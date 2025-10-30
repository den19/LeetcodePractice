namespace MergeTwoSortedLists_21_Easy
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

    public static class Solver
    {
        // Function for create linked list from int array
        public static ListNode CreateLinkedList(int[] values)
        {
            ListNode head = null;
            ListNode tail = null;
            foreach (var v in values)
            {
                if (head == null)
                {
                    head = new ListNode(v);
                    tail = head;
                }
                else
                {
                    tail.next = new ListNode(v);
                    tail = tail.next;
                }
            }
            return head;
        }

        /// <summary>
        /// Ordinal recursive method
        /// Time O(N + M)
        /// Memory O(N + M)
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoListsOrdinal(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            // Select smaller node
            if (l1.val <= l2.val)
            {
                l1.next = MergeTwoListsOrdinal(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoListsOrdinal(l1, l2.next);
                return l2;
            }
        }

        /// <summary>
        /// Iterational memory efficient method
        /// Time O(N + M)
        /// Memory O(1)
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoListsIterativeMemoryEfficient(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode();
            var current = dummy;

            while (l1 != null && l2 != null)
            {
                if(l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }

            return dummy.next;
        }
    }
}
