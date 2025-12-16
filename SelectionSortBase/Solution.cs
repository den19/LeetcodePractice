using System;

public class SelectionSort
{
    // Основной метод сортировки выбором
    public static void Sort(int[] array)
    {
        int n = array.Length;

        // Проходим по всем элементам массива, кроме последнего
        for (int i = 0; i < n - 1; i++)
        {
            // Предполагаем, что минимальный элемент - текущий
            int minIndex = i;

            // Ищем минимальный элемент в оставшейся части массива
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Если нашли элемент меньше текущего, меняем их местами
            if (minIndex != i)
            {
                // Обмен элементов
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }

    public static void PrintArray(int[] array)
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}