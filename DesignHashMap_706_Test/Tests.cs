using DesignHashMap_706;

namespace DesignHashMap_706_Test
{
    public class MyHashMapTests
    {
        [Fact]
        public void TestPutAndGet()
        {
            var map = new MyHashMap();
            map.Put(1, 100);
            Assert.Equal(100, map.Get(1)); // Check existence of value
            Assert.Equal(-1, map.Get(2)); // Check missing of value
        }

        [Fact]
        public void TestRemove()
        {
            var map = new MyHashMap();
            map.Put(1, 100);
            map.Remove(1);
            Assert.Equal(-1, map.Get(1)); // Value must be missing
        }

        [Fact]
        public void TestMultipleOperations()
        {
            var map = new MyHashMap();
            map.Put(1, 100);
            map.Put(2, 200);
            map.Put(3, 300);
            Assert.Equal(100, map.Get(1));
            Assert.Equal(200, map.Get(2));
            Assert.Equal(300, map.Get(3));

            map.Remove(2);
            Assert.Equal(-1, map.Get(2));
        }
    }
}