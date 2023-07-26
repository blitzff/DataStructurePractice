namespace DataStructurePractice.LeetCode;

public class GroupAnagramsSolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        // 能想到 O(n*n*m) 的暴力
        // 排序， 稍微好一点点
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
        // 不同的题目对于变位词的定义稍有不同
        // 本题中相同字符串属于是变位词
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