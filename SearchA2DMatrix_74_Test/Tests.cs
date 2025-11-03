using SearchA2DMatrix;

namespace SearchA2DMatrix_74_Test
{
    public class SearchMatrixTests
    {
        private readonly Solution _solution = new Solution();

        [Fact]
        public void TestTargetExists()
        {
            var matrix = new[] { new[] { 1, 3, 5 }, new[] { 10, 11, 16 } };
            Assert.True(_solution.SearchMatrixBS(matrix, 3));
        }

        [Fact]
        public void TestTargetNotFound()
        {
            var matrix = new[] { new[] { 1, 3, 5 }, new[] { 10, 11, 16 } };
            Assert.False(_solution.SearchMatrixBS(matrix, 8));
        }

        // Create class TheoryData for storing our data
        public static readonly TheoryData<int[][], int> EdgeCaseTestData = new()
        {
            { new[] { new[] { 1 } }, 1 },
            { new[] { new[] { 1 }, new[] { 3 } }, 3 },
            { new[] { new[] { 1, 3 }, new[] { 5, 7 } }, 5 }
        };

        [Theory]
        [MemberData(nameof(EdgeCaseTestData))]
        public void TestEdgeCases(int[][] matrix, int target)
        {
            Assert.True(_solution.SearchMatrixBS(matrix, target));
        }

        // Create class TheoryData for storing our data
        public static readonly TheoryData<int[][], int> NegativeEdgeCasesTestData = new()
        {
            { new[] {new[] {1} }, 2 },
            { new[] { new[] { 1 }, new[] { 3 } }, 4 },
            { new[] { new[] { 1, 3 }, new[] { 5, 7 } }, 8 }
        };

        [Theory]
        [MemberData(nameof(NegativeEdgeCasesTestData))]
        public void TestNegativeEdgeCases(int[][] matrix, int target)
        {
            Assert.False(_solution.SearchMatrixBS(matrix, target));
        }
    }
}