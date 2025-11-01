using IntersectionOfTwoLinkedLists_160;

namespace IntersectionOfTwoLinkedLists_160_Test
{
    public class ListNodeTests
    {

        private static ListNode BuildLinkedList(params int[] values)
        {
            if (values.Length == 0) return null;
            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }
            return head;
        }

        [Fact]
        public void Test_IntersectionExists()
        {
            // Create two lists with common tail
            ListNode tail = BuildLinkedList(8, 4, 5);
            ListNode listA = BuildLinkedList(4, 1);
            ListNode listB = BuildLinkedList(5, 6, 1);

            // Connect common tail
            listA.next.next = tail;
            listB.next.next.next = tail;

            // Assert
            Assert.Equal(listA.next.next, new Solution().GetIntersectionNode(listA, listB));
        }

        [Fact]
        public void Test_NoIntersection()
        {
            // Two lists without common tail
            ListNode listA = BuildLinkedList(2, 6, 4);
            ListNode listB = BuildLinkedList(1, 5);

            // Must return null
            Assert.Null(new Solution().GetIntersectionNode(listA, listB));
        }

        [Fact]
        public void Test_EmptyLists()
        {
            // Both lists are empty
            ListNode listA = null;
            ListNode listB = null;

            // Must return null
            Assert.Null(new Solution().GetIntersectionNode(listA, listB));
        }

        [Fact]
        public void Test_SingleElementIntersection()
        {
            // Lists have only one cщmmon vertex
            ListNode intersection = new ListNode(3);
            ListNode listA = BuildLinkedList(1, 2);
            ListNode listB = BuildLinkedList(4, 5);

            listA.next.next = intersection;
            listB.next.next = intersection;

            // Result is their common element
            Assert.Equal(intersection, new Solution().GetIntersectionNode(listA, listB));
        }
    }
}