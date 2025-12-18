using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    internal class Solution
    {
        public void Sort(int[] array)
        {
            if (array == null || array.Length <= 1)
            {
                return;
            }

            // Начинаем со второго элемента
            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];

                int j = i - 1;

                while (j >= 0 && array[j] > current)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                // Вставляем текущий элемент в правильную позицию
                array[j + 1] = current;
            }
        }

        /// <summary>
        /// Альтернативная версия с использованием for вместо while
        /// </summary>
        /// <param name="array"></param>
        public void SortAlternative(int[] array)
        {
            if (array == null || array.Length <= 1)
            {
                return;
            }

            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];

                int j;

                for (j = i - 1; j >= 0 && array[j] > current; j--)
                {
                    array[j + 1] = array[j];
                }

                array[j + 1] = current;
            }
        }
    }
}
