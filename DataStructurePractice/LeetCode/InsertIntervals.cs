using System;

namespace DataStructurePractice.LeetCode;

[TestClass]
public class InsertIntervals
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        int left = newInterval[0];
        int right = newInterval[1];
        var placed = false;
        var ansList = new List<int[]>();
        // 只考虑目标和当前区间， 和当前区间无交集，将当前区间加入结果
        // 和当前区间有交集， 更新目标区间
        foreach (int[] interval in intervals)
        {
            // 在插入区间的右侧且无交集
            if (interval[0] > right)
            {
                if (!placed) // 在开头
                {
                    ansList.Add(new int[] { left, right });
                    placed = true;
                }
                ansList.Add(interval);
            }
            else if (interval[1] < left)
            {
                // 在插入区间的左侧且无交集
                ansList.Add(interval);
            }
            else
            {
                // 与插入区间有交集，计算它们的并集
                left = Math.Min(left, interval[0]);
                right = Math.Max(right, interval[1]);
            }
        }
        // 在末尾
        if (!placed)
        {
            ansList.Add(new int[] { left, right });
        }

        return ansList.ToArray();
    }

    [TestMethod]
    public void test()
    {
        new InsertIntervals().Insert(new int[][]
        {
            new int[] { 1,2 },
            new int[] { 3,5 },
            new int[] { 6,7 },
            new int[] { 8,10 },
            new int[] { 12,16 }
        }, 
        new int[] { 4, 8 });
    }
}
