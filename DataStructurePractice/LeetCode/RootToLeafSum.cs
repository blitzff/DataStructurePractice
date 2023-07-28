namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/3Etpl5/
/// 
/// 树中节点的数目在范围 [1, 1000] 内
/// 0 <= Node.val <= 9
/// 树的深度不超过 10
/// </summary>
public class RootToLeafSum
{
    public int SumNumbers(TreeNode root)
    {
        return SumPath(root, 0);
    }

    private int SumPath(TreeNode root, int pathSum)
    {
        // 对于途中的空节点, 直接返回0
        if (root == null) return 0;

        pathSum = pathSum * 10 + root.val;
        // 如果到达叶子节点, 返回路径和
        if (root.left == null && root.right == null)
        {
            return pathSum;
        }
        // 如果是非叶子节点, 接着算
        else
        {
            var leftSum = SumPath(root.left, pathSum);
            var rightSum = SumPath(root.right, pathSum);

            return leftSum + rightSum;
        }
    }

    /**
     * 根据题意, 直接乘法不会溢出
     * 
     * 先得到第一个数, 然后得到第二个数, ..., 最后返回他们的和
     * NLR, 先序
     * 
     * 对于一个节点
     *  null 
     *      非叶子节点 return 0
     *      对于叶子节点要单独处理一下 要返回和而不是空
     *  !null
     *      接着算
     * */
}