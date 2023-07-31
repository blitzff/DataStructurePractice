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