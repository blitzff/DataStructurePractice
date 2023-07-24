namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/RQku0D/description/
/// </summary>
public class ValidPalindromeIISolution
{
    public bool ValidPalindrome(string s)
    {
        var start = 0;
        var end = s.Length - 1;

        while (start < end)
        {
            if (s[start] != s[end])
            {
                break;
            }
            start++; end--;
        }

        return start >= end
            || IsPalindrome(s, start + 1, end)
            || IsPalindrome(s, start, end - 1);
    }

    private bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end]) return false;
            start++; end--;
        }
        return true;
    }

    /**
     * 最多删除1个, 遍历到不满足原字符串为回文的情况, 左或右删除后看看是否构成回文.
     * 
     * 还有可能本身就已经是回文串 (最多删除1个, 也可以不删除).
     * */
}