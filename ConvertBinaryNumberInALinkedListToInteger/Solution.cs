namespace ConvertBinaryNumberInALinkedListToInteger
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
        /// Decision though string of binary values
        /// O(n)
        /// O(n), because length of string equals length of linked list
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int GetDecimalValueLinear(ListNode head)
        {
            // Create empty string for storing binary values
            string binaryString = string.Empty;

            while (head != null)
            {
                // Add current binary value to the end of the string
                binaryString += head.val.ToString();

                head = head.next;
            }

            // Convert binary string to integer
            return Convert.ToInt32(binaryString, 2);
        }

        /// <summary>
        /// Effective Memory solution O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int GetDecimalValueEffective(ListNode head)
        {
            int result = 0;

            while (head != null)
            {
                // Multiply previous result by 2 (shift left)
                // and add new bit
                result = (result << 1) | head.val;

                head = head.next;
            }

            return result;
        }
    }
}
