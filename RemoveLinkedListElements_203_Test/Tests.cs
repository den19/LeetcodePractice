using RemoveLinkedListElements_203;
using Xunit;

namespace RemoveLinkedListElements_203_Test
{
    public class RemoveElementsTests
    {
        private readonly Solution _solution = new Solution(); // Solution instance

        // Array to linked list
        static ListNode ArrayToListNode(int[] arr)
        {
            if (arr.Length == 0) return null;

            var dummyHead = new ListNode();
            var curr = dummyHead;

            foreach (var num in arr)
            {
                curr.next = new ListNode(num);
                curr = curr.next;
            }

            return dummyHead.next;
        }

        // Method for comparing two lists
        bool AreListsEqual(ListNode l1, ListNode l2)
        {
            while (l1 != null || l2 != null)
            {
                if ((l1 == null && l2 != null) || (l1 != null && l2 == null)) return false;
                if (l1.val != l2.val) return false;
                l1 = l1.next;
                l2 = l2.next;
            }
            return true;
        }

        [Fact]
        public void TestEmptyList()
        {
            Assert.True(AreListsEqual(_solution.RemoveElements(null, 1), null));
        }

        [Fact]
        public void TestSingleElementNotRemoved()
        {
            var input = ArrayToListNode(new[] { 1 });
            var expected = ArrayToListNode(new[] { 1 });
            Assert.True(AreListsEqual(_solution.RemoveElements(input, 2), expected));
        }

        [Fact]
        public void TestSingleElementRemoved()
        {
            var input = ArrayToListNode(new[] { 1 });
            var expected = ArrayToListNode(new int[] { });
            Assert.True(AreListsEqual(_solution.RemoveElements(input, 1), expected));
        }

        [Fact]
        public void TestMultipleElementsRemoved()
        {
            var input = ArrayToListNode(new[] { 1, 2, 6, 3, 4, 5, 6 });
            var expected = ArrayToListNode(new[] { 1, 2, 3, 4, 5 });
            Assert.True(AreListsEqual(_solution.RemoveElements(input, 6), expected));
        }

        [Fact]
        public void TestAllElementsRemoved()
        {
            var input = ArrayToListNode(new[] { 7, 7, 7, 7 });
            var expected = ArrayToListNode(new int[] { });
            Assert.True(AreListsEqual(_solution.RemoveElements(input, 7), expected));
        }

        [Fact]
        public void TestNoElementsRemoved()
        {
            var input = ArrayToListNode(new[] { 1, 2, 3, 4, 5 });
            var expected = ArrayToListNode(new[] { 1, 2, 3, 4, 5 });
            Assert.True(AreListsEqual(_solution.RemoveElements(input, 6), expected));
        }
    }
}