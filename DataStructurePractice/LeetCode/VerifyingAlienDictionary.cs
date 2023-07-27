namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/lwyVBB/
/// </summary>
public class VerifyingAlienDictionary
{
    public bool IsAlienSorted(string[] words, string order)
    {
        var dicOrder = new int[26];
        var i = 0;
        foreach (var ch in order)
        {
            dicOrder[ch - 'a'] = i++;
        }
        for (i = 0; i < words.Length-1; i++)
        {
            if (!IsOrdered(words[i], words[i+1], dicOrder)) return false;
        }
        return true;
    }

    private bool IsOrdered(string s1, string s2, int[] dicOrder)
    {
        var index = 0;
        while (index < s1.Length && index < s2.Length)
        {
            var a = s1[index] - 'a';
            var b = s2[index] - 'a';
            if (dicOrder[a] > dicOrder[b])
            {
                return false;
            }
            if (dicOrder[a] < dicOrder[b])
            {
                return true;
            }
            index++;
        }
        return index == s1.Length;
    }

    /**
     * 用哈希表来记录每个字符的顺序
     * 由题意知, 只包含小写字母
     * new int[26];
     * 
     * 对于字符串数组中的字符串的比较
     * words[i], words[i+1], i \in [0, words.Length-2]
     * 相邻的两个比较
     * 
     * 如何比较?
     * 两个指针都没结束:
     * 字符一样, 继续遍历, 指针++
     * 某位置字符 str前 > str后 return false
     * 某位置字符 str前 < str后 return true
     * 
     * 某一字符串结束,
     * 如果第一个字符串结束, return true, 因为 空 < 任意字符
     * 如果第一个字符串没结束, return false
     * 综上, return p == str1.Length
     * */
}