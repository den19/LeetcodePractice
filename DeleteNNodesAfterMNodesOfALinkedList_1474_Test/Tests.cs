using DeleteNNodesAfterMNodesOfALinkedList_1474;

namespace DeleteNNodesAfterMNodesOfALinkedList_1474_Test
{
    public class LinkedListTests
    {
        [Fact]
        public void TestDeleteNodes_ExampleFromLeetcode()
        {
            // Подготовка теста
            var head = CreateList(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            var expected = CreateList(new[] { 1, 2, 6, 7 });
            var actual = new Solution().DeleteNodesLinear(head, 2, 3);

            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact]
        public void TestDeleteNodes_EmptyList()
        {
            var head = CreateList(Array.Empty<int>());
            var expected = CreateList(Array.Empty<int>());
            var actual = new Solution().DeleteNodesLinear(head, 2, 3);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDeleteNodes_OneElementList()
        {
            var head = CreateList(new[] { 1 });
            var expected = CreateList(new[] { 1 });
            var actual = new Solution().DeleteNodesLinear(head, 2, 3);

            Assert.Equal(expected.ToString(), actual.ToString());
        }

        private static ListNode CreateList(IEnumerable<int> values)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;
            foreach (var value in values)
            {
                current.next = new ListNode(value);
                current = current.next;
            }
            return dummy.next;
        }
    }
}