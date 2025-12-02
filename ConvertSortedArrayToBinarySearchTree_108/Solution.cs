using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertSortedArrayToBinarySearchTree_108
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        /// <summary>
        /// Основной метод для преобразования массива в BST
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if(nums == null || nums.Length == 0)
            {
                return null;
            }

            return ConstructBST(nums, 0, nums.Length - 1);
        }

        private TreeNode ConstructBST(int[] nums, int left, int right)
        {
            // Базывй случай: левая граница превысила правую
            if (left > right)
            {
                return null;
            }

            // Выбираем средний элемент для поддержания баланса
            // Для избежания переполнения исполльзуем безопасное вычисление середины
            int mid = left + (right - left) / 2;

            // Создаем корневой узел
            TreeNode node = new TreeNode(nums[mid]);

            // Рекурсивно строим левое и правое поддеревья
            node.left = ConstructBST(nums, left, mid - 1);
            node.right = ConstructBST(nums, mid + 1, right);

            return node;
        }

        // Вспомогательный метод для проверки, является ли дерево BST
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBST(TreeNode node, long min, long max)
        {
            if (node == null) return true;
            if (node.val <= min || node.val >= max) return false;
            return IsValidBST(node.left, min, node.val) &&
                   IsValidBST(node.right, node.val, max);
        }

        // Вспомогательный метод для проверки сбалансированности дерева
        public bool IsBalanced(TreeNode root)
        {
            return CheckHeight(root) != -1;
        }

        private int CheckHeight(TreeNode node)
        {
            if (node == null) return 0;

            int leftHeight = CheckHeight(node.left);
            if (leftHeight == -1) return -1;

            int rightHeight = CheckHeight(node.right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
