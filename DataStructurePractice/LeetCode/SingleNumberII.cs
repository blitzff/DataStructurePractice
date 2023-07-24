namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/WGki4K/submissions/
/// 
/// 1 <= nums.length <= 3 * 104
/// -231 <= nums[i] <= 231 - 1
/// nums 中，除某个元素仅出现 一次 外，其余每个元素都恰出现 三次
/// </summary>
public class SingleNumberII
{
    public int SingleNumber(int[] nums)
    {
        // int 32位, 统计每一位上的和
        var bitSums = new int[32];
        foreach (var n in nums)
        {
            for (int i = 0; i < 32; i++)
            {
                bitSums[i] += ((n >> (31 - i)) & 1);
            }
        }

        // 还原不重复的数字的每一位
        var result = 0;
        for (int i = 0; i < bitSums.Length; i++)
        {
            result = (result << 1) + bitSums[i] % 3;
        }

        return result;
    }
}