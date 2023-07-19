using System.Text;

namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/ti-huan-kong-ge-lcof/submissions/?envType=study-plan-v2&envId=coding-interviews
/// </summary>
[TestClass]
public class Solution05_ReplaceSpace
{
    public string ReplaceSpace(string s)
    {
        if (s == null) throw new ArgumentNullException();
        if (s.Length == 0) return s;

        var sb = new StringBuilder();
        foreach (var c in s.ToCharArray())
        {
            if (c.Equals(' '))
            {
                sb.Append("%20");
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    [TestMethod]
    public void TestSolution()
    {
        var sol = new Solution05_ReplaceSpace();
        
        Assert.AreEqual(sol.ReplaceSpace(""), "");

        Assert.ThrowsException<ArgumentNullException>(() => { sol.ReplaceSpace(null); });

        Assert.AreEqual("%20%20%20", sol.ReplaceSpace("   "));
    }
}