namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/NYBBNL/
/// 结合单链表的反转操作
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
     * 记得每次出栈的时候处理就是中序
     * 因此, 出栈的时候进行节点的链接处理, 最后得到的就是BST的升序
     * 如何处理:
     *  上一次出栈时记录下prev节点, 然后让prev.right = cur
     *  
     * root.left = null 是有必要的, 否则 root = root.right 后又会入root.left了, 可能造成死循环.
     * */
}