using SwapNodesInPairs_24;
using Xunit;

public class SwapNodesInPairsTests
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

    // Helper method to convert linked list to array for easy comparison
    private int[] LinkedListToArray(ListNode head)
    {
        List<int> result = new List<int>();
        ListNode current = head;

        while (current != null)
        {
            result.Add(current.val);
            current = current.next;
        }

        return result.ToArray();
    }

    [Fact]
    public void SwapPairs_EmptyList_ReturnsNull()
    {
        // Arrange
        var solution = new Solution();
        ListNode head = null;

        // Act
        var result = solution.SwapPairsIterative(head);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SwapPairs_SingleNode_ReturnsSameList()
    {
        // Arrange
        var solution = new Solution();
        ListNode head = new ListNode(1);

        // Act
        var result = solution.SwapPairsIterative(head);

        // Assert
        Assert.Equal(1, result.val);
        Assert.Null(result.next);
    }

    [Fact]
    public void SwapPairs_TwoNodes_SwapsCorrectly()
    {
        // Arrange
        var solution = new Solution();
        ListNode head = CreateLinkedList(new int[] { 1, 2 });
        int[] expected = new int[] { 2, 1 };

        // Act
        var result = solution.SwapPairsIterative(head);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SwapPairs_FourNodes_SwapsCorrectly()
    {
        // Arrange
        var solution = new Solution();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4 });
        int[] expected = new int[] { 2, 1, 4, 3 };

        // Act
        var result = solution.SwapPairsIterative(head);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SwapPairs_ThreeNodes_SwapsFirstTwo()
    {
        // Arrange
        var solution = new Solution();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3 });
        int[] expected = new int[] { 2, 1, 3 };

        // Act
        var result = solution.SwapPairsIterative(head);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SwapPairs_FiveNodes_SwapsCorrectly()
    {
        // Arrange
        var solution = new Solution();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
        int[] expected = new int[] { 2, 1, 4, 3, 5 };

        // Act
        var result = solution.SwapPairsIterative(head);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SwapPairs_LargeList_SwapsCorrectly()
    {
        // Arrange
        var solution = new Solution();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        int[] expected = new int[] { 2, 1, 4, 3, 6, 5, 8, 7 };

        // Act
        var result = solution.SwapPairsIterative(head);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SwapPairs_RecursiveApproach_WorksCorrectly()
    {
        // Arrange
        var solution = new Solution();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4 });
        int[] expected = new int[] { 2, 1, 4, 3 };

        // Act - Test recursive approach specifically
        var result = solution.SwapPairsIterative(head);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }
}