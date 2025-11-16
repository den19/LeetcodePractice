namespace ConvertDoublyLinkedListToArrayI_3263
{
    public class DoublyLinkedListConverter
    {
        // Most efficient approach - single pass
        public int[] ConvertToArray(DoublyLinkedListNode head)
        {
            if (head == null) return new int[0];

            List<int> resultList = new List<int>();
            DoublyLinkedListNode current = head;

            while (current != null)
            {
                resultList.Add(current.val);
                current = current.next;
            }

            return resultList.ToArray();
        }

        // Helper method to create a doubly linked list from array (for testing)
        public static DoublyLinkedListNode CreateDoublyLinkedList(int[] values)
        {
            if (values == null || values.Length == 0) return null;

            DoublyLinkedListNode head = new DoublyLinkedListNode(values[0]);
            DoublyLinkedListNode current = head;
            DoublyLinkedListNode previous = null;

            for (int i = 1; i < values.Length; i++)
            {
                current.prev = previous;
                current.next = new DoublyLinkedListNode(values[i]);
                previous = current;
                current = current.next;
            }

            current.prev = previous;
            return head;
        }

        // Helper method to verify doubly linked list structure (for testing)
        public static bool VerifyDoublyLinkedList(DoublyLinkedListNode head, int[] expectedValues)
        {
            if (head == null) return expectedValues == null || expectedValues.Length == 0;

            // Forward traversal
            DoublyLinkedListNode current = head;
            int index = 0;

            while (current != null)
            {
                if (index >= expectedValues.Length || current.val != expectedValues[index])
                {
                    return false;
                }

                // Verify next pointer consistency
                if (current.next != null && current.next.prev != current)
                {
                    return false;
                }

                current = current.next;
                index++;
            }

            return index == expectedValues.Length;
        }
    }
    public class DoublyLinkedListNode
    {
        public int val;
        public DoublyLinkedListNode prev;
        public DoublyLinkedListNode next;

        public DoublyLinkedListNode(int val = 0,
                                   DoublyLinkedListNode prev = null,
                                   DoublyLinkedListNode next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }

    public class Solution
    {
        /// <summary>
        /// Approach 1: Linear (Brute Force) - Two Pass
        /// Time Complexity: O(2n) = O(n) - Two passes through the list
        /// Space Complexity: O(n) - For the result array (excluding input)
        /// Pros: Simple, easy to understand
        /// Cons: Two passes through the list
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] ConvertToArrayBruteForceTwoPass(DoublyLinkedListNode head)
        {
            if (head == null) return new int[0];

            // First pass: count the number of nodes
            int count = 0;
            DoublyLinkedListNode current = head;
            while (current != null)
            {
                count++;
                current = current.next;
            }

            // Second pass: populate the array
            int[] result = new int[count];
            current = head;
            for (int i = 0; i < count; i++)
            {
                result[i] = current.val;
                current = current.next;
            }

            return result;
        }

        /// <summary>
        /// Approach 2: Most Efficient - Single Pass with List
        /// Time Complexity: O(n) - Single pass through the list
        /// Space Complexity: O(n) - For the List and resulting array
        /// Pros: Only one pass, efficient
        /// Cons: Uses List internally which may have some overhead
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] ConvertToArrayMostEfficientSinglePassWithList(DoublyLinkedListNode head)
        {
            if (head == null) return new int[0];
            List<int> result = new List<int>();
            DoublyLinkedListNode current = head;
            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }
            return result.ToArray();
        }
    }


}
