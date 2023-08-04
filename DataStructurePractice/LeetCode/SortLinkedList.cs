namespace DataStructurePractice.LeetCode;

public class SortLinkedList
{
    public ListNode SortList(ListNode head)
    {
        return Separate(head);
    }

    public ListNode Separate(ListNode head)
    {
        // ���Ϊnull��ֻ��1���ڵ�Ͳ���������
        if (head == null || head.next == null) return head;

        var head1 = head;
        var head2 = Split(head);
        head1 = Separate(head1); // ��Seperate�����а���Merge, 
        // Merge����head1��һ����ԭ����head1
        head2 = Separate(head2);
        // ���ص���head1, head2�ϲ���֮����ܵ�ͷ�ڵ�
        return Merge(head1, head2);
    }

    private ListNode Split(ListNode head)
    {
        var dummy = new ListNode(-1, head);
        var slow = dummy;
        var fast = dummy;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        var second = slow.next;
        slow.next = null; // �Ͽ�ʹ��Ϊ������
        return second;
    }

    private ListNode Merge(ListNode h1, ListNode h2)
    { // �˿��Ѿ����������� ��Split�жϿ���
        var dummy = new ListNode();
        var cur = dummy;
        while (h1 != null && h2 != null)
        {
            if (h1.val < h2.val)
            {
                cur.next = h1;
                h1 = h1.next;
            }
            else
            {
                cur.next = h2;
                h2 = h2.next;
            }
            cur = cur.next;
        }
        // ����ʣ��Ԫ�صģ�ֱ�ӽӵ�cur����
        cur.next = h1 == null ? h2 : h1;
        return dummy.next;
    }
}