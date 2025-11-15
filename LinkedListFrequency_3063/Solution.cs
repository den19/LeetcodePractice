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
        public ListNode FrequencyBruteForce(ListNode head)
        {
            if (head == null) return null;

            ListNode dummy = new ListNode(0);
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
                    if (temp.val == value)
                    {
                        count++;
                    }
                    temp = temp.next;
                }

                // Check if we alrewady processed this value
                bool alreadyProcessed = false;
                ListNode check = head;
                while (check != current)
                {
                    if (check.val == value)
                    {
                        alreadyProcessed = true;
                        break;
                    }
                }

                // Add to result if result occurrance
                if (!alreadyProcessed)
                {
                    currentNew.next = new ListNode(count);
                    currentNew = currentNew.next;
                }

                current = current.next;
            }
            return dummy.next;
        }

        public ListNode FrequencyOptimized(ListNode head)
        {
            if (head == null) return null;

            // Dictionary to store frequency counts
            var frequencyMap = new Dictionary<int, int>();

            // First Pass: count frequencies
            var current = head;
            while (current != null)
            {
                if( frequencyMap.ContainsKey(current.val) )
                { 
                    frequencyMap[current.val]++;
                }
                else
                {
                    frequencyMap[current.val] = 1;
                }
                current = current.next;
            }

            // Second Pass: create new list maintaining order of te occurrence
            var dummy = new ListNode();


            return dummy.next;
        }
    }
}
