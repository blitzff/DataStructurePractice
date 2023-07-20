namespace DataStructurePractice.CrackingTheCodingInterview;

[TestClass]
public class NHammingWeight
{
    /// <summary>
    /// ������� i & (i-1) ÿ���Ƶ� i ���ҵ�1λ1,
    /// Ҳ����ζ��, bits[i] = bits[i & (i-1)] + 1;
    /// ��� i > i & (i-1) �Ļ�, ��ô����һ��Ϳ�����.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] CountBits(int n)
    {
        int[] bits = new int[n+1];
        for (int i = 1; i < bits.Length; i++)
        {
            bits[i] = bits[i & (i-1)] + 1;
        }
        return bits;
    }

    /// <summary>
    /// i > i & (i-1)
    /// </summary>
    [TestMethod]
    public void test()
    {
        for (int i = 1; i < 10000; i++)
        {
            Console.WriteLine($"{i} : {i & (i-1)}");
        }
    }
}