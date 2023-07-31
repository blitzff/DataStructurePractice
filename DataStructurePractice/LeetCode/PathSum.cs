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
        // 叶子节点
        if (root.left == null && root.right == null) 
        {
            return pathSum == targetSum;
        }

        var left = HasTargetSum(root.left, pathSum, targetSum );
        var right = HasTargetSum(root.right, pathSum, targetSum );

        return left || right;
    }

    /**
     * 到叶子节点的和, NLR先序遍历, pathSum在参数中一层层带下去
     * 到叶子节点判断是否pathSum == targetSum, 
     * 怎么返回?
     * 返回左树或右树"是否有符合条件的pathSum"这件事.
     * */
}