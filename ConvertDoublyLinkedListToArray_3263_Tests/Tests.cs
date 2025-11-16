using ConvertDoublyLinkedListToArrayI_3263;
using System.Linq;
using Xunit;

public class DoublyLinkedListConverterTests
{
    private readonly DoublyLinkedListConverter _converter;

    public DoublyLinkedListConverterTests()
    {
        _converter = new DoublyLinkedListConverter();
    }

    [Fact]
    // Test case: Empty list should return empty array
    public void ConvertToArray_EmptyList_ReturnsEmptyArray()
    {
        // Arrange
        DoublyLinkedListNode head = null;

        // Act
        int[] result = _converter.ConvertToArray(head);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    // Test case: Single node list should return single element array
    public void ConvertToArray_SingleNode_ReturnsSingleElementArray()
    {
        // Arrange
        int[] expected = { 5 };
        DoublyLinkedListNode head = DoublyLinkedListConverter.CreateDoublyLinkedList(expected);

        // Act
        int[] result = _converter.ConvertToArray(head);

        // Assert
        Assert.Equal(expected, result);
        Assert.True(DoublyLinkedListConverter.VerifyDoublyLinkedList(head, expected));
    }

    [Fact]
    // Test case: Multiple nodes with positive numbers
    public void ConvertToArray_MultipleNodesPositive_ReturnsCorrectArray()
    {
        // Arrange
        int[] expected = { 1, 2, 3, 4, 5 };
        DoublyLinkedListNode head = DoublyLinkedListConverter.CreateDoublyLinkedList(expected);

        // Act
        int[] result = _converter.ConvertToArray(head);

        // Assert
        Assert.Equal(expected, result);
        Assert.True(DoublyLinkedListConverter.VerifyDoublyLinkedList(head, expected));
    }

    [Fact]
    // Test case: Multiple nodes with negative numbers
    public void ConvertToArray_MultipleNodesNegative_ReturnsCorrectArray()
    {
        // Arrange
        int[] expected = { -1, -2, -3, -4, -5 };
        DoublyLinkedListNode head = DoublyLinkedListConverter.CreateDoublyLinkedList(expected);

        // Act
        int[] result = _converter.ConvertToArray(head);

        // Assert
        Assert.Equal(expected, result);
        Assert.True(DoublyLinkedListConverter.VerifyDoublyLinkedList(head, expected));
    }

    [Fact]
    // Test case: Mixed positive and negative numbers
    public void ConvertToArray_MixedNumbers_ReturnsCorrectArray()
    {
        // Arrange
        int[] expected = { -3, 0, 5, -2, 10 };
        DoublyLinkedListNode head = DoublyLinkedListConverter.CreateDoublyLinkedList(expected);

        // Act
        int[] result = _converter.ConvertToArray(head);

        // Assert
        Assert.Equal(expected, result);
        Assert.True(DoublyLinkedListConverter.VerifyDoublyLinkedList(head, expected));
    }

    [Fact]
    // Test case: Large list to test performance and correctness
    public void ConvertToArray_LargeList_ReturnsCorrectArray()
    {
        // Arrange
        int[] expected = Enumerable.Range(1, 1000).ToArray();
        DoublyLinkedListNode head = DoublyLinkedListConverter.CreateDoublyLinkedList(expected);

        // Act
        int[] result = _converter.ConvertToArray(head);

        // Assert
        Assert.Equal(expected, result);
        Assert.True(DoublyLinkedListConverter.VerifyDoublyLinkedList(head, expected));
    }

    [Fact]
    // Test case: List with duplicate values
    public void ConvertToArray_DuplicateValues_ReturnsCorrectArray()
    {
        // Arrange
        int[] expected = { 1, 1, 2, 2, 3, 3 };
        DoublyLinkedListNode head = DoublyLinkedListConverter.CreateDoublyLinkedList(expected);

        // Act
        int[] result = _converter.ConvertToArray(head);

        // Assert
        Assert.Equal(expected, result);
        Assert.True(DoublyLinkedListConverter.VerifyDoublyLinkedList(head, expected));
    }

    [Fact]
    // Test case: Verify that the original list structure remains unchanged
    public void ConvertToArray_OriginalListUnchanged_ReturnsCorrectArray()
    {
        // Arrange
        int[] originalValues = { 1, 2, 3, 4, 5 };
        DoublyLinkedListNode head = DoublyLinkedListConverter.CreateDoublyLinkedList(originalValues);

        // Act
        int[] result = _converter.ConvertToArray(head);

        // Assert - Verify the result is correct
        Assert.Equal(originalValues, result);

        // Assert - Verify the original list structure is preserved
        Assert.True(DoublyLinkedListConverter.VerifyDoublyLinkedList(head, originalValues));

        // Additional verification: manually traverse and check structure
        DoublyLinkedListNode current = head;
        Assert.Equal(1, current.val);
        Assert.Null(current.prev); // Head should have null prev

        current = current.next;
        Assert.Equal(2, current.val);
        Assert.Equal(1, current.prev.val); // Second node should point back to first

        current = current.next;
        Assert.Equal(3, current.val);
        Assert.Equal(2, current.prev.val); // Third node should point back to second
    }
}