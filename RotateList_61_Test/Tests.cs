using RotateList_61;
using Xunit;

public class RotateListTests
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

    // Helper method to convert linked list to array for comparison
    private int[] LinkedListToArray(ListNode head)
    {
        if (head == null) return new int[0];

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
    // Test case: Rotate list [1,2,3,4,5] by 2 positions
    public void RotateRight_StandardCase_ReturnsCorrectRotation()
    {
        // Arrange
        var solution = new RotateListOptimal();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
        int k = 2;
        int[] expected = new int[] { 4, 5, 1, 2, 3 };

        // Act
        ListNode result = solution.RotateRight(head, k);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    // Test case: Rotate list [0,1,2] by 4 positions (k > length)
    public void RotateRight_KGreaterThanLength_ReturnsCorrectRotation()
    {
        // Arrange
        var solution = new RotateListOptimal();
        ListNode head = CreateLinkedList(new int[] { 0, 1, 2 });
        int k = 4;
        int[] expected = new int[] { 2, 0, 1 }; // Equivalent to rotating by 1 (4 % 3 = 1)

        // Act
        ListNode result = solution.RotateRight(head, k);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    // Test case: Empty list should return null
    public void RotateRight_EmptyList_ReturnsNull()
    {
        // Arrange
        var solution = new RotateListOptimal();
        ListNode head = null;
        int k = 3;

        // Act
        ListNode result = solution.RotateRight(head, k);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    // Test case: Single node list remains unchanged for any k
    public void RotateRight_SingleNode_ReturnsSameList()
    {
        // Arrange
        var solution = new RotateListOptimal();
        ListNode head = CreateLinkedList(new int[] { 1 });
        int k = 5;
        int[] expected = new int[] { 1 };

        // Act
        ListNode result = solution.RotateRight(head, k);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    // Test case: k = 0 should return original list
    public void RotateRight_ZeroRotations_ReturnsOriginalList()
    {
        // Arrange
        var solution = new RotateListOptimal();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3 });
        int k = 0;
        int[] expected = new int[] { 1, 2, 3 };

        // Act
        ListNode result = solution.RotateRight(head, k);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    // Test case: k equals list length should return original list
    public void RotateRight_KEqualsLength_ReturnsOriginalList()
    {
        // Arrange
        var solution = new RotateListOptimal();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3 });
        int k = 3;
        int[] expected = new int[] { 1, 2, 3 };

        // Act
        ListNode result = solution.RotateRight(head, k);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    // Test case: Multiple of length rotations should return original list
    public void RotateRight_MultipleOfLength_ReturnsOriginalList()
    {
        // Arrange
        var solution = new RotateListOptimal();
        ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4 });
        int k = 8; // 8 % 4 = 0
        int[] expected = new int[] { 1, 2, 3, 4 };

        // Act
        ListNode result = solution.RotateRight(head, k);
        int[] actual = LinkedListToArray(result);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    // Test case: Compare brute force and optimal solutions
    public void BothSolutions_ProduceSameResults()
    {
        // Arrange
        var bruteForce = new RotateListBruteForce();
        var optimal = new RotateListOptimal();
        int[] testCases = new int[] { 0, 1, 2, 5, 10, 15 };

        foreach (int k in testCases)
        {
            ListNode head1 = CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
            ListNode head2 = CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });

            // Act
            ListNode result1 = bruteForce.RotateRight(head1, k);
            ListNode result2 = optimal.RotateRight(head2, k);

            // Assert
            Assert.Equal(LinkedListToArray(result1), LinkedListToArray(result2));
        }
    }
}