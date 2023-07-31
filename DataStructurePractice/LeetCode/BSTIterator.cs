namespace DataStructurePractice.LeetCode;

public class BSTIterator
{
    private TreeNode current;
    private TreeNode root;
    private readonly Stack<TreeNode> stack;

    public BSTIterator(TreeNode root)
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