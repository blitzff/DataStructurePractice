namespace DataStructurePractice.LeetCode;

public class FlipString
{
    private char[] chars;
    private int min = int.MaxValue;
    public int MinFlipsMonoIncr(string s)
    {
        chars = s.ToCharArray();
        f(0, 0);
        return min;
    }

    /**
     * 然后考虑如何改动态规划
     * 设f[n]代表到n位置使s为递增的最小翻转次数
     * 这里面涉及到chars回溯的问题，怎么弄？二维数组
     * 而且只有符合题目要求的才考虑。
     * 
     * 假设字符串 s 的长度是 n，对于 0≤i<n，用 dp[i][0] 
     * 和 dp[i][1] 分别表示下标 i 处的字符为 0 和 1
     * 的情况下使得 s[0..i] 单调递增的最小翻转次数。
     * 
     * 由于字符串 s 的每个位置的字符可以是 0 或 1，因此对于每个位置需要
     * 分别计算该位置的字符是 0 和该位置的字符是 1 的情况下的最小翻转次数。
     * 
     * i == 0 时最小翻转次数是0, dp[0][0] = s[0] == '1', dp[0][1] = s[0] == '0'
     * 
     * dp[i][0]时，前一个位置只能是0才符合题目要求
     * dp[i][0] = dp[i-1][0] + s[i] == '1'
     * 
     * dp[i][1]时，前一个位置可能是0或1
     * dp[i][1] = min(dp[i-1][1], dp[i-1][0]) + s[i] == '0'
     * 
     * */

    private void f(int i, int count)
    {
        if (i == chars.Length)
        {
            if (IsIncreasing())
            {
                min = Math.Min(min, count);
            }
        }
        else if (i < chars.Length)
        {
            // i位置翻转
            chars[i] = chars[i] == '0' ? '1' : '0';
            f(i + 1, count + 1);
            chars[i] = chars[i] == '0' ? '1' : '0'; // 回溯

            // i位置不翻转
            f(i + 1, count);
        }
    }

    private bool IsIncreasing()
    {
        // 前面全是0， 后面全是1
        var n = chars.Length;
        var left = 0;
        while (left < n && chars[left] == '0') left++;
        var right = n - 1;
        while (right >= 0 && chars[right] == '1') right--;

        if (left >= right) return true;
        return false;
    }

    /**
     * 求最小反转次数，因此使用动态规划
     * 
     * 在每个位置上有两个选择：
     *  翻转或是不翻转
     *  
     * 设f(n)是到n位置的最少翻转次数
     * 从0位置开始如何得到下一次
     * 
     * */
}
