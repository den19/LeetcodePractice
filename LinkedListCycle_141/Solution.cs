namespace LinkedListCycle_141
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

    public class  Solution
    {
        /// <summary>
        /// Hash Table approach
        /// O(n)
        /// O(n)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycleHashTable(ListNode head)
        {
            var visitedNodes = new HashSet<ListNode>();

            while (head != null)
            {
                if (visitedNodes.Contains(head))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Two pointers approach, effective
        /// O(n)
        /// O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head.next;

            while (slow != fast)
            {
                if(fast == null || fast.next == null)
                {
                    return false;
                }

                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }
    }
}
