using ReverseLinkedList_206;

namespace ReverseLinkedList_206_Test
{
    public class TestReverseLinkedList
    {
        private readonly Solution _solution = new Solution();

        [Fact]
        public void ShouldReverseSimpleList()
        {
            // Arrange
            var list = CreateList(new[] { 1, 2, 3 });
            var expected = CreateList(new[] { 3, 2, 1 });

            // Act
            var reversed = _solution.ReverseList(list);

            // Assert
            Assert.Equal(expected.ToString(), reversed.ToString());
        }

        [Fact]
        public void ShouldHandleEmptyList()
        {
            // Arrange
            var emptyList = null as ListNode;

            // Act
            var result = _solution.ReverseList(emptyList);

            // Assert
            Assert.Null(result); // We expect empty list
        }

        [Fact]
        public void ShouldHandleSingleElementList()
        {
            // Arrange
            var singleElementList = new ListNode(1);

            // Act
            var result = _solution.ReverseList(singleElementList);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.val);
            Assert.Null(result.next);
        }

        private ListNode CreateList(int[] values)
        {
            ListNode dummy = new ListNode(-1);
            ListNode tail = dummy;
            foreach (var value in values)
            {
                tail.next = new ListNode(value);
                tail = tail.next;
            }
            return dummy.next;
        }
    }
}