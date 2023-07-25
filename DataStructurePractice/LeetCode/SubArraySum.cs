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
            // Ϊ����S_sum��S_(sum-k)��ֵһ��, ����S_sum�ĸ���Ҫ�������.
            sumCountMap[sum] = sumCountMap.GetValueOrDefault(sum, 0) + 1;
        }

        return count;
    }

    /**
     * ��������������ĺͲ��ǵ�����, ����޷�ʹ��˫ָ�뷨.
     * 
     * ͳ��ǰn���, ͳ�ƹ����м��� Sn-k ��n֮ǰ���ֹ�����,
     * ����ζ���м�����nλ�ú�Ϊk������������, ������������
     * ��ĸ���.
     * 
     * ��Ҫһ����ϣ��, <Sn, Count_Sn>
     * */
}