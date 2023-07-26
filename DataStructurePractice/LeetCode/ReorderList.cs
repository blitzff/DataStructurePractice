using static DataStructurePractice.LeetCode.LinkedListCycle;

namespace DataStructurePractice.LeetCode;

public class ReorderListSolution
{
    public void ReorderList(ListNode head)
    {
        var dummy = new ListNode(-1, head);
        var slow = dummy;
        var fast = dummy;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        var rightHead = slow.next;
        slow.next = null;
        rightHead = ReverseList(rightHead);

        while (head != null && rightHead != null)
        {
            var lnext = head.next;
            var rnext = rightHead.next;

            head.next = rightHead;
            rightHead.next = lnext;

            head = lnext;
            rightHead = rnext;
        }
    }

    private ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode cur = head;
        while (cur != null)
        {
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }
        return prev;
    }

    /**
     * 1. ����ָ���ҵ��м�ڵ�
     * 2. �Ͽ�ǰ������, ��ת����һ������
     * 3. ����������ƴ��
     * 
     * һ��ͨ��, ţ��. 
     * ��żҪ����.
     * */
}