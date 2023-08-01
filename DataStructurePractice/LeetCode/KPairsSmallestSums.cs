namespace DataStructurePractice.LeetCode;

[TestClass]
public class KPairsSmallestSums
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var maxHeap = new PriorityQueue<List<int>, int>(
            Comparer<int>.Create((x, y) => y - x));

        for (int i = 0; i < Math.Min(nums1.Length, k); i++)
        {
            for (int j = 0; j < Math.Min(nums2.Length, k); j++)
            {
                var list = new List<int>() { nums1[i], nums2[j] };
                if (maxHeap.Count < k)
                {
                    maxHeap.Enqueue(list, list.Sum());
                }
                else if (maxHeap.Peek().Sum() > list.Sum())
                {
                    maxHeap.Dequeue();
                    maxHeap.Enqueue(list, list.Sum());
                }
            }
        }

        var res = new List<IList<int>>();
        while (maxHeap.Count > 0)
        {
            var list = maxHeap.Dequeue();
            res.Add(list);
        }
        return res;
    }
}