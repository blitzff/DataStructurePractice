namespace DataStructurePractice.LeetCode;

/// <summary>
/// 无界背包问题
/// 0-1背包问题讨论的是当前元素选还是不选
/// 无界背包问题讨论的是当前元素选几次，要注意，在考虑dp[i-1, ...]时要考虑它存在不存在, 见①处
/// </summary>
public class CoinChangeSolution
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0) return 0;

        var m = coins.Length + 1; // 硬币种数 + 1 (0的情况)
        var n = amount + 1;
        var dp = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            dp[i, 0] = 0;
        }
        for (int i = 1; i < n; i++)
        {
            dp[0, i] = int.MaxValue;
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = int.MaxValue; // dp[i,j]在new数组时默认值为0
                for (int k = 0; j - k * coins[i - 1] >= 0; k++)
                {
                    if (dp[i - 1, j - k * coins[i - 1]] != int.MaxValue)// ①
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - k * coins[i - 1]] + k);
                    }
                }
            }
        }
        return dp[m - 1, n - 1] == int.MaxValue ? -1 : dp[m - 1, n - 1];
    }
    /*
    设 dp[i, j]代表使用前i种硬币能够凑成金额j所需的最少硬币数量
    dp[coins.Length, amount]即为所求
    第i种硬币面额是coins[i-1]
    对于第i种硬币进行分类, 可以使用[0, k], k*coins[i-1] <= j
    使用k枚当前面额, 前i-1种可以凑成余下金额
        dp[i, j] = min(dp[i-1, j-k*coins[i-1]]) + k

    讨论特殊位置
        dp[i, 0](i>=0) = 0
        dp[0, j](j>0) = -1
    */
}