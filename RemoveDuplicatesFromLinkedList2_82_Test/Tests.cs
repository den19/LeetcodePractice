using RemoveDuplicatesFromLinkedList2_82;

public class SolutionTests
{
    private ListNode CreateList(int[] values)
    {
        if (values.Length == 0) return null;

        ListNode head = new ListNode(values[0]);
        ListNode current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }
        return head;
    }

    private int[] ListToArray(ListNode head)
    {
        var result = new List<int>();
        while (head != null)
        {
            result.Add(head.val);
            head = head.next;
        }
        return result.ToArray();
    }

    [Fact]
    public void EmptyList_ReturnsNull()
    {
        var solution = new Solution();
        var result = solution.DeleteDuplicates(null);
        Assert.Null(result);
    }

    [Fact]
    public void SingleNode_ReturnsSame()
    {
        var solution = new Solution();
        var head = new ListNode(1);
        var result = solution.DeleteDuplicates(head);
        Assert.Equal(new int[] { 1 }, ListToArray(result));
    }

    [Fact]
    public void NoDuplicates_ReturnsSame()
    {
        var solution = new Solution();
        var head = CreateList(new int[] { 1, 2, 3 });
        var result = solution.DeleteDuplicates(head);
        Assert.Equal(new int[] { 1, 2, 3 }, ListToArray(result));
    }

    [Fact]
    public void AllDuplicates_ReturnsNull()
    {
        var solution = new Solution();
        var head = CreateList(new int[] { 1, 1, 1 });
        var result = solution.DeleteDuplicates(head);
        Assert.Null(result);
    }

    [Fact]
    public void MixedDuplicates_CorrectOutput()
    {
        var solution = new Solution();
        var head = CreateList(new int[] { 1, 2, 3, 3, 4, 4, 5 });
        var result = solution.DeleteDuplicates(head);
        Assert.Equal(new int[] { 1, 2, 5 }, ListToArray(result));
    }

    [Fact]
    public void DuplicatesAtBeginning_CorrectOutput()
    {
        var solution = new Solution();
        var head = CreateList(new int[] { 1, 1, 2, 3 });
        var result = solution.DeleteDuplicates(head);
        Assert.Equal(new int[] { 2, 3 }, ListToArray(result));
    }

    [Fact]
    public void DuplicatesAtEnd_CorrectOutput()
    {
        var solution = new Solution();
        var head = CreateList(new int[] { 1, 2, 3, 3 });
        var result = solution.DeleteDuplicates(head);
        Assert.Equal(new int[] { 1, 2 }, ListToArray(result));
    }
}
