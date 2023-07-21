namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/aseY1I/
/// 2 <= words.length <= 1000
/// 1 <= words[i].length <= 1000
/// words[i] ������Сд��ĸ
/// </summary>
public class WordsLengthMultiply
{
    public int MaxProduct(string[] words)
    {
        // ��һ��32λint������Ϊ�����г��ֵ���ĸ��ͳ��
        // ÿ����ĸֻͳ��һ�ξ��㹻
        // ������ܹ���֪���������Ƿ����ظ�����
        var alpletables = new int[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            foreach (var c in words[i])
            {
                alpletables[i] |= (1 << (c-'a'));
            }
        }

        // n^2�������е���, ȡ��ĸ���ظ��ĳ��ĳ˻����ֵ
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