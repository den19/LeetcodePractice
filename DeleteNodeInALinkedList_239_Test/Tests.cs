using DeleteNodeInALinkedList_239;

namespace DeleteNodeInALinkedList_239_Test
{
    public class DeleteNodeTests
    {
        private readonly Solution _solution = new Solution();

        private static ListNode CreateList(params int[] values)
        {
            if (values.Length == 0) return null;

            var head = new ListNode(values[0]);
            var current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            return head;
        }

        private static string ToString(ListNode node)
        {
            var result = "";
            while (node != null)
            {
                result += $"{node.val}, ";
                node = node.next;
            }
            return result.TrimEnd(',', ' ');
        }

        [Fact]
        public void Test_DeleteMiddleNode()
        {
            // Arrange
            var head = CreateList(1, 2, 3, 4);
            var targetNode = head.next; // Удаляем второй элемент

            // Act
            _solution.DeleteNode(ref targetNode); // Вызываем метод удаления

            // Assert
            Assert.Equal("1, 3, 4", ToString(head));
        }

        [Fact]
        public void Test_DeleteFirstNode()
        {
            // Arrange
            var head = CreateList(1, 2, 3);
            var targetNode = head; // Удаляем первый элемент

            // Act
            _solution.DeleteNode(ref targetNode); // Вызываем метод удаления

            // Assert
            Assert.Equal("2, 3", ToString(head));
        }

        [Fact]
        public void Test_SingleElementList()
        {
            // Arrange
            var head = CreateList(1);
            var targetNode = head; // Единственный узел

            // Act
            _solution.DeleteNode(ref head); // Вызываем метод удаления

            // Assert
            Assert.Null(head); // После удаления список пуст
        }

        [Fact]
        public void Test_EmptyList()
        {
            // Arrange
            var head = CreateList();
            var targetNode = head; // Список пустой

            // Act & Assert
            Assert.ThrowsAny<Exception>(() => _solution.DeleteNode(ref targetNode)); // Ожидаем исключение, так как удалять нечего
        }
    }
}