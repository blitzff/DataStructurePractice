namespace DataStructurePractice.LeetCode;

public class Solution
{
	public int[] FullBloomFlowers(int[][] periods, int[] days)
	{
		// 花期按开始时间升序排序
		Array.Sort(periods, (x, y) => x[0] - y[0]);

		// 访问日期按日期大小升序排序
		//Array.Sort(days);
		// 用优先级队列按天数作为优先级保存索引从而在记录结果时更新到days的索引对应的位置上.
		// 还有一种方式是将days的值和索引装进一个Node里, 然后按值排序Node, 直接访问引用就可以了.
		var daysHeap = new PriorityQueue<int, int>();
		for (int i = 0; i < days.Length; i++)
		{
			daysHeap.Enqueue(i, days[i]);
		}

		var answers = new int[days.Length];

		// 记录结束花期, 全局, 因为开始时间按升序排序了, 因此 s2 > s1, 又s1 > periods[1][0], 所以s2 > periods[1][0]
		// 那么只要s2 <= e1, 那么也是符合s2的结果, 因此堆里包含对上一次的观看日进行筛选时的花期
		var ends = new PriorityQueue<int, int>();
		var pindex = 0;
		while (daysHeap.Count > 0)
		{
			var dayIndex = daysHeap.Dequeue();
			var visitday = days[dayIndex]; // 最小的那天
			for (; pindex < periods.Length; pindex++) // 遍历一遍periods
			{
				var startPeriod = periods[pindex][0];
				var endPeriod = periods[pindex][1];
				if (startPeriod <= visitday) // 最小的天数 >= 花期的开始时间, 将花期的结束时间入一个小根堆
					ends.Enqueue(endPeriod, endPeriod);
				else
					break;
			}

			while (ends.Count > 0) // 小根堆, 堆顶是最小的结束花期, 堆里剩下的都是比visitday大的
			{
				var endflower = ends.Peek();
				if (visitday <= endflower) // 最小的都比visitday大, 因此剩下的都满足
					break;
				else
					ends.Dequeue();
			}
			answers[dayIndex] = ends.Count;
		}

		return answers;
	}
}
