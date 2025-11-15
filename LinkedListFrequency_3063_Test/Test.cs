using LinkedListFrequency_3063;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class LinkedListFrequencyTests
{
    private readonly Solution _solution;

    public LinkedListFrequencyTests()
    {
        _solution = new Solution();
    }

    // Test helper method to compare two linked lists
    private bool AreLinkedListsEqual(ListNode list1, ListNode list2)
    {
        while (list1 != null && list2 != null)
        {
            if (list1.val != list2.val) return false;
            list1 = list1.next;
            list2 = list2.next;
        }
        return list1 == null && list2 == null;
    }

    [Fact]
    public void Frequency_EmptyList_ReturnsNull()
    {
        // Arrange
        ListNode head = null;

        // Act
        ListNode result = _solution.FrequencyMostEfficient(head);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Frequency_SingleElement_ReturnsSingleFrequency()
    {
        // Arrange: [5] -> [1]
        ListNode head = CreateLinkedList(new int[] { 5 });
        ListNode expected = CreateLinkedList(new int[] { 1 });

        // Act
        ListNode result = _solution.FrequencyMostEfficient(head);

        // Assert
        Assert.True(AreLinkedListsEqual(expected, result));
    }

    [Fact]
    public void Frequency_AllSameElements_ReturnsSingleFrequency()
    {
        // Arrange: [2,2,2,2] -> [4]
        ListNode head = CreateLinkedList(new int[] { 2, 2, 2, 2 });
        ListNode expected = CreateLinkedList(new int[] { 4 });

        // Act
        ListNode result = _solution.FrequencyMostEfficient(head);

        // Assert
        Assert.True(AreLinkedListsEqual(expected, result));
    }

    [Fact]
    public void Frequency_AllDistinctElements_ReturnsAllOnes()
    {
        // Arrange: [1,2,3,4] -> [1,1,1,1]
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4 });
        ListNode expected = CreateLinkedList(new int[] { 1, 1, 1, 1 });

        // Act
        ListNode result = _solution.FrequencyMostEfficient(head);

        // Assert
        Assert.True(AreLinkedListsEqual(expected, result));
    }

    [Fact]
    public void Frequency_MixedElements_MaintainsFirstOccurrenceOrder()
    {
        // Arrange: [1,2,1,3,2,1] -> [3,2,1]
        ListNode head = CreateLinkedList(new int[] { 1, 2, 1, 3, 2, 1 });
        ListNode expected = CreateLinkedList(new int[] { 3, 2, 1 });

        // Act
        ListNode result = _solution.FrequencyMostEfficient(head);

        // Assert
        Assert.True(AreLinkedListsEqual(expected, result));
    }

    [Fact]
    public void Frequency_DuplicatesNotConsecutive_CorrectFrequencies()
    {
        // Arrange: [1,3,2,1,3,1] -> [3,2,1]
        ListNode head = CreateLinkedList(new int[] { 1, 3, 2, 1, 3, 1 });
        ListNode expected = CreateLinkedList(new int[] { 3, 2, 1 });

        // Act
        ListNode result = _solution.FrequencyMostEfficient(head);

        // Assert
        Assert.True(AreLinkedListsEqual(expected, result));
    }

    [Fact]
    public void Frequency_NegativeNumbers_WorksCorrectly()
    {
        // Arrange: [-1,2,-1,0,-1,2] -> [3,2,1]
        ListNode head = CreateLinkedList(new int[] { -1, 2, -1, 0, -1, 2 });
        ListNode expected = CreateLinkedList(new int[] { 3, 2, 1 });

        // Act
        ListNode result = _solution.FrequencyMostEfficient(head);

        // Assert
        Assert.True(AreLinkedListsEqual(expected, result));
    }

    [Fact]
    public void Frequency_LargeInput_PerformanceTest()
    {
        // Arrange: Create a large list with repeated patterns
        List<int> largeInput = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            largeInput.Add(i % 10); // Pattern: 0,1,2,...,9 repeated
        }

        ListNode head = CreateLinkedList(largeInput.ToArray());
        // Expected: each number 0-9 appears 100 times
        ListNode expected = CreateLinkedList(new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 });

        // Act & Assert - This should complete quickly with O(n) approach
        ListNode result = _solution.FrequencyMostEfficient(head);
        Assert.True(AreLinkedListsEqual(expected, result));
    }

    [Fact]
    public void Frequency_ExampleFromProblem_CorrectOutput()
    {
        // Arrange: Example from problem statement
        ListNode head = CreateLinkedList(new int[] { 1, 2, 1, 3, 2, 1 });
        ListNode expected = CreateLinkedList(new int[] { 3, 2, 1 });

        // Act
        ListNode result = _solution.FrequencyMostEfficient(head);

        // Assert
        Assert.True(AreLinkedListsEqual(expected, result));
        Assert.Equal("3 -> 2 -> 1", DisplayLinkedList(result));
    }

    // Helper method to convert linked list to array for testing
    public int[] LinkedListToArray(ListNode head)
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

    // Helper method to display linked list as string
    public string DisplayLinkedList(ListNode head)
    {
        StringBuilder sb = new StringBuilder();
        ListNode current = head;

        while (current != null)
        {
            sb.Append(current.val);
            if (current.next != null)
            {
                sb.Append(" -> ");
            }
            current = current.next;
        }

        return sb.ToString();
    }

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
}