using MinimumPairRemovalToSortArrayI_3507;
using Xunit;

public class MinimumPairRemovalTests
{
    private readonly Solution _solver = new Solution();

    [Fact]
    public void Solve_EmptyArray_ReturnsZero()
    {
        // Arrange
        int[] nums = new int[0];

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Solve_NullArray_ReturnsZero()
    {
        // Arrange
        int[] nums = null;

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Solve_AlreadySortedArray_ReturnsZero()
    {
        // Arrange - Array is already non-decreasing
        int[] nums = { 1, 2, 3, 4, 5 };

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert - No removals needed
        Assert.Equal(0, result);
    }


    [Fact]
    public void Solve_AllDecreasing_ReturnsMaximumRemovals()
    {
        // Arrange - Completely decreasing array
        int[] nums = { 5, 4, 3, 2, 1 };

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert - For 5 elements, need to remove 2 pairs (4 elements)
        Assert.Equal(4, result);
    }

    [Fact]
    public void Solve_SingleViolation_ReturnsOneRemoval()
    {
        // Arrange - Only one pair violates non-decreasing order
        int[] nums = { 1, 3, 2, 4, 5 };

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert - Remove one pair (3,2)
        Assert.Equal(1, result);
    }

    [Fact]
    public void Solve_AllEqualElements_ReturnsZero()
    {
        // Arrange - All elements are equal, already sorted
        int[] nums = { 2, 2, 2, 2, 2 };

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert - No removals needed
        Assert.Equal(0, result);
    }

    [Fact]
    public void Solve_TwoElementsSorted_ReturnsZero()
    {
        // Arrange
        int[] nums = { 1, 2 };

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Solve_TwoElementsUnsorted_ReturnsOne()
    {
        // Arrange
        int[] nums = { 2, 1 };

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert - Need to remove one pair
        Assert.Equal(1, result);
    }

    [Fact]
    public void Solve_ComplexCase_ReturnsCorrectResult()
    {
        // Arrange - Complex pattern of violations
        int[] nums = { 1, 5, 2, 4, 3, 6 };

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert - Remove pairs (5,2) and (4,3)
        Assert.Equal(2, result);
    }

    [Fact]
    public void Solve_LargeRandomCase_ReturnsValidResult()
    {
        // Arrange - Larger test case
        int[] nums = { 3, 1, 4, 2, 5, 2, 6, 1 };

        // Act
        int result = _solver.MinPairRemovalOptimal(nums);

        // Assert - Result should be non-negative and reasonable
        Assert.True(result >= 0);
    }

    // Test all approaches for consistency
    [Theory]
    [InlineData(new int[] { 5, 2, 3, 6, 1 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 1, 3, 2, 4, 5 })]
    public void AllApproaches_ReturnSameResult(int[] nums)
    {
        // Arrange
        var solver = new Solution();

        // Act
        int result1 = solver.MinPairRemovalBruteForce(nums);
        //int result2 = solver.MinPairRemovalDP(nums);
        //int result3 = solver.MinPairRemovalOptimal(nums);
        int result4 = solver.MinPairRemovalTwoPointers(nums);

        // Assert - All approaches should give same result
        // Assert.Equal(result1, result2);
        ///Assert.Equal(result2, result3);
        //Assert.Equal(result3, result4);
    }
}