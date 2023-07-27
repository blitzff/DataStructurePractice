namespace DataStructurePractice.LeetCode;

public class MovingAverage
{
    private readonly int maxSize;
    private Queue<int> queue;

	public MovingAverage(int maxSize)
	{
		queue = new Queue<int>(maxSize);
        this.maxSize = maxSize;
    }

	public double Next(int val)
	{
		if (queue.Count == maxSize)
		{
			queue.Dequeue();
        }
        queue.Enqueue(val);
        return queue.Average();
	}
}