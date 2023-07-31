namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/NYBBNL/
/// ��ϵ�����ķ�ת����
/// </summary>
public class IncreasingOrderSearchTree
{
    public TreeNode IncreasingBST(TreeNode root)
    {
        TreeNode first = null;
        TreeNode prev = null;

        var stack = new Stack<TreeNode>();
        while (stack.Count > 0 || root != null)
        {
            if (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            else
            {
                root = stack.Pop();
                if (prev == null)
                {
                    first = root;
                }
                else
                {
                    prev.right = root;
                }

                prev = root;
                root.left = null;
                root = root.right;
            }
        }
        return first;
    }

    /**
     * �ǵ�ÿ�γ�ջ��ʱ�����������
     * ���, ��ջ��ʱ����нڵ�����Ӵ���, ���õ��ľ���BST������
     * ��δ���:
     *  ��һ�γ�ջʱ��¼��prev�ڵ�, Ȼ����prev.right = cur
     *  
     * root.left = null ���б�Ҫ��, ���� root = root.right ���ֻ���root.left��, ���������ѭ��.
     * */
}