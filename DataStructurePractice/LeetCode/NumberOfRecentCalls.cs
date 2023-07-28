namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/H8086Q/
/// </summary>
public class RecentCounter
{
    private Queue<int> counterQueue = new();

    public RecentCounter()
    {

    }

    public int Ping(int t)
    {
        counterQueue.Enqueue(t);
        while (counterQueue.Count > 0
            && counterQueue.Peek() < t-3000)
        {
            counterQueue.Dequeue();
        }
        return counterQueue.Count;
    }
}