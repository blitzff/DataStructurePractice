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
     * ϣ����������������������, Ȼ����ϵ�ǰ�ڵ�, ����.
     * �Ǿ����������ٸ��ڵ�, �������.
     * */
}