namespace DataStructurePractice.LeetCode;

public class MaxAfterKOps
{
    public long MaxKelements(int[] nums, int k)
    {
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        for (int i = 0; i < nums.Length; i++)
        {
            maxHeap.Enqueue(nums[i], nums[i]);
        }

        var score = 0l;
        for (var i = 0; i < k; i++)
        {
            var max = maxHeap.Dequeue();
            score += max;
            var newNum = (int)Math.Ceiling((double)max / 3);
            maxHeap.Enqueue(newNum, newNum);
        }
        return score;
    }

}
