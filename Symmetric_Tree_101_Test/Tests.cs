using Symmetric_Tree_101;
using Xunit;

public class SymmetricTreeTests
{
    [Fact]
    // Test case 1: Empty tree should be symmetric
    public void IsSymmetric_EmptyTree_ReturnsTrue()
    {
        // Arrange
        TreeNode root = null;
        var solution = new Solution();

        // Act & Assert
        Assert.True(solution.IsSymmetric(root));
        Assert.True(solution.IsSymmetricIterative(root));
        Assert.True(solution.IsSymmetricBruteForce(root));
    }

    [Fact]
    // Test case 2: Single node tree should be symmetric
    public void IsSymmetric_SingleNode_ReturnsTrue()
    {
        // Arrange
        TreeNode root = new TreeNode(1);
        var solution = new Solution();

        // Act & Assert
        Assert.True(solution.IsSymmetric(root));
        Assert.True(solution.IsSymmetricIterative(root));
        Assert.True(solution.IsSymmetricBruteForce(root));
    }

    [Fact]
    // Test case 3: Symmetric tree with two levels
    public void IsSymmetric_SymmetricTwoLevels_ReturnsTrue()
    {
        // Arrange
        // Tree: 
        //     1
        //    / \
        //   2   2
        TreeNode root = new TreeNode(1,
            new TreeNode(2),
            new TreeNode(2));
        var solution = new Solution();

        // Act & Assert
        Assert.True(solution.IsSymmetric(root));
        Assert.True(solution.IsSymmetricIterative(root));
        Assert.True(solution.IsSymmetricBruteForce(root));
    }

    [Fact]
    // Test case 4: Asymmetric tree with two levels
    public void IsSymmetric_AsymmetricTwoLevels_ReturnsFalse()
    {
        // Arrange
        // Tree:
        //     1
        //    / \
        //   2   3
        TreeNode root = new TreeNode(1,
            new TreeNode(2),
            new TreeNode(3));
        var solution = new Solution();

        // Act & Assert
        Assert.False(solution.IsSymmetric(root));
        Assert.False(solution.IsSymmetricIterative(root));
        Assert.False(solution.IsSymmetricBruteForce(root));
    }

    [Fact]
    // Test case 5: Complex symmetric tree
    public void IsSymmetric_ComplexSymmetric_ReturnsTrue()
    {
        // Arrange
        // Tree:
        //       1
        //      / \
        //     2   2
        //    / \ / \
        //   3  4 4  3
        TreeNode root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3),
                new TreeNode(4)),
            new TreeNode(2,
                new TreeNode(4),
                new TreeNode(3)));
        var solution = new Solution();

        // Act & Assert
        Assert.True(solution.IsSymmetric(root));
        Assert.True(solution.IsSymmetricIterative(root));
        Assert.True(solution.IsSymmetricBruteForce(root));
    }

    [Fact]
    // Test case 6: Complex asymmetric tree
    public void IsSymmetric_ComplexAsymmetric_ReturnsFalse()
    {
        // Arrange
        // Tree:
        //       1
        //      / \
        //     2   2
        //      \   \
        //       3   3
        TreeNode root = new TreeNode(1,
            new TreeNode(2,
                null,
                new TreeNode(3)),
            new TreeNode(2,
                null,
                new TreeNode(3)));
        var solution = new Solution();

        // Act & Assert
        Assert.False(solution.IsSymmetric(root));
        Assert.False(solution.IsSymmetricIterative(root));
        Assert.False(solution.IsSymmetricBruteForce(root));
    }

    [Fact]
    // Test case 7: Tree with null values in asymmetric positions
    public void IsSymmetric_AsymmetricNulls_ReturnsFalse()
    {
        // Arrange
        // Tree:
        //     1
        //    / \
        //   2   2
        //  /   /
        // 3   3
        TreeNode root = new TreeNode(1,
            new TreeNode(2, new TreeNode(3), null),
            new TreeNode(2, new TreeNode(3), null));
        var solution = new Solution();

        // Act & Assert
        Assert.False(solution.IsSymmetric(root));
        Assert.False(solution.IsSymmetricIterative(root));
        Assert.False(solution.IsSymmetricBruteForce(root));
    }

    [Fact]
    // Test case 8: Large symmetric tree
    public void IsSymmetric_LargeSymmetricTree_ReturnsTrue()
    {
        // Arrange
        // Tree:
        //         1
        //       /   \
        //      2     2
        //     / \   / \
        //    3   4 4   3
        //   / \       / \
        //  5   6     6   5
        TreeNode root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3,
                    new TreeNode(5),
                    new TreeNode(6)),
                new TreeNode(4)),
            new TreeNode(2,
                new TreeNode(4),
                new TreeNode(3,
                    new TreeNode(6),
                    new TreeNode(5))));
        var solution = new Solution();

        // Act & Assert
        Assert.True(solution.IsSymmetric(root));
        Assert.True(solution.IsSymmetricIterative(root));
        Assert.True(solution.IsSymmetricBruteForce(root));
    }
}