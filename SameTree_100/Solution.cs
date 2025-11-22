namespace SameTree_100
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
        // Recursive Depth-First Search (DFS)
        public bool IsSameTree(TreeNode? p, TreeNode? q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        // Breadth-First Search (BFS) using Queue
        public bool IsSameTreeIterative(TreeNode? p, TreeNode? q)
        {
            Queue<TreeNode?> queue = new Queue<TreeNode?>();

            queue.Enqueue(p);

            queue.Enqueue(q);

            while (queue.Count > 0)
            {
                TreeNode? node1 = queue.Dequeue();
                TreeNode? node2 = queue.Dequeue();

                // Both nodes are null, continue to next pair
                if (node1 == null && node2 == null) continue;

                // One of the nodes is null - trees are not the same
                if (node1 == null || node2 == null) return false;

                // Values are different - trees are not the same
                if (node1.val != node2.val) return false;

                // Enqueue left and right children for both nodes
                queue.Enqueue(node1.left);
                queue.Enqueue(node2.left);
                queue.Enqueue(node1.right);
                queue.Enqueue(node2.right);
            }

            return true;
        }

        // Depth-First Search (DFS) using Stack
        public bool IsSameTreeIterativeDFS(TreeNode? p, TreeNode? q)
        {
            Stack<TreeNode?> stack = new Stack<TreeNode?>();
            stack.Push(p);
            stack.Push(q);
            while (stack.Count > 0)
            {
                TreeNode? node2 = stack.Pop();
                TreeNode? node1 = stack.Pop();
                // Both nodes are null, continue to next pair
                if (node1 == null && node2 == null) continue;
                // One of the nodes is null - trees are not the same
                if (node1 == null || node2 == null) return false;
                // Values are different - trees are not the same
                if (node1.val != node2.val) return false;
                // Push right and left children for both nodes
                stack.Push(node1.right);
                stack.Push(node2.right);
                stack.Push(node1.left);
                stack.Push(node2.left);
            }
            return true;
        }
    }
}
