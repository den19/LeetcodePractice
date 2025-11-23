using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symmetric_Tree_101
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
        /// Symmetric Tree, Brute Force Approach
        /// Time O(N)
        /// Memory O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetricBruteForce(TreeNode root)
        {
            if (root == null) return true;

            // Convert tree to list using level order traversal
            var values = new List<int?>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                var levelValues = new List<int?>();

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();

                    if (current != null)
                    {
                        levelValues.Add(current.val);
                        queue.Enqueue(current.left);
                        queue.Enqueue(current.right);
                    }
                    else
                    {
                        levelValues.Add(null);
                    }
                }

                // Check if current level is symmetric
                if (!IsListSymmetric(levelValues))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsListSymmetric(List<int?> list)
        {
            int left = 0, right = list.Count - 1;

            while(left < right)
            {
                if (list[left] != list[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        // Most Efficient Recursive Approach
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsMirror(root.left, root.right);
        }

        private bool IsMirror(TreeNode left, TreeNode right)
        {
            // Both nodes are null - symmetric
            if (left == null && right == null) return true;

            // One node is null, other is not - asymmetric
            if (left == null || right == null) return false;

            // Values don't match - asymmetric
            if (left.val != right.val) return false;

            // Recursively check mirrors
            return IsMirror(left.left, right.right) &&
                   IsMirror(left.right, right.left);
        }


        // Iterative Approach using Queue
        public bool IsSymmetricIterative(TreeNode root)
        {
            if (root == null) return true;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);

            while (queue.Count > 0)
            {
                TreeNode left = queue.Dequeue();
                TreeNode right = queue.Dequeue();

                // Both nodes are null - continue
                if (left == null && right == null) continue;

                // One node is null, other is not - asymmetric
                if (left == null || right == null) return false;

                // Values don't match - asymmetric
                if (left.val != right.val) return false;

                // Add children in mirror order
                queue.Enqueue(left.left);
                queue.Enqueue(right.right);
                queue.Enqueue(left.right);
                queue.Enqueue(right.left);
            }

            return true;
        }
    }
}
