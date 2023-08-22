namespace DataStructurePractice.LeetCode;

public class MaxDistanceToClosestPerson
{
    public int MaxDistToClosest(int[] seats)
    {
        var n = seats.Length;
        var dp = new int[n];
        dp[0] = Distance(seats, 0, 1);
        dp[n - 1] = Distance(seats, n - 1, -1);

        for (int i = 1; i < n-1; i++)
        {
            dp[i] = Math.Min(dp[i - 1] + 1, Distance(seats, i, 1));
        }

        return dp.Max();
    }

    private int Distance(int[] seats, int start, int step)
    {
        var j = start;
        while (j < seats.Length && seats[j] != 1)
        {
            j += step;
        }
        return Math.Abs(j - start);
    }

    /**
     * 求最优解, 每个步骤有两个方向, 能够利用上一步的解
     * 感觉可以动态规划, 试一下
     * 
     * 设 dp[i] 代表坐在第i个位置上离别人最近的最大距离的值
     * 
     * 对于 dp[i]
     * - 如果i位置上有人, 也就是seats[i] == 0, 那么dp[i] = 0
     * - 如果i位置上没人, 选择坐在i位置上
     *  - 如果左右都有人
     *      dp[i] = Math.Min(dp[i-1]+1, while(j < seats.Length && seats[j++] != 0))
     *  - 如果仅右边有人
     *      dp[0] = while(j < seats.Length && seats[j++] != 0)
     *  - 如果仅左边有人
     *      dp[n-1] = while(j < seats.Length && seats[j--] != 0)
     * */
}
