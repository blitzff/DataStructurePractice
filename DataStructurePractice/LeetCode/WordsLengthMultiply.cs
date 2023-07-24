namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/aseY1I/
/// 2 <= words.length <= 1000
/// 1 <= words[i].length <= 1000
/// words[i] 仅包含小写字母
/// </summary>
public class WordsLengthMultiply
{
    public int MaxProduct(string[] words)
    {
        // 用一个32位int类型作为单词中出现的字母的统计
        // 每个字母只统计一次就足够
        // 与操作能够得知两个单词是否有重复单词
        var alpletables = new int[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            foreach (var c in words[i])
            {
                alpletables[i] |= (1 << (c-'a'));
            }
        }

        // n^2遍历所有单词, 取字母不重复的长的乘积最大值
        var maxProduct = 0;
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i+1; j < words.Length; j++)
            {
                if ((alpletables[i] & alpletables[j]) == 0)
                {
                    maxProduct = Math.Max(maxProduct, words[i].Length * words[j].Length);
                }
            }
        }

        return maxProduct;
    }
}