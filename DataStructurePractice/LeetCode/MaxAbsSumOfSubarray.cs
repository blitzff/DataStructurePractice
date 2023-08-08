namespace DataStructurePractice.LeetCode;

public class MaxAbsSum
{
    public int MaxAbsoluteSum(int[] nums)
    {
        // max 和 min 分别代表最大和最小的前n项和
        // 有可能是空，Sn == 0
        var max = 0;
        var min = 0;

        var sum = 0;
        foreach (var n in nums)
        {
            sum += n;
            max = Math.Max(max, sum);
            min = Math.Min(min, sum);
        }

        return max - min;
    }
}