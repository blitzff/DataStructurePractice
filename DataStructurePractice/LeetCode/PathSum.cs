namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/path-sum/
/// </summary>
public class PathSum
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        return HasTargetSum(root, 0, targetSum);
    }

    private bool HasTargetSum(TreeNode root, int pathSum, int targetSum)
    {
        if (root == null) return false;

        pathSum += root.val;
        // Ҷ�ӽڵ�
        if (root.left == null && root.right == null) 
        {
            return pathSum == targetSum;
        }

        var left = HasTargetSum(root.left, pathSum, targetSum );
        var right = HasTargetSum(root.right, pathSum, targetSum );

        return left || right;
    }

    /**
     * ��Ҷ�ӽڵ�ĺ�, NLR�������, pathSum�ڲ�����һ������ȥ
     * ��Ҷ�ӽڵ��ж��Ƿ�pathSum == targetSum, 
     * ��ô����?
     * ��������������"�Ƿ��з���������pathSum"�����.
     * */
}