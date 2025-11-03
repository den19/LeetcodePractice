namespace PalindromeLinkedList_234
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
        /// Ordinary approach
        /// Time O(N)
        /// Memory O(N)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            // Copy values to C# List
            var values = new List<int>();

            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }

            // Check, if C# List is palindrome
            for(int i = 0; i < values.Count /2; ++i)
            {
                if(values[i] != values[values.Count - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Function to reverse list
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private ListNode ReverseList(ListNode node)
        {
            ListNode prev = null;

            while (node != null)
            {
                ListNode tempNext = node.next;
                node.next = prev;
                prev = node;
                node = tempNext;
            }

            return prev;
        }

        /// <summary>
        /// Time O(N)
        /// Memory O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindromeOptimized(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return true;
            }

            // Step 1. Find half of the list
            ListNode slow = head, fast = head;
            while(fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // Step 2. Reverse second half of the list
            ListNode secondHalfHead = ReverseList(slow.next);

            // Disconnect two halves
            slow.next = null;

            // Compare two sides
            ListNode firstHalfHead = head;
            while (firstHalfHead != null && secondHalfHead != null)
            {
                if(firstHalfHead.val != secondHalfHead.val)
                {
                    return false;
                }

                firstHalfHead = firstHalfHead.next;
                secondHalfHead = secondHalfHead.next;
            }

            return true;
        }
    }
}
