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
     * ���ɾ��1��, ������������ԭ�ַ���Ϊ���ĵ����, �����ɾ���󿴿��Ƿ񹹳ɻ���.
     * 
     * ���п��ܱ�����Ѿ��ǻ��Ĵ� (���ɾ��1��, Ҳ���Բ�ɾ��).
     * */
}