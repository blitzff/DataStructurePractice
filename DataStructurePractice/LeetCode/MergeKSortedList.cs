namespace DataStructurePractice.LeetCode;

public class MergeKSortedList
{
    public ListNode MergeKLists(ListNode[] heads)
    {
        var minHeap = new PriorityQueue<ListNode, ListNode>(
            Comparer<ListNode>.Create((a, b) => a.val - b.val));
        foreach (var head in heads)
        {
            if (head != null) minHeap.Enqueue(head, head);
        }

        if (minHeap.Count <= 0) return null;

        var dummy = new ListNode();
        var cur = dummy;
        while (minHeap.Count > 0)
        {
            var node = minHeap.Dequeue();
            cur.next = node;
            cur = cur.next;

            if (node.next != null)
            {
                minHeap.Enqueue(node.next, node.next);
            }
        }
        return dummy.next;
    }

    /**
     * ֱ����һ��С����, �����нڵ�ӽ�ȥ, �ռ�̫��
     * 
     * ÿ��list�ĳ��Ȳ�һ��
     * һ��С����, �ѵĴ�С��lists.Length
     * 
     * һ��ʼֻ��ͷ�ڵ����,
     * Ȼ�󵯳���С��, ������С��֮��next���
     * ��֤������������ߵ�5��Ԫ���ڶ���.
     * */
}