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
     * �ù�ϣ������¼ÿ���ַ���˳��
     * ������֪, ֻ����Сд��ĸ
     * new int[26];
     * 
     * �����ַ��������е��ַ����ıȽ�
     * words[i], words[i+1], i \in [0, words.Length-2]
     * ���ڵ������Ƚ�
     * 
     * ��αȽ�?
     * ����ָ�붼û����:
     * �ַ�һ��, ��������, ָ��++
     * ĳλ���ַ� strǰ > str�� return false
     * ĳλ���ַ� strǰ < str�� return true
     * 
     * ĳһ�ַ�������,
     * �����һ���ַ�������, return true, ��Ϊ �� < �����ַ�
     * �����һ���ַ���û����, return false
     * ����, return p == str1.Length
     * */
}