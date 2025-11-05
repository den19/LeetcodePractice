using FindMinimumInRotatedSortedArray_153;

namespace FindMinimumInRotatedSortedArray_153_Test
{
    public class MinInRotatedArrayTests
    {
        private readonly Solution _solution = new Solution();

        [Fact]
        public void TestSingleElement()
        {
            var result = _solution.FindMin(new[] { 1 });
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestNoRotation()
        {
            var result = _solution.FindMin(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestOneRotation()
        {
            var result = _solution.FindMin(new[] { 3, 4, 5, 1, 2 });
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestMultipleDuplicates()
        {
            var result = _solution.FindMin(new[] { 2, 2, 2, 0, 1 });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestAllSameElements()
        {
            var result = _solution.FindMin(new[] { 1, 1, 1, 1, 1 });
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestLargeInput()
        {
            var input = new int[10000];
            for (var i = 0; i < input.Length; i++) input[i] = i % 10 + 1;
            var result = _solution.FindMin(input);
            Assert.Equal(1, result);
        }
    }
}