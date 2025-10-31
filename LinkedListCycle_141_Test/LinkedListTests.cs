using LinkedListCycle_141;
using System.Collections.Generic;
using Xunit;

namespace LinkedListCycle_141_Test
{
    public class LinkedListTests
    {
        // Aux function to create linked list
        private static ListNode BuildLinkedList(int[] values, int pos)
        {
            var dummyHead = new ListNode(-1); // Fictive head
            var current = dummyHead;

            for (int i = 0; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            if (pos >= 0 && pos < values.Length)
            {
                current.next = dummyHead.next.next; // Create cycle
            }

            return dummyHead.next;
        }

        [Fact]
        public void TestHasCycle_WithCycle_ReturnsTrue()
        {
            var solution = new Solution();
            var input = BuildLinkedList(new[] { 3, 2, 0, -4 }, 1);
            Assert.True(solution.HasCycle(input));
        }

        [Fact]
        public void TestHasCycle_NoCycle_ReturnsFalse()
        {
            var solution = new Solution();
            var input = BuildLinkedList(new[] { 1, 2 }, -1);
            Assert.False(solution.HasCycle(input));
        }

        [Fact]
        public void TestHasCycle_SingleElementNoCycle_ReturnsFalse()
        {
            var solution = new Solution();
            var input = BuildLinkedList(new[] { 1 }, -1);
            Assert.False(solution.HasCycle(input));
        }

        [Fact]
        public void TestHasCycle_LoopAtFirstNode_ReturnsTrue()
        {
            var solution = new Solution();
            var input = BuildLinkedList(new[] { 1, 2 }, 0);
            Assert.True(solution.HasCycle(input));
        }
    }
}