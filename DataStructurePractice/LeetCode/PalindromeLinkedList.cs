using static DataStructurePractice.LeetCode.LinkedListCycle;

namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/aMhZSa/
/// </summary>
public class PalindromeLinkedlist
{
    public bool IsPalindrome(ListNode head)
    {
        var dummy = new ListNode(-1, head);
        var slow = dummy;
        var fast = dummy;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        var rightH = slow.next;
        slow.next = null;
        rightH = RevereseList(rightH);

        while (head != null && rightH != null)
        {
            if (head.val != rightH.val)
            {
                return false;
            }
            head = head.next;
            rightH = rightH.next;
        }
        return true;
    }

    private ListNode RevereseList(ListNode head)
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
     * 1. 快慢指针找到中间节点
     * 2. 断开左后两半
     * 3. 反转后半部分链表
     * 4. 对比两半部分节点的值判断是否回文
     * 
     * 一次通过~
     * */
}