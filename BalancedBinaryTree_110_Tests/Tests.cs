using BalancedBinaryTree_110;
using Xunit;

public class BalancedBinaryTreeTests
{
    // Helper method to create test trees
    private TreeNode CreateTree(int?[] values)
    {
        if (values.Length == 0 || values[0] == null) return null;

        var root = new TreeNode(values[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;
        while (i < values.Length)
        {
            var current = queue.Dequeue();

            // Left child
            if (i < values.Length && values[i] != null)
            {
                current.left = new TreeNode(values[i].Value);
                queue.Enqueue(current.left);
            }
            i++;

            // Right child
            if (i < values.Length && values[i] != null)
            {
                current.right = new TreeNode(values[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }

    [Fact]
    public void IsBalanced_EmptyTree_ReturnsTrue()
    {
        // Arrange
        var tree = (TreeNode)null;
        var solution = new SolutionDFSOptimal();

        // Act
        var result = solution.IsBalanced(tree);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsBalanced_SingleNode_ReturnsTrue()
    {
        // Arrange
        var tree = new TreeNode(1);
        var solution = new SolutionDFSOptimal();

        // Act
        var result = solution.IsBalanced(tree);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsBalanced_BalancedTree_ReturnsTrue()
    {
        // Arrange: Create a balanced tree
        //     3
        //    / \
        //   9  20
        //      / \
        //     15  7
        var tree = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });
        var solution = new SolutionDFSOptimal();

        // Act
        var result = solution.IsBalanced(tree);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsBalanced_UnbalancedTree_ReturnsFalse()
    {
        // Arrange: Create an unbalanced tree
        //     1
        //    / \
        //   2   2
        //  / \
        // 3   3
        // / \
        //4   4
        var tree = CreateTree(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 });
        var solution = new SolutionDFSOptimal();

        // Act
        var result = solution.IsBalanced(tree);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsBalanced_SkewedLeftTree_ReturnsFalse()
    {
        // Arrange: Create a left-skewed tree
        //     1
        //    /
        //   2
        //  /
        // 3
        var tree = CreateTree(new int?[] { 1, 2, null, 3 });
        var solution = new SolutionDFSOptimal();

        // Act
        var result = solution.IsBalanced(tree);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsBalanced_ComplexBalancedTree_ReturnsTrue()
    {
        // Arrange: Create a complex but balanced tree
        //        1
        //      /   \
        //     2     3
        //    / \   / \
        //   4   5 6   7
        var tree = CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });
        var solution = new SolutionDFSOptimal();

        // Act
        var result = solution.IsBalanced(tree);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CompareBruteForceAndOptimalSolutions()
    {
        // Arrange: Test both solutions on various trees
        var testCases = new List<(int?[] values, bool expected)>
        {
            (new int?[] { }, true),
            (new int?[] { 1 }, true),
            (new int?[] { 1, 2, 3 }, true),
            (new int?[] { 1, 2, null, 3 }, false),
            (new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 }, false),
            (new int?[] { 3, 9, 20, null, null, 15, 7 }, true),
        };

        var bruteForce = new SolutionBruteForce();
        var optimal = new SolutionDFSOptimal();

        foreach (var testCase in testCases)
        {
            // Arrange
            var tree = CreateTree(testCase.values);

            // Act
            var bruteForceResult = bruteForce.IsBalanced(tree);
            var optimalResult = optimal.IsBalanced(tree);

            // Assert
            Assert.Equal(testCase.expected, bruteForceResult);
            Assert.Equal(testCase.expected, optimalResult);
            Assert.Equal(bruteForceResult, optimalResult);
        }
    }
}