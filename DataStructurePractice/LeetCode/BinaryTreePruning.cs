namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/pOCWxh/
/// </summary>
public class BinaryTreePruning
{
    public TreeNode PruneTree(TreeNode root)
    {
        if (root == null) return null;

        root.left = PruneTree(root.left);
        root.right = PruneTree(root.right);
        if (root.left == null && root.right == null && root.val == 0)
        {
            return null;
        }

        return root;
    }

    /**
     * 从叶子节点开始剪, 叶子节点为0可以剪
     * 能不能有种方法, 从底部开始剪, 这样剪完之后, 上面的也是叶子节点了
     * => 这其实想达成的效果是 LRN, 后序遍历!
     * 
     * 怎么删除一个节点?
     * return null
     * */
}