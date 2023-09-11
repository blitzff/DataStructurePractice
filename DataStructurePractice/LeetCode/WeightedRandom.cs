namespace DataStructurePractice.LeetCode;

public class WeightedRandom
{
    private int[] ratio;
    private int sum = 0;

    public WeightedRandom(int[] weights)
    {
        ratio = new int[weights.Length];
        for (int i = 0; i < weights.Length; i++)
        {
            sum += weights[i];
            ratio[i] = sum;
        }
    }

    /// <summary>
    /// 查找num小于当前并且大于等于上一个ratio中的元素的索引
    /// [0, sum)
    /// </summary>
    /// <returns></returns>
    public int PickIndex()
    {
        var random = new Random();
        var num = random.Next(0, sum);

        var left = 0;
        var right = ratio.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (ratio[mid] > num)
            {
                if (mid == 0 || ratio[mid-1] <= num)
                {
                    return mid;
                }
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return -1;
    }
}
