using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumDepthOfBinaryTree_104
{
    public class Solution
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

        /// <summary>
        /// Approach 1.
        /// Recursive DFS (Depth - First Seacrh)
        /// Linear Time - Most Efficient
        /// Time O(n)
        /// Memory O(h). In worst case its O(n), in balanced tree O(log(n))
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }


        /// <summary>
        /// Approach 1
        /// Alternative concise recusrive version
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepthConcise(TreeNode root)
        {
            return root == null ? 0 :
                Math.Max(MaxDepthConcise(root.left),
                         MaxDepthConcise(root.right)
                        ) + 1;
        }

        /// <summary>
        /// Approach 2
        /// Iterative BFS using queue
        /// Time O(n)
        /// Memory O(w), w - is the max width of the tree. In worst case
        /// (complete binary tree), it is O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepthBFS(TreeNode root)
        {
            if (root == null) return 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 0;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                // Process all nodes at current level
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();

                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }

                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }

                // Increment depth after processing each level
                depth++;
            }
            return depth;
        }

        public int MaxDepthIterativeDFS(TreeNode root)
        {
            if (root == null) return 0;

            Stack<(TreeNode node, int depth)> stack = new Stack<(TreeNode, int)>();
            stack.Push((root, 1));
            int maxDepth = 0;

            while (stack.Count > 0)
            {
                var (currentNode, currentDepth) = stack.Pop();
                maxDepth = Math.Max(maxDepth, currentDepth);

                if (currentNode.right != null)
                {
                    stack.Push((currentNode.right, currentDepth + 1));
                }
                if (currentNode.left != null)
                {
                    stack.Push((currentNode.left, currentDepth + 1));
                }
            }

            return maxDepth;
        }


    }
}
