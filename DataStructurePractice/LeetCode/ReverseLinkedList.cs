using static DataStructurePractice.LeetCode.LinkedListCycle;

namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/UHnkqh/
/// </summary>
public class ReverseLinkedList
{
    public ListNode ReverseList(ListNode head)
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
     * ��Ҫ3��ָ��, prev cur next
     * ����cur, ����prev, �ֳ���cur.next
     * */
}