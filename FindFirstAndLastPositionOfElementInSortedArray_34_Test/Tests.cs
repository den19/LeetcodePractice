using FindFirstAndLastPositionOfElementInSortedArray_34;

namespace FindFirstAndLastPositionOfElementInSortedArray_34_Test
{
    public class SearchRangeTest
    {
        [Fact]
        public void TestTargetExistsMultipleTimes()
        {
            var solution = new Solution();
            var result = solution.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            Assert.Equal(new int[] { 3, 4 }, result);
        }

        [Fact]
        public void TestTargetNotFound()
        {
            var solution = new Solution();
            var result = solution.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);
            Assert.Equal(new int[] { -1, -1 }, result);
        }

        [Fact]
        public void TestSingleElementArray()
        {
            var solution = new Solution();
            var result = solution.SearchRange(new int[] { 1 }, 1);
            Assert.Equal(new int[] { 0, 0 }, result);
        }

        [Fact]
        public void TestEmptyArray()
        {
            var solution = new Solution();
            var result = solution.SearchRange(new int[] { }, 1);
            Assert.Equal(new int[] { -1, -1 }, result);
        }

        [Fact]
        public void TestAllSameElements()
        {
            var solution = new Solution();
            var result = solution.SearchRange(new int[] { 2, 2, 2, 2, 2 }, 2);
            Assert.Equal(new int[] { 0, 4 }, result);
        }
    }
}