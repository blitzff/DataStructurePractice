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
     * ��Ҷ�ӽڵ㿪ʼ��, Ҷ�ӽڵ�Ϊ0���Լ�
     * �ܲ������ַ���, �ӵײ���ʼ��, ��������֮��, �����Ҳ��Ҷ�ӽڵ���
     * => ����ʵ���ɵ�Ч���� LRN, �������!
     * 
     * ��ôɾ��һ���ڵ�?
     * return null
     * */
}