using static DataStructurePractice.LeetCode.LinkedListCycle;

namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/lMSNwu/
/// </summary>
public class AddTwoNumbersII
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var h1 = ReverseList(l1);
        var h2 = ReverseList(l2);

        var flag = 0;
        var dummy = new ListNode();
        var node = dummy;
        while (h1 != null && h2 != null)
        {
            var sum = h1.val + h2.val + flag;
            var val = (sum >= 10) ? (sum % 10) : sum;
            flag = sum >= 10 ? 1 : 0;
            node.next = new ListNode(val);
            node = node.next;
            h1 = h1.next;
            h2 = h2.next;
        }
        
        if (h2 != null) h1 = h2;

        while (h1 != null)
        {
            var sum = h1.val + flag;
            var val = (sum >= 10) ? (sum % 10) : sum;
            flag = sum >= 10 ? 1 : 0;
            node.next = new ListNode(val);
            node = node.next;
            h1 = h1.next;
        }

        if (flag != 0)
        {
            node.next = new ListNode(1);
        }
        return ReverseList(dummy.next);
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
     * ��β����ʼ���, ���ǽ�λ, ��ת����(������ջ)
     * 
     * ע��:
     *  1. ���ʣ�µĽ�λҪ�½��ڵ�
     *  2. ���Ľ��Ҫ�ٴη�ת
     * */
}