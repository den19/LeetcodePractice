using SearchInRotatedSortedArray2;

namespace SearchInRotatedSortedArray2_Test
{
    public class SearchInRotatedSortedArrayTests
    {
        private readonly Solution _solution = new Solution();

        [Fact]
        public void Test_FoundTarget()
        {
            var input = new[] { 2, 5, 6, 0, 0, 1, 2 };
            Assert.True(_solution.Search(input, 0));
        }

        [Fact]
        public void Test_NotFoundTarget()
        {
            var input = new[] { 2, 5, 6, 0, 0, 1, 2 };
            Assert.False(_solution.Search(input, 3));
        }

        [Fact]
        public void Test_EmptyArray()
        {
            var input = new int[] { };
            Assert.False(_solution.Search(input, 1));
        }

        [Fact]
        public void Test_SingleElementArray_TargetPresent()
        {
            var input = new[] { 1 };
            Assert.True(_solution.Search(input, 1));
        }

        [Fact]
        public void Test_SingleElementArray_TargetNotPresent()
        {
            var input = new[] { 1 };
            Assert.False(_solution.Search(input, 2));
        }

        [Fact]
        public void Test_AllSameElements()
        {
            var input = new[] { 1, 1, 1, 1, 1 };
            Assert.True(_solution.Search(input, 1));
        }

        [Fact]
        public void Test_AllSameElementsButNoMatch()
        {
            var input = new[] { 1, 1, 1, 1, 1 };
            Assert.False(_solution.Search(input, 2));
        }
    }
}