namespace DataStructurePractice.LeetCode;

public class PartitionEqualSubsetSum
{
    public bool CanPartition(int[] nums)
    {
        var sum = nums.Sum();
        if (sum % 2 != 0) return false;

        var t = sum / 2 + 1;
        var n = nums.Length + 1;
        var dp = new bool[t, n];
        dp[0, 0] = false;
        for (int i = 1; i < t; i++)
        {
            dp[i, 0] = false;
        }
        for (int j = 1 ; j < n; j++)
        {
            dp[0, j] = true;
        }
        for (int i = 1; i < t; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = dp[i, j - 1];
                if (!dp[i, j] && i - nums[j-1] >= 0)
                {
                    dp[i, j] = dp[i - nums[j-1], j - 1];
                }
            }
        }
        return dp[t - 1, n - 1];
    }
    /**
     * 对于一个元素, 有两种情况, 选/不选
     * 因此是一个0-1背包问题
     * 背包的大小是sum/2 (如果是奇数那么不满足), 记为t
     * 行 [0, t], 共t+1行 代表背包大小
     * 列 [-1, nums.Length-1] => [0, nums.Length], 共nums.Length+1个, 1位置代表nums[0], nums[j-1]
     * dp[i, j]代表前j个元素是否满足和为i
     * 对于普遍的[i, j]位置, 有当前位置放入背包或当前位置不放入背包这两种情况:
     * 1. 放入背包, 那么 前j个元素能否满足和为i 如果前j-1个元素能够满足和为i-nums[j-1]
     *  那么当前位置放入背包能够满足题意
     *      dp[i, j] = dp[i-nums[j-1], j-1]
     * 2. 不放入背包, 那么 前j个元素能否满足和为i 如果前j-1个元素能够满足和为i
     *  那么当前不放入能够满足题意
     *      dp[i, j] = dp[i, j-1]
     * 
     * 考虑特殊位置
     *  dp[0, j] = true 背包大小为0, 不选即可
     *  dp[i, 0] = false 选0个元素, 不满足, 
     *  dp[0, 0] = false
     * */
}
