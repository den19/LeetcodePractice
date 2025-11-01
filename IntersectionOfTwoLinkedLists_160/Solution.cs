namespace IntersectionOfTwoLinkedLists_160
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
        /// BruteForce decision
        /// O(N*M), N,M lists lengths
        /// O(1)
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNodeBruteForce(ListNode headA, ListNode headB)
        {
            while(headA != null)
            {
                var temp = headB;
                while (temp != null)
                {
                    if(temp == headA)
                    {
                        return headA;
                    }
                }
            }

            return null;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if(headA == null || headB == null)
            {
                return null;
            }

            ListNode ptr1 = headA;
            ListNode ptr2 = headB;

            // While both pointers not equals to each other
            while (ptr1 != ptr2)
            {
                ptr1 = (ptr1 == null) ? headB : ptr1.next;
                ptr2 = (ptr2 == null) ? headA : ptr2.next;
            }

            return ptr1;
        }
    }
}
