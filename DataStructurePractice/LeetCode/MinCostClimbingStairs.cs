namespace DataStructurePractice.LeetCode;

public class MinCostClimbingStairsSolution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var f = new int[cost.Length];
        f[0] = cost[0];
        f[1] = cost[1];
        for (int i = 2; i < cost.Length; i++)
        {
            f[i] = cost[i] + Math.Min(f[i - 1], f[i - 2]);
        }
        return Math.Min( f[f.Length - 1], f[f.Length-2]);

    }

    // return Math.Min(f(0, cost), f(1, cost));
    private int f(int i, int[] cost)
    {
        if (i >= cost.Length) return 0;
        return cost[i] + Math.Min(f(i + 1, cost), f(i + 2, cost));
    }
}
