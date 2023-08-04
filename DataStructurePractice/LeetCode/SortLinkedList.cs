namespace DataStructurePractice.LeetCode;

public class SortLinkedList
{
    public ListNode SortList(ListNode head)
    {
        return Separate(head);
    }

    public ListNode Separate(ListNode head)
    {
        // 如果为null或只有1个节点就不继续分了
        if (head == null || head.next == null) return head;

        var head1 = head;
        var head2 = Split(head);
        head1 = Separate(head1); // 在Seperate过程中包含Merge, 
        // Merge完后的head1不一定是原来的head1
        head2 = Separate(head2);
        // 返回的是head1, head2合并完之后的总的头节点
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
        slow.next = null; // 断开使成为两条链
        return second;
    }

    private ListNode Merge(ListNode h1, ListNode h2)
    { // 此刻已经是两条链表， 在Split中断开的
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
        // 仍有剩余元素的，直接接到cur后面
        cur.next = h1 == null ? h2 : h1;
        return dummy.next;
    }
}