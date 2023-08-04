namespace DataStructurePractice.LeetCode;

public class MergeIntervals
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (i1, i2) => i1[0] - i2[0]);
        var merged = new List<int[]>();
        var i = 0;

        while (i < intervals.Length)
        {
            var temp = intervals[i];
            // 从i+1开始, 如果能够合并, 就一直修改缓存的temp的end值
            var j = i + 1;
            while (j < intervals.Length 
                && temp[1] >= intervals[j][0])
            {
                temp[1] = Math.Max(intervals[j][1], temp[1]);
                j++;
            }
            // 直到不能合并, 交换i
            i = j;
            merged.Add(temp);
        }
        var res = new int[merged.Count][];
        merged.CopyTo(res, 0);
        return res;
    }

    /**
     * 按第一个元素排序
     * 遍历二维数组的第一维，
     * 关键在于一个缓存的temp值
     *  能合并一直合并(更新temp[1]的值)
     *  不能合并交换i和j
     * */
}