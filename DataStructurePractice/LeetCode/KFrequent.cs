namespace DataStructurePractice.LeetCode;

public class KFrequent
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        // ͳ�ƴ���
        var hash = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            hash[n] = hash.GetValueOrDefault(n, 0) + 1;
        }
        // ����������
        var heap = new PriorityQueue<int, int>(k);
        foreach (var key in hash.Keys)
        {
            if (heap.Count < k)
            {
                heap.Enqueue(key, hash[key]);
            }
            else if (hash[key] > hash[heap.Peek()]) // *
            {
                heap.Dequeue();
                heap.Enqueue(key, hash[key]);
            }
        }

        var res = new int[k];
        for (int i = 0; i < k; i++)
        {
            res[i] = heap.Dequeue();
        }

        return res;
    }

    /**
     * ע��Ƚϵ��ǳ��ִ���.
     * */
}