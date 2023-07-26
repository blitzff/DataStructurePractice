namespace DataStructurePractice.LeetCode;

public class GroupAnagramsSolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        // ���뵽 O(n*n*m) �ı���
        // ���� ��΢��һ���
        var hash = new Dictionary<string, IList<string>>();
        foreach (var str in strs)
        {
            var added = false;
            foreach (var key in hash.Keys)
            {
                if (IsAnagrams(key, str))
                {
                    hash[key].Add(str);
                    added = true;
                }
            }
            if (!added)
            {
                hash[str] = new List<string>() { str };
            }
        }

        var res = new List<IList<string>>();
        foreach (var key in hash.Keys)
        {
            res.Add(hash[key]);
        }
        return res;
    }

    private bool IsAnagrams(string s, string t)
    {
        // ��ͬ����Ŀ���ڱ�λ�ʵĶ������в�ͬ
        // ��������ͬ�ַ��������Ǳ�λ��
        if (s.Length != t.Length) return false;

        var hash = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            hash[s[i] - 'a']++;
            hash[t[i] - 'a']--;
        }
        return AreAllZeros(hash);
    }

    private bool AreAllZeros(int[] arr)
    {
        foreach (var a in arr)
        {
            if (a != 0) return false;
        }
        return true;
    }
}