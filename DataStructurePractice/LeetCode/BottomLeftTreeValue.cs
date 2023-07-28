namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/LwUNpT/
/// 二叉树的节点个数的范围是 [1,10^4]
/// </summary>
public class BottomLeftTreeValue
{
    public int FindBottomLeftValue(TreeNode root)
    {
        var bottomLeft = root;

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
                bottomLeft = queue.Count > 0 ? queue.Peek() : bottomLeft;
                curEnd = nextEnd;
            }
        }
        return bottomLeft.val;
    }

    /**
     * 三个变量 curNode, curEnd, nextEnd
     * 遍历的同时更新和判断比较它们的值
     * 
     * 用一个变量来记录bottomLeft(注意判断空)
     * */
}