using PowXN;

namespace PowXN_50_Test
{
    public class PowerTests
    {
        private readonly Solution _solution = new();

        [Fact]
        public void TestPositiveBaseAndPositiveExponent()
        {
            var expectedResult = Math.Pow(2, 3);
            Assert.Equal(expectedResult, _solution.MyPow(2, 3));
        }

        [Fact]
        public void TestNegativeBaseAndPositiveExponent()
        {
            var expectedResult = Math.Pow(-2, 3);
            Assert.Equal(expectedResult, _solution.MyPow(-2, 3));
        }

        [Fact]
        public void TestPositiveBaseAndNegativeExponent()
        {
            var expectedResult = Math.Pow(2, -3);
            Assert.Equal(expectedResult, _solution.MyPow(2, -3));
        }

        [Fact]
        public void TestZeroExponent()
        {
            var expectedResult = Math.Pow(5, 0);
            Assert.Equal(expectedResult, _solution.MyPow(5, 0));
        }

        [Fact]
        public void TestLargeExponent()
        {
            var expectedResult = Math.Pow(2, 31);
            Assert.Equal(expectedResult, _solution.MyPow(2, 31));
        }

        [Fact]
        public void TestFractionalBase()
        {
            var expectedResult = Math.Pow(0.5, 2);
            Assert.Equal(expectedResult, _solution.MyPow(0.5, 2));
        }

        [Fact]
        public void TestEdgeCaseWithOne()
        {
            var expectedResult = Math.Pow(1, 1000000);
            Assert.Equal(expectedResult, _solution.MyPow(1, 1000000));
        }

        [Fact]
        public void TestMaximumIntExponent()
        {
            var expectedResult = Math.Pow(2, int.MaxValue);
            Assert.Equal(expectedResult, _solution.MyPow(2, int.MaxValue));
        }
    }
}