namespace DataStructurePractice.LeetCode;

public class BSTToGreaterSumTree
{
    public TreeNode ConvertBST(TreeNode cur)
    {
        if (cur == null) return cur;

        var root = cur;
        var sum = 0;
        var stack = new Stack<TreeNode>();
        while (stack.Count > 0 || cur != null)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.right;
            }
            else
            {
                cur = stack.Pop();

                sum += cur.val;
                cur.val = sum;

                cur = cur.left;
            }
        }
        return root;
    }

    /**
     * ˼·1: S��-Sn�õ��ӵ�ǰλ�õ�ĩβ�����д�������ֵ�ĺ�
     * ˼·2: �����������, �ȱ�����Ľڵ�
     * */
}