using WinnerOfTheLinkedListGame_3062;
namespace WinnerOfTheLinkedListGame_3062_Test
{
    public class LinkedListGameTests
    {
        // Helper method to create linked list from array
        private ListNode CreateLinkedList(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            return head;
        }

        [Fact]
        public void TestPlayer1Wins_EvenNumberOfNodes()
        {
            // Arrange: Player1: 5+3=8, Player2: 2+1=3
            int[] values = { 5, 2, 3, 1 }; // Even number of nodes
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(1, result); // Player 1 should win
        }

        [Fact]
        public void TestPlayer2Wins_EvenNumberOfNodes()
        {
            // Arrange: Player1: 1+2=3, Player2: 5+4=9
            int[] values = { 1, 5, 2, 4 };
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(2, result); // Player 2 should win
        }

        [Fact]
        public void TestTieGame_EqualScores()
        {
            // Arrange: Player1: 1+4=5, Player2: 2+3=5
            int[] values = { 1, 2, 4, 3 };
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(0, result); // Should be a tie
        }

        [Fact]
        public void TestTwoNodes_Player1Wins()
        {
            // Arrange: Player1: 10, Player2: 5
            int[] values = { 10, 5 };
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestTwoNodes_Player2Wins()
        {
            // Arrange: Player1: 5, Player2: 10
            int[] values = { 5, 10 };
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestSixNodes_ComplexScenario()
        {
            // Arrange: Player1: 1+3+5=9, Player2: 2+4+6=12
            int[] values = { 1, 2, 3, 4, 5, 6 };
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(2, result); // Player 2 should win
        }

        [Fact]
        public void TestAllZeros_Tie()
        {
            // Arrange: All zeros, both players get 0
            int[] values = { 0, 0, 0, 0, 0, 0 };
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(0, result); // Should be a tie
        }

        [Fact]
        public void TestNegativeNumbers_Player1Wins()
        {
            // Arrange: Player1: (-1)+(-2)=-3, Player2: (-5)+(-10)=-15
            int[] values = { -1, -5, -2, -10 };
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(1, result); // -3 > -15, so Player 1 wins
        }

        [Fact]
        public void TestLargeNumbers_Player2Wins()
        {
            // Arrange: Player1: 100+1=101, Player2: 1000+10=1010
            int[] values = { 100, 1000, 1, 10 };
            ListNode head = CreateLinkedList(values);
            Solution solution = new Solution();

            // Act
            int result = solution.GameResultLinear(head);

            // Assert
            Assert.Equal(2, result);
        }
    }
}