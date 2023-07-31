namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/opLdQZ/
/// </summary>
public class TwoSumBST
{
    public bool FindTarget(TreeNode root, int k)
    {
        var increase = new BSTIteratorIncrease(root);
        var decrease = new BSTIteratorDecrease(root);
        var l = increase.Next();
        var r = decrease.Next();
        while (l < r)
        {
            if (l + r == k) return true;

            if (l + r < k)
            {
                l = increase.Next();
            }
            else if (l + r > k)
            {
                r = decrease.Next();
            }
        }
        return false;
    }

    public class BSTIteratorDecrease
    {
        private TreeNode current;
        private TreeNode root;
        private readonly Stack<TreeNode> stack;

        public BSTIteratorDecrease(TreeNode root)
        {
            this.current = root;
            this.root = root;
            stack = new Stack<TreeNode>();
        }

        /// <summary>
        /// ���Լ��� next() ����������Ч�ģ�Ҳ����˵�������� 
        /// next() ʱ��BST ��������������ٴ���һ����һ�����֡�
        /// </summary>
        /// <returns></returns>
        public int Next()
        {
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.right;
                }
                else
                {
                    var node = stack.Pop();
                    current = node.left;
                    return node.val;
                }
            }
            return root.val;
        }

        public bool HasNext()
        {
            return stack.Count > 0 || current != null;
        }
    }

    public class BSTIteratorIncrease
    {
        private TreeNode current;
        private TreeNode root;
        private readonly Stack<TreeNode> stack;

        public BSTIteratorIncrease(TreeNode root)
        {
            this.current = root;
            this.root = root;
            stack = new Stack<TreeNode>();
        }

        /// <summary>
        /// ���Լ��� next() ����������Ч�ģ�Ҳ����˵�������� 
        /// next() ʱ��BST ��������������ٴ���һ����һ�����֡�
        /// </summary>
        /// <returns></returns>
        public int Next()
        {
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    var node = stack.Pop();
                    current = node.right;
                    return node.val;
                }
            }
            return root.val;
        }

        public bool HasNext()
        {
            return stack.Count > 0 || current != null;
        }
    }

    /**
     * ��1: ��ϣ��
     * ��2: ˫ָ��, ���������, ������
     * */
}