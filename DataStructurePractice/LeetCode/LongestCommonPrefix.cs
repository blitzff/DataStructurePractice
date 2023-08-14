using System.Text;

namespace DataStructurePractice.LeetCode;

[TestClass]
public class LongestCommonPrefixSolution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var tree = new TrieTree();
        foreach (var s in strs)
        {
            tree.Insert(s);
        }
        return tree.CommonPrefix(strs.Length);
    }

    class TrieNode
    {
        public int pass;
        public int end;
        public TrieNode[] nexts = new TrieNode[26];
    }

    class TrieTree
    {
        public TrieNode root = new TrieNode();

        public void Insert(string word)
        {
            var node = root;
            var chars = word.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                var idx = chars[i] - 'a';

                if (node.nexts[idx] == null)
                {
                    node.nexts[idx] = new TrieNode();
                }

                node = node.nexts[idx];
                node.pass++;
            }
            node.end++;
        }

        public string CommonPrefix(int strs)
        {

            var sb = new StringBuilder();
            var node = root;
            while (node.nexts != null)
            {
                var i = 0;
                for (; i < node.nexts.Length; i++)
                {
                    var next = node.nexts[i];
                    if (next == null) continue;

                    if (next.pass == strs)
                    {
                        sb.Append((char)(i + 'a'));
                        node = next;
                        break;
                    }
                }
                if (i >= 26) break;
            }
            return sb.ToString();
        }
    }

    [TestMethod]
    public void test()
    {
        new LongestCommonPrefixSolution().LongestCommonPrefix(
            new string[]
            {
                "flower","flow","flight"
            });
    }
}
