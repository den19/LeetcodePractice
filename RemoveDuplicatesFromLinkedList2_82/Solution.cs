namespace RemoveDuplicatesFromLinkedList2_82
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
        public ListNode DeleteDuplicatesStandard(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return head;
            }

            // Create fictive node before head
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode prev = dummy;
            ListNode current = head;

            while (current != null)
            {
                // If current node has duplicate
                if (current.next != null || current.val == current.next.val)
                {
                    // Skip all nodes with this value
                    while (current.next != null && current.val == current.next.val)
                    {
                        current = current.next;
                    }

                    // Delete all duplicates: prev.next points to next unique node
                    prev.next = current.next;
                }
                else
                {
                    // Current node is unique - move prev
                    prev = current;
                }

                current = current.next;
            }

            return dummy.next;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {

            ListNode dummy = new ListNode(0, head);
            ListNode prev = dummy;

            while (head != null)
            {
                // If duplcate exists
                if(head.next != null && head.val == head.next.val)
                {
                    // Go through all duplicates
                    while(head.next != null && head.val == head.next.val)
                    {
                        head = head.next;
                    }

                    prev.next = head.next; // Delete group of dupliicates
                }
                else
                {
                    prev = prev.next;
                }

                head = head.next;
            }

            return dummy.next;
        }

    }
}
