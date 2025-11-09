namespace DeleteNNodesAfterMNodesOfALinkedList_1474
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
        /// Linear Brute force solution
        /// O(N)
        /// O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m">Take M</param>
        /// <param name="n">Delete N</param>
        /// <returns></returns>
        public ListNode DeleteNodesLinear(ListNode head, int m, int n)
        {
            if (head == null || m < 0 || n < 0) return head;

            // Create fictive dummy node to simplify work with head
            var dummy= new ListNode(-1);
            dummy.next = head;

            var current = dummy;

            while (current != null && current.next != null)
            {
                // Go forward m nodes
                for (var i = 0; i < m && current != null; i++)
                {
                    current = current.next;
                }

                // If we reach the end, finish work
                if (current == null) break;

                // Delete N nodes after current node
                var temp = current;

                for(var j = 0; j < n && temp?.next != null; j++)
                {
                    temp = temp.next;
                }

                // Renew current element link to the next after deleting
                current.next = temp?.next;

                // Move to the next list node
            }

            return dummy.next;

        }
    }
}
