namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/6eUYwP/
/// 二叉树的节点个数的范围是 [0,1000]
/// -109 <= Node.val <= 109 
/// -1000 <= targetSum <= 1000 
/// </summary>
public class PathSumIII
{
    public int PathSum(TreeNode root, int targetSum)
    {
        var map = new Dictionary<int, int>() { { 0, 1 } };

        return FindRes(root, targetSum, map, 0);
    }

    /// <summary>
    /// 遍历过程中统计前n项和, 计算pathSum-targetSum出现的次数
    /// </summary>
    /// <param name="root"></param>
    /// <param name="targetSum"></param>
    /// <param name="map"></param>
    /// <param name="pathSum"></param>
    /// <returns></returns>
    private int FindRes(TreeNode root, int targetSum, Dictionary<int, int> map, int pathSum)
    {
        if (root == null) return 0;

        pathSum += root.val;
        // 从根节点开始到哪儿的和是pathSum-targetSum, 也就是从哪儿到当前节点的和是targetSum
        // 计算这个数量
        var count = map.GetValueOrDefault(pathSum - targetSum, 0);
        // 进入这棵子树的时候, 当前节点属于前n项和的一部分.
        map[pathSum] = map.GetValueOrDefault(pathSum, 0) + 1;

        count += FindRes(root.left, targetSum, map, pathSum);
        count += FindRes(root.right, targetSum, map, pathSum);

        // 离开这棵子树的时候, 当前节点不属于前n项和了.
        map[pathSum] -= 1;

        return count;
    }
}