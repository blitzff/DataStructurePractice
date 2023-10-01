namespace DataStructurePractice.LeetCode;

[TestClass]
public class MaxOfTriple
{
    public long MaximumTripletValue(int[] nums)
    {

        long max = 0;
        var n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    long t = (long)(nums[i] - nums[j]) * (long)nums[k];
                    max = Math.Max(max, t);
                }
            }
        }
        return max;
    }

    [TestMethod]
    public void test()
    {
        var nums = new int[] { 1000000, 1, 1000000 };
        new MaxOfTriple().MaximumTripletValue(nums);
    }
}
