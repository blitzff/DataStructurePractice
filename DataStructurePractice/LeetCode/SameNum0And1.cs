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
     * ������ֻ����0��1, ��0ת��Ϊ-1, ��Ŀ�ͱ�����Ϊ0�������������ĳ���.
     * 
     * Ϊ���Һ�Ϊ0������������, Ҳ���������κ�Ϊmʱ֮��ĳ���, ��ôֵ����Ҫ��¼
     * ��һ�κ�Ϊmʱ���±�.
     * 
     * �ٴ�������Ϊmʱ���������±�, ��Ϊ��һ������m�����һ������m֮�����.
     * ���Ƕ��ڲ�ͬ�ĺ�֮��, ������Ҫ Math.Max(i-index, max);
     * 
     * ��Ȼ��ǰn���, <Sn, ��һ�κ�Ϊm���±�>
     * 
     * ע��: 0λ�õĳ�ʼ��!
     * */
}