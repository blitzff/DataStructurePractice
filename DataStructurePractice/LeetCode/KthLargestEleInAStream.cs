namespace DataStructurePractice.LeetCode;

public class KthLargest
{
    private readonly int k;
    private PriorityQueue<int, int> heap;

    public KthLargest(int k, int[] nums)
    {
        this.k = k;

        heap = new PriorityQueue<int, int>(k);
        foreach (var n in nums)
        {
            Add(n);
        }
    }

    public int Add(int val)
    {
        if (heap.Count < k)
        {
            heap.Enqueue(val, val);
        }
        else if (val > heap.Peek())
        {
            heap.Dequeue();
            heap.Enqueue(val, val);
        }

        return heap.Peek();
    }

    /**
     * 让堆顶是第k大的
     * 堆的大小是k
     * 要求第k大的值, 那么
     *  1. 使用大小为k的小顶堆, 那么堆顶是第k大的
     *  2. 每次如果比堆里最小的值大, 那么让新值入堆, 原值出堆, 堆顶是个新的第k大的值
     *  
     * 注意初始化时也要使用Add!
     * */
}