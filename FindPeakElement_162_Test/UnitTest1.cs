using FindPeakElement_162;

namespace FindPeakElement_162_Test
{
    public class FindPeakElementTests
    {

        private readonly Solution _solution = new Solution();

        [Fact]
        public void TestFindSingleElement()
        {
            var result = _solution.FindPeakElementBinarySearch(new[] { 1 });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestSimpleCase()
        {
            var result = _solution.FindPeakElementBinarySearch(new[] { 1, 2, 3, 1 });
            Assert.Equal(2, result); // Индекс элемента '3'
        }

        [Fact]
        public void TestFirstElementIsPeak()
        {
            var result = _solution.FindPeakElementBinarySearch(new[] { 3, 2, 1 });
            Assert.Equal(0, result); // Первый элемент является пиком
        }

        [Fact]
        public void TestLastElementIsPeak()
        {
            var result = _solution.FindPeakElementBinarySearch(new[] { 1, 2, 3 });
            Assert.Equal(2, result); // Последний элемент является пиком
        }

        [Fact]
        public void TestMiddleElementIsPeak()
        {
            var result = _solution.FindPeakElementBinarySearch(new[] { 1, 3, 2, 1 });
            Assert.Equal(1, result); // Средний элемент является пиком
        }

        [Fact]
        public void TestLargeArray()
        {
            var input = Enumerable.Range(1, 1000).ToArray(); // Создаем возрастающую последовательность
            var result = _solution.FindPeakElementBinarySearch(input);
            Assert.Equal(999, result); // Вернет последний элемент как пик
        }
    }
}