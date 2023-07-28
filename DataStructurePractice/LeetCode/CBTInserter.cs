namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/NaqhDT/
/// 最初给定的树是完全二叉树，且包含 1 到 1000 个节点。
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
         * 对于完全二叉树的节点, 只有两种情况:
         * 右孩子为空 或 左右孩子都为空
         * 
         * 留在队列里的是尾节点的父节点tf 及其同层的后续节点
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
             * 留在队列里的还有parent同层的后续节点,
             * 但是parent的孩子节点要入队作为后续的尾节点.
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
     * 怎么判断完全二叉树中尾节点的父节点:
     *  左或右孩子为空
     * 
     * 怎么持续记录最后一个节点? 
     *  将尾节点的父节点tf 及其同层的后续节点留在队列里.
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