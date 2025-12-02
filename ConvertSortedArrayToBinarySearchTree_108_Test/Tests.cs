using ConvertSortedArrayToBinarySearchTree_108;
using Xunit;

public class SortedArrayToBSTTests
{
    private readonly Solution _solution;

    public SortedArrayToBSTTests()
    {
        _solution = new Solution();
    }

    // Test 1: Empty array should return null
    [Fact]
    public void SortedArrayToBST_EmptyArray_ReturnsNull()
    {
        // Arrange
        int[] nums = new int[0];

        // Act
        TreeNode result = _solution.SortedArrayToBST(nums);

        // Assert
        Assert.Null(result);
    }

    // Test 2: Single element array should return a tree with only root
    [Fact]
    public void SortedArrayToBST_SingleElement_ReturnsSingleNodeTree()
    {
        // Arrange
        int[] nums = new int[] { 5 };

        // Act
        TreeNode result = _solution.SortedArrayToBST(nums);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.val);
        Assert.Null(result.left);
        Assert.Null(result.right);
    }

    // Test 3: Array with three elements should create balanced tree
    [Fact]
    public void SortedArrayToBST_ThreeElements_CreatesBalancedTree()
    {
        // Arrange
        int[] nums = new int[] { 1, 2, 3 };

        // Act
        TreeNode result = _solution.SortedArrayToBST(nums);

        // Assert: Tree should be balanced
        Assert.True(_solution.IsBalanced(result));

        // Assert: Tree should be valid BST
        Assert.True(_solution.IsValidBST(result));

        // Assert: Root should be the middle element (2)
        Assert.Equal(2, result.val);
    }

    // Test 4: Array with odd number of elements
    [Fact]
    public void SortedArrayToBST_OddLengthArray_CreatesValidBST()
    {
        // Arrange
        int[] nums = new int[] { -10, -3, 0, 5, 9 };

        // Act
        TreeNode result = _solution.SortedArrayToBST(nums);

        // Assert: Tree should be valid BST
        Assert.True(_solution.IsValidBST(result));

        // Assert: Tree should be balanced (height difference <= 1)
        Assert.True(_solution.IsBalanced(result));
    }

    // Test 5: Array with even number of elements
    [Fact]
    public void SortedArrayToBST_EvenLengthArray_CreatesValidBST()
    {
        // Arrange
        int[] nums = new int[] { 1, 2, 3, 4, 5, 6 };

        // Act
        TreeNode result = _solution.SortedArrayToBST(nums);

        // Assert: Tree should be valid BST
        Assert.True(_solution.IsValidBST(result));

        // Assert: Tree should be balanced
        Assert.True(_solution.IsBalanced(result));
    }

    // Test 6: Large array should still be balanced
    [Fact]
    public void SortedArrayToBST_LargeArray_RemainsBalanced()
    {
        // Arrange
        int[] nums = Enumerable.Range(1, 1000).ToArray();

        // Act
        TreeNode result = _solution.SortedArrayToBST(nums);

        // Assert: Tree should be balanced
        Assert.True(_solution.IsBalanced(result));

        // Assert: Tree should be valid BST
        Assert.True(_solution.IsValidBST(result));
    }

    // Helper method to check if value exists in tree (for assertions)
    private bool Contains(TreeNode root, int value)
    {
        if (root == null) return false;
        if (root.val == value) return true;
        return Contains(root.left, value) || Contains(root.right, value);
    }
}

// Extension method for Contains assertion
public static class TreeNodeExtensions
{
    public static bool Contains(this TreeNode root, int value)
    {
        if (root == null) return false;
        if (root.val == value) return true;
        return root.left.Contains(value) || root.right.Contains(value);
    }
}