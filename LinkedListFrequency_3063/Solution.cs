namespace LinkedListFrequency_3063
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
        /// Optimized Hash Map Approach
        /// O(n)
        /// O(n)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode FrequencyOptimized(ListNode head)
        {
            if (head == null) return null;

            // Dictionary to store frequency counts

        }

        public ListNode FrequencyBruteForce(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode dummy = new ListNode();
            ListNode currentNew = dummy;
            ListNode current = head;

            while (current != null)
            {
                int value = current.val;
                int count = 0;

                // Count frequency of current value
                ListNode temp = head;
                while (temp != null)
                {
                    if(temp.val == value)
                    {
                        count++;
                    }
                    temp = temp.next;
                }

                // Check if we already prcessed this value
                bool alreadyProcessed = false;
                ListNode check = head;
                while (check != current)
                {
                    if (check.val == value)
                    {
                        alreadyProcessed = true;
                        break;
                    }
                    check = check.next;
                }

                //Add to result if first occurrence
                if (!alreadyProcessed)
                {
                    currentNew.next = new ListNode(count);
                    currentNew = currentNew.next;
                }
                current = current.next;
            }

            return dummy.next;
        }
    }
}
