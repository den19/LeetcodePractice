using System.ComponentModel.DataAnnotations;

namespace DesignHashMap_706
{
    public class Solution
    {
    }


    /// <summary>
    /// Simple solution using array
    /// Time complexity O(n/m) for all operations.
    /// Average time complexity O(1)
    /// Memory complexity O(m +n), n - number of elements, m - array size
    /// </summary>
    public class HashMapArray
    {
        private List<(int key, int val)>[] data;

        public HashMapArray() 
        {
            // Length can be optimized
            data = new List<(int key, int val)>[1000];
        }

        public void Put(int key, int val)
        {
            var index = GetIndex(key);

            if (data[index] == null)
            {
                data[index] = new List<(int key, int val)>();
            }

            for(var i = 0; i < data[index].Count; ++i)
            {
                // Update existing element
                if (data[index][i].key == key)
                {
                    data[index][i] = (key, val);
                    return;
                }
            }

            // Add new element
            data[index].Add((key, val));
        }


        public int Get(int key)
        {
            var index = GetIndex(key);

            if(data[index] != null)
            {
                foreach(var pair in data[index])
                {
                    if(pair.key == key)
                    {
                        return pair.val;
                    }
                }
            }

            return -1;
        }

        public void Remove(int key)
        {
            var index = GetIndex(key);

            if(data[index] != null )
            {
                for(var i = 0; i < data[index].Count; ++i)
                {
                    if(data[index][i].key == key)
                    {
                        data[index].RemoveAt(i);
                        break;
                    }
                }
            }
        }
        private int GetIndex(int key) => Math.Abs(key % data.Length);
    }


    /// <summary>
    /// Optimized solution with dynamic capacity growth
    /// Time of inserting and search is near O(1)
    /// </summary>
    public class MyHashMap
    {
        private const double LOAD_FACTOR_THRESHOLD = 0.75d;

        private Entry[] entries;

        private int size;

        public MyHashMap() : this(8)
        {
        }

        public MyHashMap(int capacty)
        {
            entries = new Entry[capacty];
        }

        public void Put(int key, int value)
        {
            RehashIfNeeded();

            var index = FindEntryIndex(key);

            if (entries[index] == null || entries[index].Key == -1)
            {
                entries[index] = new Entry(key, value);
                size++;
            }
            else
            {
                entries[index].Value = value;
            }
        }

        public int Get(int key)
        {
            var index = FindEntryIndex(key);

            if (entries[index] != null && entries[index].Key >= 0)
            {
                return entries[index].Value;
            }

            return -1;
        }

        public void Remove(int key)
        {
            var index = FindEntryIndex(key);

            if (entries[index] != null && entries[index].Key >= 0)
            {
                // Mark cell as deleted
                entries[index].MarkAsDeleted();
                size--;
            }
        }

        private bool NeedRehash() => ((double) size / entries.Length) > LOAD_FACTOR_THRESHOLD;

        private void RehashIfNeeded()
        {
            if (NeedRehash())
            {
                var oldEntries = entries.ToArray();
                // Increase capacity two times
                entries = new Entry[oldEntries.Length * 2];

                size = 0;

                foreach(var entry in oldEntries)
                {
                    if(entry != null && entry.Key >= 0)
                    {
                        // Rearrange old records
                        Put(entry.Key, entry.Value);
                    }
                }
            }
        }

        private int FindEntryIndex(int key)
        {
            var hash = GetHash(key);

            while (true)
            {
                if (entries[hash] == null || entries[hash].Key == key)
                {
                    return hash;
                }

                // Goto next free cell
            }
        }

        private int GetHash(int key) => Math.Abs(key % entries.Length);

        private int ProbeNext(int currentIndex) => (currentIndex + 1) % entries.Length;
    }

    class Entry
    {
        public int Key { get; set; }

        public int Value { get; set; }

        public Entry(int key, int value)
        {
            Key = key;
            Value = value;
        }

        public void MarkAsDeleted()
        {
            // Mark as deleted
            Key = -1;
        }
    }
}
