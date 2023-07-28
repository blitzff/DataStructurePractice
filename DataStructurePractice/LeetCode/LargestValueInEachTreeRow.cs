namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/hPov7L/
/// 二叉树的节点个数的范围是 [0,104]
/// </summary>
public class LargestValueInEachTreeRow
{
    public IList<int> LargestValues(TreeNode root)
    {
        if (root == null) return new List<int>();

        var maxEachLevel = new List<int>();
        var curMax = int.MinValue;

        var curNode = root;
        var curEnd = root;
        var nextEnd = root; // null actually, but need a type to use 'var'

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            curNode = queue.Dequeue();
            curMax = Math.Max(curMax, curNode.val);
            if (curNode.left != null)
            {
                var left = curNode.left;
                queue.Enqueue(left);
                nextEnd = left;
            }
            if (curNode.right != null)
            {
                var right = curNode.right;
                queue.Enqueue(right);
                nextEnd = right;
            }

            if (curNode == curEnd)
            {
                maxEachLevel.Add(curMax);
                curMax = int.MinValue;
                curEnd = nextEnd;
            }
        }
        return maxEachLevel;
    }

    /**
     * 三个变量:
     *  curNode, curEnd, nextEnd
     * 遍历的同时更新和判断这三个变量.
     * */
}