using System;

namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/M1oyTv/
/// 1 <= s.length, t.length <= 10^5
/// s 和 t 由英文字母组成
/// 注意： 对于 t 中重复字符，我们寻找的子字符串中该字符数量必须不少于 t 中该
/// 字符数量。
/// 
/// 给定两个字符串 s 和 t 。返回 s 中包含 t 的所有字符的最短子字符串。如果 s
/// 中不存在符合条件的子字符串，则返回空字符串 "" 。
/// 
/// 如果 s 中存在多个符合条件的子字符串，返回任意一个。
/// </summary>
[TestClass]
public class MinWindowSolution
{
    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length) { return ""; }

        var charInTMap = new bool['z' - 'A' + 1];

        // 种类数 && 重复次数
        var charCountMap = new int['z'-'A'+1];
        var count = 0;
        int index;

        for (int i = 0; i < t.Length; i++)
        {
            index = t[i] - 'A';
            // 记录t中是否有这个字符, t中没有的字符在下面的过程中无须计算
            charInTMap[index] = true;
            // 记录t中这个字符出现了几次 => 所求子串缺几次
            charCountMap[index] --;
            // 记录t中字符种类数, 首次==-1时 => 所求子串缺的种类数
            if (charCountMap[index] == -1) count --;
        }

        var left = 0;
        var right = 0;

        index = s[right] - 'A';
        if (charInTMap[index])
        {
            charCountMap[index]++;
            if (charCountMap[index] == 0) count++; // 如果这种字符不缺了, 更新count
        }

        var minLeft = 0;
        var minLength = int.MaxValue;

        while (right < s.Length)
        {
            if (count != 0)
            {  
                // 先移动到下一个指针, 再更新
                if (++right >= s.Length) break;

                index = s[right] - 'A';
                if (charInTMap[index])
                {
                    charCountMap[index]++;
                    if (charCountMap[index] == 0) count++; // 如果这种字符不缺了, 更新count
                }
            }
            else
            {
                // 先更新, 再右移指针
                var len = right - left + 1;
                if (len < minLength)
                {
                    minLeft = left;
                    minLength = len;
                }
                index = s[left] - 'A';
                if (charInTMap[index])
                {
                    charCountMap[index]--;
                    if (charCountMap[index] == -1) count--;
                }
                left++;
            }
        }

        Console.WriteLine($"{minLeft} {minLength}");
        return minLength == int.MaxValue
            ? ""
            : s.Substring(minLeft, minLength);
    }

    /**
     * 注意:
     * - s.Length 需要 >= t.Length
     * 
     * 思路:
     * 字符的种类数要对应, 字符的重复数量要对应
     * int count记录字符的种类数, charCountMap记录字符出现的数量
     * 
     * 并且, 只需要计算t中有的字符
     * bool[] charInTMap
     * 
     * 1. 初始化, 初始化过程与右指针移动后的计算过程是一样的
     * 2. 循环
     *  - count != 0 : 右指针右移, 判断是否出界, 增加当前右指针位置字符情况, 只更新在t中有的字符的情况, 
     *      种类, 数量
     *  - count == 0 : 更新res; 如果当前左指针所在位置的字符在t中, 计算移除当前左指针位置的字符的情况, 
     *      最后, 无论怎样, 左指针右移
     * 3. 返回res
     * 
     * 提前初始化, 尽管有一些重复代码, 但是边界问题会很清晰.
     * */

    [TestMethod]
    public void test()
    {
        new MinWindowSolution().MinWindow(
            "ADOBECODEBANC", 
            "ABC"
            );
    }
}