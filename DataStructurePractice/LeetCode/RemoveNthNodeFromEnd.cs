namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/SLwz0R/
/// </summary>
public class RemoveNthNodeFromeEndOfList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(
            int val = 0,
            ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var dummy = new ListNode(0, head);
        var back = dummy;
        var front = dummy;
        for (int i = 0; i <= n; i++)
        {
            front = front.next;
        }

        while (front != null)
        {
            back = back.next;
            front = front.next;
        }

        back.next = back.next.next;
        return dummy.next;
    }

    /**
     * 链表中结点的数目为 sz
     * 1 <= sz <= 30
     * 0 <= Node.val <= 100
     * 1 <= n <= sz
     * 
     * 删除一个节点node.next的方式是 node.next = node.next.next
     * 为了避免node.next.next的访问为空, 需要一个dummyHead
     * 
     * 1 <= n <= sz, 无需考虑n的范围问题
     * 
     * 无脑设置两个指针一开始都在dummy, 然后画个表格看front, end指针
     * 的起始位置 终止位置, 以及终止位置和n的关系, 后得出
     *  
     *  让front先走n+1步
     *  
     * 然后当front在null位置时, back在倒数第n+1个节点上.
     * 
     * */
}