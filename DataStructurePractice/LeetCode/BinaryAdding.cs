using System.Text;

namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/JFETK5/
/// 每个字符串仅由字符 '0' 或 '1' 组成。
/// 1 <= a.length, b.length <= 10^4
/// 字符串如果不是 "0" ，就都不含前导零。
/// </summary>
public class BinaryAdding
{
    public string AddBinary(string a, string b)
    {
        var i = a.Length - 1;
        var j = b.Length - 1;

        var result = new StringBuilder();

        var C = 0;

        while (i >= 0 || j >= 0)
        {
            var A = i >= 0 ? a[i--] - '0' : 0;
            var B = j >= 0 ? b[j--] - '0' : 0;
            var sum = A + B + C;
            C = sum >= 2 ? 1 : 0;
            result.Insert(0, sum >= 2 ? sum - 2 : sum);
        }

        if (C == 1)
        {
            result.Insert(0, "1");
        }

        return result.ToString();
    }

    /**
     * 全是细节(易错点):
     * 1. 遍历字符串a和b时, 使用 ||
     * 2. 由1意味着要在循环体中判断i和j是否越界
     * 3. A和B取值时要-'0'
     * 4. sum有两种情况, 2和3
     * 5. 每次计算下一次的进位情况
     * 6. 对当前位的判断
     * 7. StringBuilder使用Insert来使其逆序
     *  */
}
