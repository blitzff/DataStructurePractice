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
        /// 可以假设 next() 调用总是有效的，也就是说，当调用 
        /// next() 时，BST 的中序遍历中至少存在一个下一个数字。
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
        /// 可以假设 next() 调用总是有效的，也就是说，当调用 
        /// next() 时，BST 的中序遍历中至少存在一个下一个数字。
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
     * 法1: 哈希表
     * 法2: 双指针, 正反向遍历, 迭代器
     * */
}