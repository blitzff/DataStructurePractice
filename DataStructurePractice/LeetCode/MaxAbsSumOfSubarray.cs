namespace DataStructurePractice.LeetCode;

public class MaxAbsSum
{
    public int MaxAbsoluteSum(int[] nums)
    {
        // max �� min �ֱ����������С��ǰn���
        // �п����ǿգ�Sn == 0
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