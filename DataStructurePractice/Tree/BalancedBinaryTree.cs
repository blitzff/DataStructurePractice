namespace DataStructurePractice.Tree;

/// <summary>
/// 检查是否是平衡二叉树:
/// 1. 任何节点的左右子树的高度差不超过1
/// 2. 左树也是平衡二叉树
/// 3. 右数也是平衡二叉树
/// https://leetcode.cn/problems/ping-heng-er-cha-shu-lcof/submissions/477204603/
/// </summary>
public class BalancedBinaryTree
{
    public static bool IsBalanced<T>(TreeNode<T> root)
    {
        return IsBalancedInner(root).isBalanced;
    }

    private static Info IsBalancedInner<T>(TreeNode<T> root)
    {
        if (root == null)
        {
            return new Info()
            {
                isBalanced = true,
                height = 0,
            };
        }

        var leftInfo = IsBalancedInner(root.Left);
        var rightInfo = IsBalancedInner(root.Right);

        var info = new Info()
        {
            isBalanced = leftInfo.isBalanced && 
                        rightInfo.isBalanced &&
                        Math.Abs(leftInfo.height - rightInfo.height) < 2,
            height = Math.Max(leftInfo.height, rightInfo.height) + 1,
        };

        return info;
    }

    class Info
    {
        public bool isBalanced;
        public int height;
    }
}
