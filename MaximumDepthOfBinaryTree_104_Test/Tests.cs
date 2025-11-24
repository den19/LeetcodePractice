using MaximumDepthOfBinaryTree_104;
using static MaximumDepthOfBinaryTree_104.Solution;

public class MaximumDepthTests
{
    [Fact]
    public void MaxDepth_EmptyTree_ReturnsZero()
    {
        // Arrange
        Solution solution = new Solution();
        TreeNode root = null;

        // Act
        int result = solution.MaxDepth(root);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void MaxDepth_SingleNode_ReturnsOne()
    {
        // Arrange - Tree with only root node: [1]
        Solution solution = new Solution();
        TreeNode root = new TreeNode(1);

        // Act
        int result = solution.MaxDepth(root);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void MaxDepth_CompleteBinaryTree_ReturnsCorrectDepth()
    {
        // Arrange - Complete binary tree:
        //     3
        //    / \
        //   9   20
        //       / \
        //      15  7
        Solution solution = new Solution();
        TreeNode root = new TreeNode(3)
        {
            left = new TreeNode(9),
            right = new TreeNode(20)
            {
                left = new TreeNode(15),
                right = new TreeNode(7)
            }
        };

        // Act
        int result = solution.MaxDepth(root);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void MaxDepth_LeftSkewedTree_ReturnsCorrectDepth()
    {
        // Arrange - Left skewed tree:
        //     1
        //    /
        //   2
        //  /
        // 3
        Solution solution = new Solution();
        TreeNode root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(3)
            }
        };

        // Act
        int result = solution.MaxDepth(root);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void MaxDepth_RightSkewedTree_ReturnsCorrectDepth()
    {
        // Arrange - Right skewed tree:
        //   1
        //    \
        //     2
        //      \
        //       3
        Solution solution = new Solution();
        TreeNode root = new TreeNode(1)
        {
            right = new TreeNode(2)
            {
                right = new TreeNode(3)
            }
        };

        // Act
        int result = solution.MaxDepth(root);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void MaxDepth_BalancedTree_ReturnsCorrectDepth()
    {
        // Arrange - Balanced tree:
        //       1
        //      / \
        //     2   3
        //    / \   \
        //   4   5   6
        Solution solution = new Solution();
        TreeNode root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
            {
                right = new TreeNode(6)
            }
        };

        // Act
        int result = solution.MaxDepth(root);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void MaxDepth_AllApproaches_ReturnSameResult()
    {
        // Arrange - Complex tree
        Solution solution = new Solution();
        TreeNode root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
                {
                    left = new TreeNode(7)
                }
            },
            right = new TreeNode(3)
            {
                right = new TreeNode(6)
            }
        };

        // Act
        int recursiveResult = solution.MaxDepth(root);
        int bfsResult = solution.MaxDepthBFS(root);
        int iterativeDfsResult = solution.MaxDepthIterativeDFS(root);

        // Assert - All approaches should return the same result
        Assert.Equal(4, recursiveResult);
        Assert.Equal(recursiveResult, bfsResult);
        Assert.Equal(recursiveResult, iterativeDfsResult);
    }
}