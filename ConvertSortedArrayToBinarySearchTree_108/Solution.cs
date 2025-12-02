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
    }
}
