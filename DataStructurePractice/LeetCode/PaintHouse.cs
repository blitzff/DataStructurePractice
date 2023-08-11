namespace DataStructurePractice.LeetCode;

public class PaintHouse
{
    private int[][] costs;
    private int min = int.MaxValue;
    public int MinCost(int[][] costs)
    {
        var n = costs.Length;
        var f = new int[n, 3];
        for (int i = 0; i < 3; i++)
        {
            f[0, i] = costs[0][i];
        }
        for (int i = 1; i < n; i++)
        {
            f[i,0] = costs[i][0] + Math.Min(f[i - 1,1], f[i - 1,2]);
            f[i,1] = costs[i][1] + Math.Min(f[i - 1,0], f[i - 1,2]);
            f[i,2] = costs[i][2] + Math.Min(f[i - 1,1], f[i - 1,0]);
        }
        for (int i = 0; i < 3; i++)
        {
            min = Math.Min(min, f[n - 1, i]);
        }
        return min;
    }


    /**
     * 怎么写转移方程；
     * n*3的数组f代表i位置上的房子涂颜色c的前i间房的最小花费
     * 转移方程：
     *  f[i][c] = costs[i][c] + Math.Min({f[i-1][d], d \in [0, 2], d != c}), i > 0
     *  f[0][c] = costs[0][c]
     * */

    private void f(int i, int color, int totalCost)
    {
        if (i == costs.Length)
        {
            min = Math.Min(totalCost, min);
        }
        else if (i < costs.Length)
        {
            var curCost = costs[i][color];
            totalCost += curCost;
            // 当前使用一个颜色后，下一个位置使用另外两种颜色
            for (int c = 0; c < costs[i].Length; c++)
            {
                if (c == color) continue;
                f(i + 1, c, totalCost);
            }
        }
    }

    /**
     * 求最少成本花费，所以动态规划
     * 
     * 在每一步有三种选择，costs[i][0], costs[i][1], costs[i][2]
     * 且相邻两个颜色不能相同
     * 
     * 回溯法，一个变量记录（但因为int是值传递因此无需显式回溯）
     * 
     * 设f(n)代表前n个房子的最少花费
     * */
}
