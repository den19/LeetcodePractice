using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBinaryTree_110
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

    public class SolutionBruteForce
    {
        private int GetHeight(TreeNode node)
        {
            if(node == null) return 0;

            return 1 + Math.Max(GetHeight(node.left),
                                GetHeight(node.right));
        }

        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            // 
        }
    }

    public class SolutionDFSOptimal
    {

    }
}
