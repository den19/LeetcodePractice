/*
 * Merge two sorted linked lists and return it as a new list.
 * The new list should be made by splicing together the nodes of the first two lists.
 * Example:
 * Input
 * list1 = [1, 2, 4]
 * list2 = [1, 3, 4]
 * Output
 * [1, 1, 2, 3, 4, 4]
 */
namespace MergeTwoSortedLists_21_Easy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr1 = new int[] { 1, 2, 4 };
            var arr2 = new int[] { 1, 3, 4 };


            PrintListN(arr1, 1);
            PrintListN(arr1, 2);

            // Create test lists
            ListNode l1 = Solver.CreateLinkedList(arr1);
            ListNode l2 = Solver.CreateLinkedList(arr2);

            Console.WriteLine();
            // Run test
            Console.WriteLine("Test case 1:");
            TestMerge(Solver.MergeTwoListsOrdinal(l1, l2), new int[] { 1, 1, 2, 3, 4, 4 }); // Has to return True

            // Another test case
            var arr3 = new int[] { 5, 7, 9 };
            var arr4 = new int[] { 6, 8, 10 };

            PrintListN(arr3, 3);
            PrintListN(arr4, 4);

            ListNode l3 = Solver.CreateLinkedList(arr3);
            ListNode l4 = Solver.CreateLinkedList(arr4);
            Console.WriteLine("\nTest case 2:");
            TestMerge(Solver.MergeTwoListsOrdinal(l3, l4), new int[] { 5, 6, 7, 8, 9, 10 }); // Has to return True

            Console.Read();
        }

        public static void PrintListN(int[] nums, int listNumber = 0)
        {
            Console.WriteLine();
            if (listNumber != 0)
            {
                Console.WriteLine($"List {listNumber} is");
            }

            foreach (int i in nums)
            {
                Console.Write(i);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        // Вспомогательная функция для проверки результата
        // 
        private static bool TestMerge(ListNode result, int[] expectedValues)
        {
            ListNode current = result;
            for (int i = 0; i < expectedValues.Length; i++)
            {
                if (current == null || current.val != expectedValues[i])
                {
                    Console.WriteLine($"Failed at index {i}. Expected value: {expectedValues[i]}, actual value: {(current?.val ?? -1)}");
                    return false;
                }
                current = current.next;
            }
            if (current != null)
            {
                Console.WriteLine("Extra nodes found in merged list.");
                return false;
            }

            Console.WriteLine();
            Console.WriteLine("Expected:");
            PrintListN(expectedValues);
            Console.WriteLine("Passed!");
            return true;
        }
    }
}
