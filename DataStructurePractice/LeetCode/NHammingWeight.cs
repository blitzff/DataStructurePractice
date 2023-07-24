namespace DataStructurePractice.CrackingTheCodingInterview;

[TestClass]
public class NHammingWeight
{
    /// <summary>
    /// 这个操作 i & (i-1) 每次移掉 i 最右的1位1,
    /// 也就意味着, bits[i] = bits[i & (i-1)] + 1;
    /// 如果 i > i & (i-1) 的话, 那么遍历一遍就可以了.
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