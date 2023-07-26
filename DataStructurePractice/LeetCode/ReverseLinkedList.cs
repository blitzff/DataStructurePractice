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
     * 需要3个指针, prev cur next
     * 遍历cur, 保存prev, 现场算cur.next
     * */
}