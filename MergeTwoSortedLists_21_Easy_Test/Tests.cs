using MergeTwoSortedLists_21_Easy;

namespace MergeTwoSortedLists_21_Easy_Test
{
    public class MergeTests
    {
        private static bool AreEqual(ListNode result, params int[] expectedValues)
        {
            ListNode current = result;
            for (int i = 0; i < expectedValues.Length; i++)
            {
                if (current == null || current.val != expectedValues[i])
                    return false;
                current = current.next;
            }
            return current == null;
        }

        // Test Method For [1,2,4] и [1,3,4]
        [Fact]
        public void Test_Merge_Two_Sorted_Lists()
        {
            var list1 = Solver.CreateLinkedList(new int[] { 1, 2, 4 });
            var list2 = Solver.CreateLinkedList(new int[] { 1, 3, 4 });
            Assert.True(AreEqual(Solver.MergeTwoListsOrdinal(list1, list2), 1, 1, 2, 3, 4, 4));
        }

        // Test Method For [5,7,9] и [6,8,10]
        [Fact]
        public void Test_Merge_Different_Lengths()
        {
            var list3 = Solver.CreateLinkedList(new int[] { 5, 7, 9 });
            var list4 = Solver.CreateLinkedList(new int[] { 6, 8, 10 });
            Assert.True(AreEqual(Solver.MergeTwoListsOrdinal(list3, list4), 5, 6, 7, 8, 9, 10));
        }

        // Проверка ситуации, когда один из списков пуст
        [Fact]
        public void Test_Empty_List()
        {
            var emptyList = Solver.CreateLinkedList(new int[] { });
            var nonEmptyList = Solver.CreateLinkedList(new int[] { 1, 2, 3 });
            Assert.True(AreEqual(Solver.MergeTwoListsOrdinal(emptyList, nonEmptyList), 1, 2, 3));
        }
    }
}