namespace DataStructurePractice.LeetCode;

public class RobSolution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        var f = new int[nums.Length];
        f[0] = nums[0];
        f[1] = Math.Max(nums[0], nums[1]); ;
        for (int i = 2; i < nums.Length; i++)
        {
            f[i] = Math.Max(f[i-1], f[i - 2] + nums[i]);
        }
        return Math.Max(f[f.Length - 1], f[f.Length - 2]);
    }

    /// <summary>
    /// 递归是从前往后，0, 0+2, 0+1
    /// 动态规划是从后往前, f(i) = Math.Max(f[i-1], f[i-2]+nums[i]);
    /// </summary>
    /// <param name="i"></param>
    /// <param name="nums"></param>
    /// <returns></returns>
    private int f(int i, int[] nums)
    {
        if (i >= nums.Length) return 0;

        // 偷当前的
        var m1 = nums[i] + f(i + 2, nums);
        // 不偷当前的
        var m2 = f(i+1, nums);

        return Math.Max(m1, m2);
    }
}
