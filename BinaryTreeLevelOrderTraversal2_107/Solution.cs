namespace BinaryTreeLevelOrderTraversal2_107
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
        /// Standard BFS
        /// O(N)
        /// O(W), w - maximum breadth of tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottomStandardBFS(TreeNode root)
        {
            var result = new List<IList<int>>();

            if(root == null)
            {
                return result;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                var currentLevel = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    currentLevel.Add(node.val);

                    if(node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                result.Add(currentLevel);
            }

            // Razvorachivaem spisok urovney
            result.Reverse();
            return result;
        }

        /// <summary>
        /// Optimal solution with stack
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottomSimplified(TreeNode root)
        {
            var result = new List<IList<int>>();
            var stack = new Stack<IList<int>>(); // For storing levels in reverse order

            if(root == null)
            {
                return result;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                var currentLevel = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    currentLevel.Add(node.val);
                    
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                stack.Push(currentLevel);
            }

            // Unload from stack in result
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }

            return result;
        }
    }
}
