using MiddleOfTheLinkedList_876;

namespace MiddleOfTheLinkedList_876_Test
{
    public class MiddleOfTheLinkedListTests
    {
        private readonly Solution _solution = new Solution();

        [Fact]
        public void TestSingleElement()
        {
            // Arrange
            var input = new ListNode(1);
            var expected = input;

            // Act
            var result = _solution.MiddleNodeOnePass(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestEvenNumberOfElements()
        {
            // Arrange
            var input = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            var expected = new ListNode(3, new ListNode(4));

            // Act
            var result = _solution.MiddleNodeOnePass(input);

            // Assert
            Assert.Equal(expected.val, result.val);
            Assert.Equal(expected.next.val, result.next.val);
        }

        [Fact]
        public void TestOddNumberOfElements()
        {
            // Arrange
            var input = new ListNode(1, new ListNode(2, new ListNode(3)));
            var expected = new ListNode(2);

            // Act
            var result = _solution.MiddleNodeOnePass(input);

            // Assert
            Assert.Equal(expected.val, result.val);
        }

        [Fact]
        public void TestNullHead()
        {
            // Arrange
            var input = null as ListNode;
            var expected = null as ListNode;

            // Act
            var result = _solution.MiddleNodeOnePass(input);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void TestLargeList()
        {
            // Arrange
            var input = CreateLongList(100_000);
            var expectedVal = 50_001;

            // Act
            var result = _solution.MiddleNodeOnePass(input);

            // Assert
            Assert.Equal(expectedVal, result.val);
        }

        private static ListNode CreateLongList(int size)
        {
            ListNode dummy = new ListNode(-1);
            ListNode current = dummy;
            for (int i = 1; i <= size; i++)
            {
                current.next = new ListNode(i);
                current = current.next;
            }
            return dummy.next;
        }
    }
}