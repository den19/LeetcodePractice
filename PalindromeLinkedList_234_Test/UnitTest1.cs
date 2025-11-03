using PalindromeLinkedList_234;

namespace PalindromeLinkedList_234_Test
{
    public class SolutionTests
    {
        private readonly Solution _solution = new Solution();

        private static ListNode BuildLinkedList(params int[] values)
        {
            if (values.Length == 0)
            {
                return null;
            }

            ListNode dummy = new ListNode();
            ListNode current = dummy;
            foreach (var value in values)
            {
                current.next = new ListNode(value);
                current = current.next;
            }
            return dummy.next;
        }

        [Fact]
        public void TestIsPalindrome_OddLength()
        {
            var input = BuildLinkedList(1, 2, 3, 2, 1);
            Assert.True(IsPalindrome(input));
        }

        [Fact]
        public void TestIsPalindrome_EvenLength()
        {
            var input = BuildLinkedList(1, 2, 2, 1);
            Assert.True(IsPalindrome(input));
        }

        [Fact]
        public void TestNotPalindrome()
        {
            var input = BuildLinkedList(1, 2, 3, 4, 5);
            Assert.False(IsPalindrome(input));
        }

        [Fact]
        public void TestSingleElement()
        {
            var input = BuildLinkedList(1);
            Assert.True(IsPalindrome(input));
        }

        [Fact]
        public void TestEmptyList()
        {
            var input = BuildLinkedList(); // empty list
            Assert.True(IsPalindrome(input)); // empty lists are palindromes too
        }

        [Fact]
        public void TestAllSameElements()
        {
            var input = BuildLinkedList(1, 1, 1, 1, 1);
            Assert.True(IsPalindrome(input));
        }

        [Fact]
        public void TestOddLengthWithDifferentMiddle()
        {
            var input = BuildLinkedList(1, 2, 3, 4, 1);
            Assert.False(IsPalindrome(input));
        }

        [Fact]
        public void TestEdgeCase_OnlyTwoNodes()
        {
            var input = BuildLinkedList(1, 2);
            Assert.False(IsPalindrome(input));
        }

        // Main method to test for palindrome
        private bool IsPalindrome(ListNode head) => _solution.IsPalindromeOptimized(head);
    }
}