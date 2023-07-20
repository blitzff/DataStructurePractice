namespace DataStructurePractice.CrackingTheCodingInterview;

public class HammingWeightSolution
{
    public int HammingWeight(uint n)
    {
        // ÿ��������һλ��Ϊ0��һ����Ҫ���ٴ�
        // i & (i-1)
        var result = 0;
        while (n != 0)
        {
            result++;
            n = n & (n - 1);
        }
        return result;
    }
}