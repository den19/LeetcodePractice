namespace SelectionSortBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 64, 25, 12, 22, 11 };

            Console.WriteLine("Исходный массив:");

            
            SelectionSort.PrintArray(numbers);

            SelectionSort.Sort(numbers);

            Console.WriteLine("\nОтсортированный массив:");
            SelectionSort.PrintArray(numbers);
        }
    }
}
