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
     * ���ֱ��ͼ����������3�ֿ��ܡ�
     * 
     * ��1���Ǿ���ͨ������������
     * 
     * ��2���Ǿ��ε���ʼ���Ӻ���ֹ���Ӷ���������ӵ���࣬Ҳ���Ǵ�
     * �±�Ϊ0�����ӵ��±�Ϊ4�����ӵ�ֱ��ͼ��������
     * 
     * ��3���Ǿ��ε���ʼ���Ӻ���ֹ���Ӷ���������ӵ��Ҳ�
     * 
     * ��2�ֺ͵�3�ִӱ�������˵��������ֱ��ͼ�������������ͬһ�����⣬���Ե��õݹ麯�������
     * */
}