namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/wtcaE1/
/// </summary>
public class LongestSubstringNoRepeatingChs
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length <= 1) return s.Length;

        var hash = new ushort[128]; // [0, 65535]
        var left = 0;
        var right = 0;
        hash[s[right]] += 1;

        var dupCount = 0;

        var maxSize = 0;

        while (right < s.Length)
        {
            if (dupCount <= 0)
            {
                maxSize = Math.Max(maxSize, right - left + 1);

                if (++right >= s.Length)
                {
                    break;
                }

                hash[s[right]] += 1;
                dupCount += hash[s[right]] > 1 ? 1 : 0;
            }
            else
            {
                dupCount -= hash[s[left]] > 1 ? 1 : 0;
                hash[s[left++]] -= 1;
            }
        }
        return maxSize;
    }

    /**
     * ����һ���ַ��� s �������ҳ����в������ظ��ַ��� ��������ַ��� �ĳ��ȡ�
     * 0 <= s.length <= 5 * 10^4
     * s ��Ӣ����ĸ�����֡����źͿո����
     * 
     * 1. ���ǳ�ʼ������������߽磻
     *   1. maxSize, left, right, ushort[128]
     *   2. Right < s.Length, left���==rightһ���ַ����ظ������Բ�����left
     * 2. ��ʼѭ��
     *   1. ���û���ظ�������maxSize����ôright++���ж��Ƿ���磬hash[s[right]] += 1
     *   2. ������ظ���hash[s[left]] -= 1��left ++
     * 3. Return maxSize
     *  
     * ����ĵط�:
     * - ��ʼ�������û�������
     * - ��ѭ����ʱ�ı߽�
     * */
}