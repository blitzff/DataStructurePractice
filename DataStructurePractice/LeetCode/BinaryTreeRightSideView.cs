namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/WNC0Lk/
/// �������Ľڵ�����ķ�Χ�� [0,100]
/// ����ÿһ���������Ľڵ�
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
     * ����ÿһ�����ҽڵ��ֵ
     * 
     * 3������ curNode, curEnd, nextEnd
     * 
     * һ����¼��Ŀ�Ľ�����б�
     * 
     * curNode == curEndʱ, ����ǰ�ڵ��ֵ���б�
     * 
     * ��󷵻ؽ���б�
     * 
     * һ��ͨ��!
     * */
}