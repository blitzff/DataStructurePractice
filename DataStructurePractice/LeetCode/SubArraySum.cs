namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/QTMn0o/
/// </summary>
public class SubarraySumSolution
{
    public int SubarraySum(int[] arr, int k)
    {
        var count = 0;
        var sumCountMap = new Dictionary<int, int>()
        {
            { 0, 1 }
        };
        var sum = 0;

        foreach (var n in arr)
        {
            sum += n;
            count += sumCountMap.GetValueOrDefault(sum - k, 0);
            // 为避免S_sum和S_(sum-k)的值一样, 对于S_sum的更新要放在最后.
            sumCountMap[sum] = sumCountMap.GetValueOrDefault(sum, 0) + 1;
        }

        return count;
    }

    /**
     * 由于连续子数组的和不是单调的, 因此无法使用双指针法.
     * 
     * 统计前n项和, 统计过程中计算 Sn-k 在n之前出现过几次,
     * 就意味着有几个到n位置和为k的连续子数组, 返回连续子数
     * 组的个数.
     * 
     * 需要一个哈希表, <Sn, Count_Sn>
     * */
}