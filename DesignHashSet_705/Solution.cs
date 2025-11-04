namespace DesignHashSet_705
{
    public class Solution
    {
    }

    /// <summary>
    /// Hash function optimized approach
    /// </summary>
    public class ChainedHashSet
    {
        private List<int>[] buckets;

        /// Beginning\initial capacity
        private int capacity = 1000;

        public ChainedHashSet()
        {
            buckets = new List<int>[capacity];
        }
        
        private int GetBucketIndex(int key)
        {
            // Simple hash function
            return Math.Abs(key % capacity);
        }

        public void Add(int key)
        {
            var index = GetBucketIndex(key);

            if (buckets[index] == null)
            {
                buckets[index] = new List<int>();
            }

            if (!buckets[index].Contains(key))
            {
                buckets[index].Add(key);
            }
        }

        public void Remove(int key)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] != null)
            {
                buckets[index].Remove(key);

                if (buckets[index].Count == 0)
                {
                    buckets[index] = null;
                }
            }
        }

        public bool Contains(int key)
        {
            var index = GetBucketIndex(key);
            
            return buckets[index] != null && buckets[index].Contains(key);

        }

    }

    /// <summary>
    /// Ordinary approach using array
    /// Time O(1)
    /// Nagatives: Huge amount of memory
    /// Out of range errors may occur
    /// </summary>
    public class ArrayBasedHashSet
    {
        private bool[] data;

        public ArrayBasedHashSet()
        {
            // Array size depends on expected key range
            // Assume, that keys are in range [0..999999]
            this.data = new bool[1000000];
        }

        public void Add(int key)
        {
            if (key >= 0 && key < data.Length)
            {
                this.data[key] = true;
            }
        }

        public void Remove(int key)
        {
            if (key > 0 && key < data.Length)
            {
                data[key] = false;
            }
        }

        public bool Contains(int key)
        {
            return key >= 0 && key < data.Length && data[key];
        }
    }
    
}
