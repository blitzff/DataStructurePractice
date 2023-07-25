namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/c32eOV/
/// </summary>
public class LinkedListCycle
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

    public ListNode DetectCycle(ListNode head)
    {
        if (head == null) return head;

        var dummy = new ListNode();
        dummy.next = head;

        var fast = dummy;
        var slow = dummy;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
            if (slow == fast) break;
        }

        if (fast == null || fast.next == null)
        {
            return null;
        }

        fast = dummy;
        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }
        return slow;
    }
}