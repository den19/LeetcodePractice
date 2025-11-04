using DesignHashSet_705;

namespace DesignHashSet_705_Test
{
    public class HashSetTests
    {
        [Fact]
        public void TestBasicOperations_ArrayBased()
        {
            var set = new ArrayBasedHashSet();

            Assert.False(set.Contains(1));
            set.Add(1);
            Assert.True(set.Contains(1));
            set.Remove(1);
            Assert.False(set.Contains(1));
        }

        [Fact]
        public void TestMultipleElements_ArrayBased()
        {
            var set = new ArrayBasedHashSet();

            for (int i = 0; i < 100; i++)
            {
                set.Add(i * 10);
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.True(set.Contains(i * 10));
            }
        }

        [Fact]
        public void TestNonExistingElement_ArrayBased()
        {
            var set = new ArrayBasedHashSet();

            set.Add(100);
            Assert.False(set.Contains(101));
        }

        [Fact]
        public void TestChainedHashSet_BasicOperations()
        {
            var set = new ChainedHashSet();

            Assert.False(set.Contains(1));
            set.Add(1);
            Assert.True(set.Contains(1));
            set.Remove(1);
            Assert.False(set.Contains(1));
        }

        [Fact]
        public void TestChainedHashSet_MultipleElements()
        {
            var set = new ChainedHashSet();

            for (int i = 0; i < 100; i++)
            {
                set.Add(i * 10);
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.True(set.Contains(i * 10));
            }
        }

        [Fact]
        public void TestChainedHashSet_NonExistingElement()
        {
            var set = new ChainedHashSet();

            set.Add(100);
            Assert.False(set.Contains(101));
        }
    }
}