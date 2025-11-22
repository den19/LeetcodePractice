using SameTree_100;
using Xunit;

public class SameTreeTests
{
    private readonly Solution _solution;

    public SameTreeTests()
    {
        _solution = new Solution();
    }

    // Test case 1: Both trees are empty
    [Fact]
    public void IsSameTree_BothTreesEmpty_ReturnsTrue()
    {
        // Arrange
        TreeNode p = null;
        TreeNode q = null;

        // Act
        bool result = _solution.IsSameTree(p, q);

        // Assert
        Assert.True(result);
    }

    // Test case 2: One tree is empty, the other is not
    [Fact]
    public void IsSameTree_OneTreeEmpty_ReturnsFalse()
    {
        // Arrange
        TreeNode p = null;
        TreeNode q = new TreeNode(1);

        // Act
        bool result = _solution.IsSameTree(p, q);

        // Assert
        Assert.False(result);
    }

    // Test case 3: Single node trees with same value
    [Fact]
    public void IsSameTree_SingleNodeSameValue_ReturnsTrue()
    {
        // Arrange
        TreeNode p = new TreeNode(1);
        TreeNode q = new TreeNode(1);

        // Act
        bool result = _solution.IsSameTree(p, q);

        // Assert
        Assert.True(result);
    }

    // Test case 4: Single node trees with different values
    [Fact]
    public void IsSameTree_SingleNodeDifferentValues_ReturnsFalse()
    {
        // Arrange
        TreeNode p = new TreeNode(1);
        TreeNode q = new TreeNode(2);

        // Act
        bool result = _solution.IsSameTree(p, q);

        // Assert
        Assert.False(result);
    }

    // Test case 5: Complex identical trees
    [Fact]
    public void IsSameTree_ComplexIdenticalTrees_ReturnsTrue()
    {
        // Arrange
        // Tree 1:     1          Tree 2:     1
        //            / \                    / \
        //           2   3                  2   3
        //          / \                    / \
        //         4   5                  4   5
        TreeNode p = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
        };

        TreeNode q = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
        };

        // Act
        bool result = _solution.IsSameTree(p, q);

        // Assert
        Assert.True(result);
    }

    // Test case 6: Trees with same structure but different values
    [Fact]
    public void IsSameTree_SameStructureDifferentValues_ReturnsFalse()
    {
        // Arrange
        // Tree 1:     1          Tree 2:     1
        //            / \                    / \
        //           2   3                  2   4
        TreeNode p = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        TreeNode q = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(4)  // Different value
        };

        // Act
        bool result = _solution.IsSameTree(p, q);

        // Assert
        Assert.False(result);
    }

    // Test case 7: Trees with different structure
    [Fact]
    public void IsSameTree_DifferentStructure_ReturnsFalse()
    {
        // Arrange
        // Tree 1:     1          Tree 2:     1
        //            / \                    / 
        //           2   3                  2   
        TreeNode p = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        TreeNode q = new TreeNode(1)
        {
            left = new TreeNode(2)
            // Missing right child
        };

        // Act
        bool result = _solution.IsSameTree(p, q);

        // Assert
        Assert.False(result);
    }

    // Test case 8: Test all approaches give same result
    [Fact]
    public void IsSameTree_AllApproachesConsistent_ReturnsSameResult()
    {
        // Arrange
        TreeNode p = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        TreeNode q = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        // Act
        bool recursiveResult = _solution.IsSameTree(p, q);
        bool iterativeBFSResult = _solution.IsSameTreeIterative(p, q);
        bool iterativeDFSResult = _solution.IsSameTreeIterativeDFS(p, q);

        // Assert - all approaches should return the same result
        Assert.True(recursiveResult);
        Assert.True(iterativeBFSResult);
        Assert.True(iterativeDFSResult);
    }
}