namespace DeleteNodeInALinkedList_239
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
        /// Efficient solution
        /// O(1)
        /// O(1)
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ref ListNode node)
        {
            if(node.next == null)
            {
                node = null;
                return;
            }
            node.val = node.next.val;

            node.next = node.next.next;
        }
    }
}
