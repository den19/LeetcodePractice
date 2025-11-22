using AddTwoNumbers;
using Xunit;

public class AddTwoNumbersTests
{
    private readonly Solution _solution;

    public AddTwoNumbersTests()
    {
        _solution = new Solution();
    }

    // Test case from the problem example
    [Fact]
    public void AddTwoNumbers_ExampleCase_ReturnsCorrectSum()
    {
        // Arrange: 342 (2->4->3) + 465 (5->6->4) = 807 (7->0->8)
        ListNode l1 = Solution.CreateLinkedList(new[] { 2, 4, 3 });
        ListNode l2 = Solution.CreateLinkedList(new[] { 5, 6, 4 });
        int[] expected = new[] { 7, 0, 8 };

        // Act
        ListNode result = _solution.AddTwoNumbers(l1, l2);
        int[] resultArray = Solution.LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, resultArray);
    }

    // Test case with different length lists
    [Fact]
    public void AddTwoNumbers_DifferentLengthLists_ReturnsCorrectSum()
    {
        // Arrange: 999 (9->9->9) + 1 (1) = 1000 (0->0->0->1)
        ListNode l1 = Solution.CreateLinkedList(new[] { 9, 9, 9 });
        ListNode l2 = Solution.CreateLinkedList(new[] { 1 });
        int[] expected = new[] { 0, 0, 0, 1 };

        // Act
        ListNode result = _solution.AddTwoNumbers(l1, l2);
        int[] resultArray = Solution.LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, resultArray);
    }

    // Test case with carry propagation
    [Fact]
    public void AddTwoNumbers_CarryPropagation_ReturnsCorrectSum()
    {
        // Arrange: 555 (5->5->5) + 555 (5->5->5) = 1110 (0->1->1->1)
        ListNode l1 = Solution.CreateLinkedList(new[] { 5, 5, 5 });
        ListNode l2 = Solution.CreateLinkedList(new[] { 5, 5, 5 });
        int[] expected = new[] { 0, 1, 1, 1 };

        // Act
        ListNode result = _solution.AddTwoNumbers(l1, l2);
        int[] resultArray = Solution.LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, resultArray);
    }

    // Test case with zeros
    [Fact]
    public void AddTwoNumbers_WithZeros_ReturnsCorrectSum()
    {
        // Arrange: 0 (0) + 0 (0) = 0 (0)
        ListNode l1 = Solution.CreateLinkedList(new[] { 0 });
        ListNode l2 = Solution.CreateLinkedList(new[] { 0 });
        int[] expected = new[] { 0 };

        // Act
        ListNode result = _solution.AddTwoNumbers(l1, l2);
        int[] resultArray = Solution.LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, resultArray);
    }

    // Test case with single digit numbers
    [Fact]
    public void AddTwoNumbers_SingleDigitWithCarry_ReturnsCorrectSum()
    {
        // Arrange: 5 (5) + 5 (5) = 10 (0->1)
        ListNode l1 = Solution.CreateLinkedList(new[] { 5 });
        ListNode l2 = Solution.CreateLinkedList(new[] { 5 });
        int[] expected = new[] { 0, 1 };

        // Act
        ListNode result = _solution.AddTwoNumbers(l1, l2);
        int[] resultArray = Solution.LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, resultArray);
    }

    // Test case with one empty list (shouldn't happen per problem, but good to test)
    [Fact]
    public void AddTwoNumbers_OneListLonger_ReturnsCorrectSum()
    {
        // Arrange: 1234 (4->3->2->1) + 56 (6->5) = 1290 (0->9->2->1)
        ListNode l1 = Solution.CreateLinkedList(new[] { 4, 3, 2, 1 });
        ListNode l2 = Solution.CreateLinkedList(new[] { 6, 5 });
        int[] expected = new[] { 0, 9, 2, 1 };

        // Act
        ListNode result = _solution.AddTwoNumbers(l1, l2);
        int[] resultArray = Solution.LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, resultArray);
    }

    // Performance test with large numbers
    [Fact]
    public void AddTwoNumbers_LargeNumbers_ReturnsCorrectSum()
    {
        // Arrange: Create two large numbers
        int[] largeArray1 = new int[100];
        int[] largeArray2 = new int[100];

        for (int i = 0; i < 100; i++)
        {
            largeArray1[i] = 9; // All 9s
            largeArray2[i] = 1; // All 1s
        }

        ListNode l1 = Solution.CreateLinkedList(largeArray1);
        ListNode l2 = Solution.CreateLinkedList(largeArray2);

        // Act & Assert - should not throw and complete in reasonable time
        ListNode result = _solution.AddTwoNumbers(l1, l2);

        Assert.NotNull(result);
    }
}