using MinimumSizeSubarraySum_209;

namespace MinimumSizeSubarraySim_209_Test
{
    public class SolutionTests
    {
        private readonly Solution _solution = new();

        [Fact]
        public void TestBasicCase()
        {
            Assert.Equal(2, _solution.MinSubArrayLenSlidingWindow(7, new[] { 2, 3, 1, 2, 4, 3 }));
        }

        [Fact]
        public void TestEdgeCaseSingleElement()
        {
            Assert.Equal(1, _solution.MinSubArrayLenSlidingWindow(1, new[] { 1 }));
        }

        [Fact]
        public void TestNoValidSolution()
        {
            Assert.Equal(0, _solution.MinSubArrayLenSlidingWindow(11, new[] { 1, 1, 1, 1, 1 }));
        }

        [Fact]
        public void TestTargetEqualToSumOfAllElements()
        {
            Assert.Equal(3, _solution.MinSubArrayLenSlidingWindow(6, new[] { 1, 2, 3 }));
        }

        [Fact]
        public void TestLargeNumbers()
        {
            Assert.Equal(1, _solution.MinSubArrayLenSlidingWindow(1000000000, new[] { 1000000000 }));
        }

        [Fact]
        public void TestEmptyArray()
        {
            Assert.Equal(0, _solution.MinSubArrayLenSlidingWindow(1, Array.Empty<int>()));
        }
    }
}