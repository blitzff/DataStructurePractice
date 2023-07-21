namespace DataStructurePractice.CrackingTheCodingInterview;

[TestClass]
public class Palindrome
{
    public bool IsPalindrome(string s)
    {
        var p1 = 0;
        var p2 = s.Length - 1;
        while (p1 < p2)
        {
            while (p1 < p2 && !char.IsLetterOrDigit(s[p1]))
            {
                p1++;
            }
            while (p1 < p2 && !char.IsLetterOrDigit(s[p2]))
            {
                p2--;
            }
            //Console.WriteLine($"{s[p1]} {s[p2]}");
            if (char.ToLower(s[p1++]) != char.ToLower(s[p2--])) return false;
        }
        return true;
    }

    [TestMethod]
    public void test()
    {
        IsPalindrome("A man, a plan, a canal: Panama");
    }
}