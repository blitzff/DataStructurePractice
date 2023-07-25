namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/tvdfij/
/// </summary>
public class LeftRightSum
{
    public int PivotIndex(int[] nums)
    {
        var totalSum = nums.Sum();

        var sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (sum - nums[i] == totalSum - sum)
            {
                return i;
            }
        }
        
        return -1;
    }

    /**
     * 法一: 暴力解法 注意边界 O(N^2)
     * 
     * 法二: 前n项和, O(N)
     *  S[0,i-1] = S[i] - i
     *  S[i+1,N] = total - S[i]
     * */
}