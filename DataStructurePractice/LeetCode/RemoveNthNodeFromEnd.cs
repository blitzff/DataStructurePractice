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
     * �����н�����ĿΪ sz
     * 1 <= sz <= 30
     * 0 <= Node.val <= 100
     * 1 <= n <= sz
     * 
     * ɾ��һ���ڵ�node.next�ķ�ʽ�� node.next = node.next.next
     * Ϊ�˱���node.next.next�ķ���Ϊ��, ��Ҫһ��dummyHead
     * 
     * 1 <= n <= sz, ���迼��n�ķ�Χ����
     * 
     * ������������ָ��һ��ʼ����dummy, Ȼ�󻭸����front, endָ��
     * ����ʼλ�� ��ֹλ��, �Լ���ֹλ�ú�n�Ĺ�ϵ, ��ó�
     *  
     *  ��front����n+1��
     *  
     * Ȼ��front��nullλ��ʱ, back�ڵ�����n+1���ڵ���.
     * 
     * */
}