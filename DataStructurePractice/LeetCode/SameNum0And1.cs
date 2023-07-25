namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/A1NYOS/
/// </summary>
public class SameNum0And1
{
    public int FindMaxLength(int[] nums)
    {
        var sumIndexMap = new Dictionary<int, int>()
        {
            {0, -1 }
        };
        var sum = 0;
        var max = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i] == 1 ? 1 : -1;
            if (sumIndexMap.ContainsKey(sum))
            {
                max = Math.Max(i - sumIndexMap[sum], max);
            }
            else
            {
                sumIndexMap[sum] = i;
            }
        }

        return max;
    }

    /**
     * 数组中只包含0和1, 将0转换为-1, 题目就变成求和为0的最长连续子数组的长度.
     * 
     * 为了找和为0的连续子数组, 也就是找两次和为m时之间的长度, 那么值就需要记录
     * 第一次和为m时的下标.
     * 
     * 再次遇到和为m时不更新下下标, 因为第一次遇到m到最后一次遇到m之间是最长.
     * 但是对于不同的和之间, 还是需要 Math.Max(i-index, max);
     * 
     * 仍然求前n项和, <Sn, 第一次和为m的下标>
     * 
     * 注意: 0位置的初始化!
     * */
}