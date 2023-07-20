namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/single-number/
/// 
/// 1 <= nums.length <= 3 * 104
/// -3 * 104 <= nums[i] <= 3 * 104
/// 除了某个元素只出现一次以外，其余每个元素均出现两次。
/// </summary>
public class SingleNumberI
{
    public int SingleNumbers(int[] nums)
    {
        var result = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            result = result ^ nums[i];
        }
        return result;
    }
}