namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/LwUNpT/
/// �������Ľڵ�����ķ�Χ�� [1,10^4]
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
     * �������� curNode, curEnd, nextEnd
     * ������ͬʱ���º��жϱȽ����ǵ�ֵ
     * 
     * ��һ����������¼bottomLeft(ע���жϿ�)
     * */
}