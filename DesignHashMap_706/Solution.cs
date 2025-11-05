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
    public class HashSetArray
    {
        private List<(int key, int val)>[] data;

        public HashSetArray() 
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


}
