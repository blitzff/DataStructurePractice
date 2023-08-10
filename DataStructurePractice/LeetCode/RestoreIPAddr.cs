using System.Text;

namespace DataStructurePractice.LeetCode;

[TestClass]
public class RestoreIPAddr
{
    private string s;
    private IList<string> res = new List<string>();

    public IList<string> RestoreIpAddresses(string s)
    {
        this.s = s;
        dfs(0, 
            new List<StringBuilder>(){
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder()
            }, 
            0);
        return res;
    }

    private void dfs(
        int start, 
        List<StringBuilder> path,
        int segNo)
    {
        if (segNo >= path.Count) return;
        if (start == s.Length && IsValidEventually(path))
        {
            var sb = new StringBuilder();
            sb.Append(path[0]); sb.Append('.');
            sb.Append(path[1]); sb.Append('.');
            sb.Append(path[2]); sb.Append('.');
            sb.Append(path[3]); 
            res.Add(sb.ToString());
        }
        else if (start < s.Length 
            && IsValidIPSoFar(path))
        {
            path[segNo].Append(s[start]);
            // 仍在当前段
            dfs(start + 1, path, segNo);
            // 去下一段
            dfs(start + 1, path, segNo+1);
            path[segNo].Remove(path[segNo].Length - 1, 1);
        }
    }

    private bool IsValidIPSoFar(List<StringBuilder> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            var s = path[i];
            if (s.Length > 0)
            {
                if (s.Length > 1 && s[0] == '0') return false;

                var num = int.Parse(s.ToString());
                if (num < 0 || num > 255) return false;
            }
        }
        return true;
    }

    private bool IsValidEventually(List<StringBuilder> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            var s = path[i];
            if (s.Length == 0) return false;

            if (s.Length > 1 && s[0] == '0') return false;

            var num = int.Parse(s.ToString());
            if (num < 0 || num > 255) return false;
        }
        return true;
    }

    [TestMethod]
    public void test()
    {
        new RestoreIPAddr().RestoreIpAddresses("25525511135");
    }
}
