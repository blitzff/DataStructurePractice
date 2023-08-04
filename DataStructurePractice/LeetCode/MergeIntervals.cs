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
            // ��i+1��ʼ, ����ܹ��ϲ�, ��һֱ�޸Ļ����temp��endֵ
            var j = i + 1;
            while (j < intervals.Length 
                && temp[1] >= intervals[j][0])
            {
                temp[1] = Math.Max(intervals[j][1], temp[1]);
                j++;
            }
            // ֱ�����ܺϲ�, ����i
            i = j;
            merged.Add(temp);
        }
        var res = new int[merged.Count][];
        merged.CopyTo(res, 0);
        return res;
    }

    /**
     * ����һ��Ԫ������
     * ������ά����ĵ�һά��
     * �ؼ�����һ�������tempֵ
     *  �ܺϲ�һֱ�ϲ�(����temp[1]��ֵ)
     *  ���ܺϲ�����i��j
     * */
}