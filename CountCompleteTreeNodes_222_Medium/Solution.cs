namespace CountCompleteTreeNodes_222
{
    public class Solution
    {
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Linear approach - visit every node
        /// Time O(N), N - number of nodes
        /// Memory O(H), H - height of the tree (recursion stack)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodesLinear(TreeNode root)
        {
            if (root == null) return 0;

            return 1 + CountNodesLinear(root.left) + CountNodesLinear(root.right);
        }
    }
}
