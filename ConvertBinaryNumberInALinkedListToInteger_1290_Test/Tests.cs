using ConvertBinaryNumberInALinkedListToInteger;

namespace ConvertBinaryNumberInALinkedListToInteger_1290_Test
{
    public class TestSolution
    {

        private readonly Solution _solution = new Solution();

        [Fact]
        public void SingleBitTest()
        {
            var node = new ListNode(1);   // Представляет '1' в двоичном виде
            Assert.Equal(1, _solution.GetDecimalValueEffective(node));
        }

        [Fact]
        public void SimpleBinaryTest()
        {
            var node = new ListNode(1, new ListNode(0));  // Представляет '10' (или 2 в десятичном виде)
            Assert.Equal(2, _solution.GetDecimalValueEffective(node));
        }

        [Fact]
        public void ComplexBinaryTest()
        {
            var node = new ListNode(1, new ListNode(0, new ListNode(1)));  // Представляет '101' (или 5 в десятичном виде)
            Assert.Equal(5, _solution.GetDecimalValueEffective(node));
        }

        [Fact]
        public void AllZerosTest()
        {
            var node = new ListNode(0, new ListNode(0, new ListNode(0)));
            Assert.Equal(0, _solution.GetDecimalValueEffective(node));
        }

        [Fact]
        public void LongListTest()
        {
            var node = new ListNode(1,
                        new ListNode(0,
                            new ListNode(1,
                                new ListNode(1))));  // Представляет '1011' (или 11 в десятичном виде)
            Assert.Equal(11, _solution.GetDecimalValueEffective(node));
        }
    }
}