namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/3u1WK4/
/// </summary>
public class IntersectionOfTwoLinkedList
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null) return null;

        var lenA = CountList(headA);
        var lenB = CountList(headB);

        var longHead = lenA > lenB ? headA : headB;
        var shortHead = longHead == headA ? headB : headA;

        var n = Math.Abs(lenA - lenB);
        for (int i = 0; i < n; i++)
        {
            longHead = longHead.next;
        }

        while (longHead != shortHead)
        {
            longHead = longHead.next;
            shortHead = shortHead.next;
        }
        return longHead;
    }

    private int CountList(ListNode head)
    {
        var count = 0;
        while (head != null)
        {
            count++;
            head = head.next;
        }
        return count;
    }

    /**
     * ��ͳ����������ĳ���, ��Ϊn
     * Ȼ����������n��, ����֮ǰ��һ����Ƚڵ㼴Ϊ����, ���û��
     * ��ô�������ཻ.
     * */

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val)
        {
            this.val = val;
        }
    }
}