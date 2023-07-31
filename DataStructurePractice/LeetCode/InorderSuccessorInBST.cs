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
     * ˼·1: �������, ����ռ��¼
     * ˼·2: ����BST, һ��ֵ�������������б������ֵ����С��, ����BST������
     * */
}