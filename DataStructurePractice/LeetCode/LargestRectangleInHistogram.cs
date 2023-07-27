namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/0ynMMM/
/// </summary>
[TestClass]
public class LargestRectangleInHistogram
{
    public int LargestRectangleArea(int[] heights)
    {
        return MinArea(heights, 0, heights.Length - 1);
    }

    private int MinArea(int[] hs, int start, int end)
    {
        if (start > end) return 0;

        var minIndex = start;
        for (int index = start; index <= end; index++)
        {
            minIndex = hs[index] < hs[minIndex] ? index : minIndex;
        }
        var area = hs[minIndex] * (end - start + 1);
        var left = MinArea(hs, start, minIndex - 1);
        var right = MinArea(hs, minIndex + 1, end);

        left = Math.Max(area, left);
        return Math.Max(left, right);
    }

    [TestMethod]
    public void test()
    {
        new LargestRectangleInHistogram().LargestRectangleArea(new int[]
        {
            2, 1
        });
    }

    /**
     * 这个直方图的最大矩形有3种可能。
     * 
     * 第1种是矩形通过这根最矮的柱子
     * 
     * 第2种是矩形的起始柱子和终止柱子都在最矮的柱子的左侧，也就是从
     * 下标为0的柱子到下标为4的柱子的直方图的最大矩形
     * 
     * 第3种是矩形的起始柱子和终止柱子都在最矮的柱子的右侧
     * 
     * 第2种和第3种从本质上来说和求整个直方图的最大矩形面积是同一个问题，可以调用递归函数解决。
     * */
}