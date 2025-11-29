using System;
using System.Collections.Generic;
using System.Text;

namespace RotateList_61
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class RotateListBruteForce
    {
        /**
         * Brute Force Approach:
         * - Perform k rotations, each time moving the last node to the front
         * - Time Complexity: O(k * n) where n is the length of the list
         * - Space Complexity: O(1)
         */
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            // Reduce k to avoid unnecessary rotations
            int length = GetLength(head);
            k = k % length;
            if (k == 0) return head;

            // Perform k rotations
            for (int i = 0; i < k; i++)
            {
                head = RotateOnce(head);
            }

            return head;
        }

        private ListNode RotateOnce(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode current = head;
            ListNode prev = null;

            // Find the last node and second last node
            while (current.next != null)
            {
                prev = current;
                current = current.next;
            }

            // Rotate: last node becomes head, second last becomes tail
            prev.next = null;
            current.next = head;

            return current;
        }

        private int GetLength(ListNode head)
        {
            int length = 0;
            ListNode current = head;
            while (current != null)
            {
                length++;
                current = current.next;
            }
            return length;
        }
    }

    public class RotateListOptimal
    {
        /**
         * Optimal Approach:
         * - Calculate length of the list
         * - Find the new head position using modulo operation
         * - Connect the end to the beginning to form a cycle
         * - Break the cycle at the new tail position
         * - Time Complexity: O(n)
         * - Space Complexity: O(1)
         */
        public ListNode RotateRight(ListNode head, int k)
        {
            // Edge cases
            if (head == null || head.next == null || k == 0)
                return head;

            // Step 1: Calculate the length of the list
            ListNode current = head;
            int length = 1;
            while (current.next != null)
            {
                length++;
                current = current.next;
            }

            // Step 2: Connect the last node to head to form a cycle
            current.next = head;

            // Step 3: Calculate effective rotations needed
            k = k % length;
            int stepsToNewHead = length - k;

            // Step 4: Find the new tail (stepsToNewHead - 1 from start)
            ListNode newTail = head;
            for (int i = 1; i < stepsToNewHead; i++)
            {
                newTail = newTail.next;
            }

            // Step 5: The new head is next of new tail
            ListNode newHead = newTail.next;

            // Step 6: Break the cycle
            newTail.next = null;

            return newHead;
        }
    }


}
