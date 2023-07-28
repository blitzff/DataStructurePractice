namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/WNC0Lk/
/// 二叉树的节点个数的范围是 [0,100]
/// 就是每一层的最右面的节点
/// </summary>
public class BinaryTreeRightSideView
{
    public IList<int> RightSideView(TreeNode root)
    {
        if (root == null) return new List<int>();

        var res = new List<int>();

        var curNode = root;
        var curEnd = root;
        var nextEnd = root;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(curNode);

        while (queue.Count > 0)
        {
            curNode = queue.Dequeue();
            if (curNode.left != null)
            {
                queue.Enqueue(curNode.left);
                nextEnd = curNode.left;
            }
            if (curNode.right != null)
            {
                queue.Enqueue(curNode.right);
                nextEnd = curNode.right;
            }

            if (curNode == curEnd)
            {
                res.Add(curNode.val);
                curEnd = nextEnd;
            }
        }

        return res;
    }

    /**
     * 就是每一层最右节点的值
     * 
     * 3个变量 curNode, curEnd, nextEnd
     * 
     * 一个记录题目的结果的列表
     * 
     * curNode == curEnd时, 将当前节点的值入列表
     * 
     * 最后返回结果列表
     * 
     * 一次通过!
     * */
}