namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/P5rCT8/
/// </summary>
public class InorderSuccessorInBST
{
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        TreeNode res = null;
        while (root != null)
        {
            if (root.val > p.val)
            {
                res = root;
                root = root.left;
            }
            else
            {
                root = root.right;
            }
        }
        return res;
    }
    
    /**
     * 思路1: 中序遍历, 额外空间记录
     * 思路2: 对于BST, 一个值的中序后继是所有比它大的值中最小的, 利用BST的性质
     * */
}