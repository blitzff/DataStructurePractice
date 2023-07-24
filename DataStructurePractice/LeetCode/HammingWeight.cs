namespace DataStructurePractice.CrackingTheCodingInterview;

public class HammingWeightSolution
{
    public int HammingWeight(uint n)
    {
        // 每次让最右一位成为0，一共需要多少次
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