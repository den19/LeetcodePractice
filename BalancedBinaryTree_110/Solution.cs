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

            // Вычисляем высоты левого и правого поддеревьев
            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);

            // Проверяем условие сбалансированности
            return Math.Abs(leftHeight - rightHeight) <= 1
                && IsBalanced(root.right)
                && IsBalanced(root.left);
        }
    }

    public class SolutionDFSOptimal
    {
        public bool IsBalanced(TreeNode root)
        {
            return CheckBalance(root) != -1;
        }

        // Возвращает высоту дерева или -1, если дерево несбалансировано
        private int CheckBalance(TreeNode node)
        {
            if (node == null) return 0;

            // Рекурсивно проверяем левое поддерево
            int leftHeight = CheckBalance(node.left);
            if (leftHeight == -1) return -1; // Левое поддерево несбалансировано

            // Рекурсивно проверяем правое поддерево
            int rightHeight = CheckBalance(node.right);
            if (rightHeight == -1) return -1; // Правое поддерево несбалансировано

            // Проверяем баланс текущего узла
            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

            // Возвращаем высоту текущего поддерева
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
