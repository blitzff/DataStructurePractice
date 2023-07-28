namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/NaqhDT/
/// ���������������ȫ���������Ұ��� 1 �� 1000 ���ڵ㡣
/// </summary>
public class CBTInserter
{
    private readonly TreeNode root;
    private Queue<TreeNode> queue;

    public CBTInserter(TreeNode root)
    {
        queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        /**
         * ������ȫ�������Ľڵ�, ֻ���������:
         * �Һ���Ϊ�� �� ���Һ��Ӷ�Ϊ��
         * 
         * ���ڶ��������β�ڵ�ĸ��ڵ�tf ����ͬ��ĺ����ڵ�
         * */
        while (queue.Peek().left != null 
            && queue.Peek().right != null)
        {
            var cur = queue.Dequeue();
            queue.Enqueue(cur.left);
            queue.Enqueue(cur.right);
        }

        this.root = root;
    }

    public int Insert(int v)
    {
        var node = new TreeNode(v);
        var parent = queue.Peek();
        if (parent.left == null)
        {
            parent.left = node;
        }
        else
        {
            queue.Dequeue().right = node;

            /**
             * ���ڶ�����Ļ���parentͬ��ĺ����ڵ�,
             * ����parent�ĺ��ӽڵ�Ҫ�����Ϊ������β�ڵ�.
             * */
            queue.Enqueue(parent.left);
            queue.Enqueue(parent.right);
        }
        return parent.val;
    }

    public TreeNode Get_root()
    {
        return root;
    }

    /**
     * ��ô�ж���ȫ��������β�ڵ�ĸ��ڵ�:
     *  ����Һ���Ϊ��
     * 
     * ��ô������¼���һ���ڵ�? 
     *  ��β�ڵ�ĸ��ڵ�tf ����ͬ��ĺ����ڵ����ڶ�����.
     * 
     * */
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(
        int val,
        TreeNode left = null,
        TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}