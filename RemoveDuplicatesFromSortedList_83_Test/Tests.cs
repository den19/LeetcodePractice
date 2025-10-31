using RemoveDuplicatesFromSortedList_83;

namespace RemoveDuplicatesFromSortedList_83_Test
{
    public class Tests
    {
        public class RemoveDuplicatesTests
        {

            private static void AssertListEqual(ListNode expected, ListNode actual)
            {
                while (expected != null && actual != null)
                {
                    Assert.Equal(expected.val, actual.val);
                    expected = expected.next;
                    actual = actual.next;
                }
                // Both list must end simulteniously
                Assert.Null(expected);
                Assert.Null(actual);
            }

            [Fact]
            public void Test_RemoveDuplicatesFromSortedList()
            {
                // Arrange
                var input = new ListNode(1, new ListNode(1, new ListNode(2)));
                var solution = new Solution();

                // Act
                var result = solution.DeleteDuplicates(input);

                // Assert
                AssertListEqual(new ListNode(1, new ListNode(2)), result);
            }

            [Fact]
            public void Test_RemoveAllDuplicates()
            {
                // Arrange
                var input = new ListNode(1, new ListNode(1));
                var solution = new Solution();

                // Act
                var result = solution.DeleteDuplicates(input);

                // Assert
                AssertListEqual(new ListNode(1), result);
            }

            [Fact]
            public void Test_EmptyList()
            {
                // Arrange
                ListNode input = null;
                var solution = new Solution();

                // Act
                var result = solution.DeleteDuplicates(input);

                // Assert
                Assert.Null(result);
            }
        }
    }
}