namespace DataStructurePractice.LeetCode;

[TestClass]
public class PalindromePartition
{
    private List<string[]> res = new List<string[]>();
    private string s;
    public string[][] Partition(string s)
    {
        this.s = s;
        dfs(0, new List<string>());
        return res.ToArray();
    }

    private void dfs(int start, List<string> path)
    {
        // 5. 某次找结束了，记录结果
        if (start == s.Length){
            res.Add(path.ToArray());
        }
        else if (start < s.Length)
        {
            // 1. 从start开始向后找
            for (int end = start; end < s.Length; end++)
            {
                // 2. 满足回文则是分割点 7.
                if (IsPalindrome(start, end))
                {
                    // 3. 记录下当前被分割的字符串
                    path.Add(s.Substring(start, end-start+1));
                    // 4. 继续往后找，到底返回5.
                    dfs(end+1, path);
                    // 6. 这一次满足的地方分割完了，继续按照当前的形式从for循环向后找当前位置的下一个满足条件的分割点
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }

    private bool IsPalindrome(int start, int end)
    {
        while (start < end)
        {
            if (s[start++] != s[end--]) return false;
        }
        return true;
    }

    [TestMethod]
    public void test()
    {
        var s = "google";
        new PalindromePartition().Partition(s);
    }

    /*
     * 题意是分割，并不是在找所有的回文，所以不能简单地用双循环
     * 
     * 回溯
     * 在每一步，向后分割[i+0, s.Length-1]
     * 如 g, go, goo, goog, googl, google
     */
}
