using System.Collections.Generic;

namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/569nqc/
/// </summary>
[TestClass]
public class MinTimeDiff
{
    public int FindMinDifference(IList<string> times)
    {
        var hash = new bool[24 * 60];
        foreach (var time in times)
        {
            var hm = time.Split(':');
            var h = hm[0];
            var m = hm[1];
            var minutes = int.Parse(h) * 60 + int.Parse(m);
            if (hash[minutes]) return 0; // ��������ظ���, ֱ�ӷ�����Сֵ0
            hash[minutes] = true;
        }

        var min = int.MaxValue;
        var firstTime = FindTime(0, hash);

        var cur = firstTime;

        while (cur < hash.Length)
        {
            var second = FindTime(cur + 1, hash);
            if (second == -1) break;

            min = Math.Min(min, second - cur);
            cur = second;
        }

        min = Math.Min(min, firstTime + 1440 - cur);

        return min;
    }

    private int FindTime(int startIndex, bool[] hash)
    {
        var i = startIndex;
        for (; i < hash.Length; i++)
        {
            if (hash[i]) return i;
        }
        return -1;
    }

    /**
     * 24 * 60 , [0, 24*60-1]
     * �����Ƚ�, ��¼��Сֵ
     * ���һ��ֵҪ�͵�һ��ֵ�Ƚ�, firstTime+1440-finalTime
     * 
     * ��αȽ����ڵ�?
     * ���ҵ���һ��ʱ��cur, Ȼ��ÿ�δ�cur+1����ҵ��ڶ���ʱ��,
     * ע���Ҳ����������ʱ�˳�;
     * Ȼ��Ƚ���Сֵ.
     * */

    [TestMethod]
    public void test()
    {
        new MinTimeDiff().FindMinDifference(
            new List<string>()
            {
                "05:31","22:08","00:35"
            });
    }
}