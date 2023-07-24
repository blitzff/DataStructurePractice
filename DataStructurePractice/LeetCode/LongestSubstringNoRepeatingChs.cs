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
     * 给定一个字符串 s ，请你找出其中不含有重复字符的 最长连续子字符串 的长度。
     * 0 <= s.length <= 5 * 10^4
     * s 由英文字母、数字、符号和空格组成
     * 
     * 1. 考虑初始化条件、出界边界；
     *   1. maxSize, left, right, ushort[128]
     *   2. Right < s.Length, left最多==right一个字符不重复，所以不考虑left
     * 2. 开始循环
     *   1. 如果没有重复，更新maxSize，那么right++，判断是否出界，hash[s[right]] += 1
     *   2. 如果有重复，hash[s[left]] -= 1，left ++
     * 3. Return maxSize
     *  
     * 出错的地方:
     * - 初始化的情况没考虑清楚
     * - 在循环中时的边界
     * */
}