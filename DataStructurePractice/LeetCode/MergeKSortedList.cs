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
     * 直接用一个小根堆, 把所有节点加进去, 空间太大
     * 
     * 每个list的长度不一样
     * 一个小根堆, 堆的大小是lists.Length
     * 
     * 一开始只有头节点入堆,
     * 然后弹出最小的, 弹出最小的之后next入堆
     * 保证堆里总是最左边的5个元素在堆里.
     * */
}