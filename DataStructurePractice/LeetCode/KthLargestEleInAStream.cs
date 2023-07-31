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
     * �öѶ��ǵ�k���
     * �ѵĴ�С��k
     * Ҫ���k���ֵ, ��ô
     *  1. ʹ�ô�СΪk��С����, ��ô�Ѷ��ǵ�k���
     *  2. ÿ������ȶ�����С��ֵ��, ��ô����ֵ���, ԭֵ����, �Ѷ��Ǹ��µĵ�k���ֵ
     *  
     * ע���ʼ��ʱҲҪʹ��Add!
     * */
}