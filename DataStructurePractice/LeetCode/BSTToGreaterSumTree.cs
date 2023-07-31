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
     * 思路1: S总-Sn得到从当前位置到末尾的所有大于它的值的和
     * 思路2: 镜像中序遍历, 先遍历大的节点
     * */
}