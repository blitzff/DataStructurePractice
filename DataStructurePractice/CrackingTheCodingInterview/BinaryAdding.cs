using System.Text;

namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/JFETK5/
/// ÿ���ַ��������ַ� '0' �� '1' ��ɡ�
/// 1 <= a.length, b.length <= 10^4
/// �ַ���������� "0" ���Ͷ�����ǰ���㡣
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
     * ȫ��ϸ��(�״��):
     * 1. �����ַ���a��bʱ, ʹ�� ||
     * 2. ��1��ζ��Ҫ��ѭ�������ж�i��j�Ƿ�Խ��
     * 3. A��BȡֵʱҪ-'0'
     * 4. sum���������, 2��3
     * 5. ÿ�μ�����һ�εĽ�λ���
     * 6. �Ե�ǰλ���ж�
     * 7. StringBuilderʹ��Insert��ʹ������
     *  */
}
