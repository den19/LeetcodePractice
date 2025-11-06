namespace MiddleOfTheLinkedList_876
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
        /// Two - pass approach
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNodeTwoPass(ListNode head)
        {
            // First pass: legth count
            int length = 0;
            var current = head;

            while (current != null)
            {
                length++;
                current = current.next;
            }

            // Find the middle
            int midIndex = length / 2;
            current = head;
            for (int i = 0; i < midIndex; i++)
            {
                current = current.next;
            }

            return current;
        }

        /// <summary>
        /// One-pass approach
        /// Fast and slow pointers
        /// O(N)
        /// O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNodeOnePass(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return head;
            }

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
    }
}
