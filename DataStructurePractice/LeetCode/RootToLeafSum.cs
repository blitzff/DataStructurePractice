namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/3Etpl5/
/// 
/// ���нڵ����Ŀ�ڷ�Χ [1, 1000] ��
/// 0 <= Node.val <= 9
/// ������Ȳ����� 10
/// </summary>
public class RootToLeafSum
{
    public int SumNumbers(TreeNode root)
    {
        return SumPath(root, 0);
    }

    private int SumPath(TreeNode root, int pathSum)
    {
        // ����;�еĿսڵ�, ֱ�ӷ���0
        if (root == null) return 0;

        pathSum = pathSum * 10 + root.val;
        // �������Ҷ�ӽڵ�, ����·����
        if (root.left == null && root.right == null)
        {
            return pathSum;
        }
        // ����Ƿ�Ҷ�ӽڵ�, ������
        else
        {
            var leftSum = SumPath(root.left, pathSum);
            var rightSum = SumPath(root.right, pathSum);

            return leftSum + rightSum;
        }
    }

    /**
     * ��������, ֱ�ӳ˷��������
     * 
     * �ȵõ���һ����, Ȼ��õ��ڶ�����, ..., ��󷵻����ǵĺ�
     * NLR, ����
     * 
     * ����һ���ڵ�
     *  null 
     *      ��Ҷ�ӽڵ� return 0
     *      ����Ҷ�ӽڵ�Ҫ��������һ�� Ҫ���غͶ����ǿ�
     *  !null
     *      ������
     * */
}