namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/maximum-depth-of-binary-tree/submissions/
/// </summary>
public class MaxDepthOfBinaryTree
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        var left = MaxDepth(root.left);
        var right = MaxDepth(root.right);
        return 1 + Math.Max(left, right);
    }

    /**
     * 希望子树给我子树的最大深度, 然后加上当前节点, 返回.
     * 那就是先子树再根节点, 后序遍历.
     * */
}