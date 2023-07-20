namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/WGki4K/submissions/
/// 
/// 1 <= nums.length <= 3 * 104
/// -231 <= nums[i] <= 231 - 1
/// nums �У���ĳ��Ԫ�ؽ����� һ�� �⣬����ÿ��Ԫ�ض�ǡ���� ����
/// </summary>
public class SingleNumberII
{
    public int SingleNumber(int[] nums)
    {
        // int 32λ, ͳ��ÿһλ�ϵĺ�
        var bitSums = new int[32];
        foreach (var n in nums)
        {
            for (int i = 0; i < 32; i++)
            {
                bitSums[i] += ((n >> (31 - i)) & 1);
            }
        }

        // ��ԭ���ظ������ֵ�ÿһλ
        var result = 0;
        for (int i = 0; i < bitSums.Length; i++)
        {
            result = (result << 1) + bitSums[i] % 3;
        }

        return result;
    }
}