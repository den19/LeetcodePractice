namespace ReverseLinkedList_206
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
        /// Ordinary recursive approach 
        /// O(n)
        /// O(n)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseListRecursive(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return head;
            }

            var newHead = ReverseListRecursive(head.next);

            // Transfer links backwards
            head.next.next = head;
            head.next = null;

            return newHead;
        }

        /// <summary>
        /// Reverse List Iterative
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;

            while (curr != null)
            {
                // Save link to next node
                ListNode nextTemp = curr.next;

                // Change direction of next to previous
                curr.next = prev;

                // Move previous position forward
                prev = curr;

                // Goto next node
                curr = nextTemp;
            }

            return prev;
        }
    }
}
