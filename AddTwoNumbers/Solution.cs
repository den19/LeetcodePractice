namespace AddTwoNumbers
{
    public class Solution
    {
        /// <summary>
        /// Linear Brute Force Solution
        /// Time O(n + m)
        /// Memory O(max(n, m))
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbersBruteForce(ListNode l1, ListNode l2)
        {
            // Convert both linked lists to numbers
            long num1 = LinkedListToNumber(l1);
            long num2 = LinkedListToNumber(l2);

            // Add the numbers
            long sum = num1 + num2;

            // Convert sum back to linked list
            return NumberToLinkedList(sum);
        }

        private long LinkedListToNumber(ListNode head)
        {
            long num = 0;
            long multiplier = 1;
            ListNode current = head;

            while (current != null)
            {
                num += current.val * multiplier;
                multiplier *= 10;
                current = current.next;
            }

            return num;
        }

        private ListNode NumberToLinkedList(long num)
        {
            if (num == 0)
            {
                return new ListNode(0);
            }

            ListNode dummy = new ListNode(0);
            ListNode current = dummy;

            while (num > 0)
            {
                int digit = (int)(num % 10);
                current.next = new ListNode(digit);
                current = current.next;
                num /= 10;
            }

            return dummy.next;
        }

        /// <summary>
        /// Most Efficient - Digit By Digit Addition
        /// Time O(max(n ,m))
        /// Memory O(max(n, m))
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);

            // Dummy node to simplify logic
            ListNode current = dummy;
            int carry = 0;

            // Process both lists until both are exhausted and no carry remains
            while (l1 != null || l2 != null || carry != 0)
            {
                // Start with carry from previous iteration
                int sum = carry;

                // Add current digit from l1 if available
                if(l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                // Add current digit from l2 if available
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                // Calculate new digit and carry
                carry = sum / 10;
                int digit = sum % 10;

                // Create new node for the digit
                current.next = new ListNode(digit);
                current = current.next;

            }

            // Skip dummy node
            return dummy.next;
        }

        // Helper method to convert linked list to array for testing
        public static int[] LinkedListToArray(ListNode head)
        {
            List<int> result = new List<int>();
            ListNode current = head;

            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }

            return result.ToArray();
        }

        // Helper method to create linked list from array
        public static ListNode CreateLinkedList(int[] values)
        {
            if (values == null || values.Length == 0) return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            return head;
        }



    }
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



}