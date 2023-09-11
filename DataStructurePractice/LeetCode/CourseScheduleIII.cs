namespace DataStructurePractice.LeetCode;

public class CourseScheduleIII
{
    public int ScheduleCourse(int[][] courses)
    {
        Array.Sort(courses, Comparer<int[]>.Create((a, b) => a[1] - b[1]));

        var durationsQueue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        var total = 0;

        foreach (var course in courses)
        {
            var duration = course[0];
            var stop = course[1];
            if (duration + total <= stop)
            {
                total += duration;
                durationsQueue.Enqueue(duration, duration);
            }
            else if (durationsQueue.Count > 0 && durationsQueue.Peek() > duration) // 如果超了就换个更小的, 如果再超了那下轮再换
            {
                var durationx = durationsQueue.Dequeue();
                total = total - durationx + duration;
                durationsQueue.Enqueue(duration, duration);
            }
        }
        return durationsQueue.Count;
    }
    /**
     * 时长, 截止时间
     * 首先按照截止时间排序
     * 贪心: 优先选择最小的截止时间的课程
     * 如果当前duration + total <= stop:
     *  queue.Enqueue(duration);
     * 如果当前duration + total > stop && queue.Peek() > duration: // 选择持续时间最短的课程
     *  var durationx = queue.Dequeue();
     *  queue.Enqueue(duration);
     */
}
