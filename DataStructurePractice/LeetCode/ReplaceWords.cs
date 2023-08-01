using System.Text;

namespace DataStructurePractice.LeetCode;

public class ReplaceWordsSolution
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        // 构造前缀树
        var trie = new TrieTree();
        foreach (var s in dictionary)
        {
            trie.Insert(s);
        }

        // 查找前缀
        var words = sentence.Split(' ');
        for(int i = 0; i < words.Length; i++)
        {
            var prefix = trie.FindPrefix(words[i]);
            words[i] = (prefix == "" ? words[i] : prefix);
        }
        return string.Join(' ', words);
    }

    class TrieNode
    {
        public int pass = 0;
        public int end = 0;
        public TrieNode[] nexts = new TrieNode[26];
    }

    class TrieTree
    {
        private readonly TrieNode root = new TrieNode();

        public void Insert(string word)
        {
            if (word == null) { return; }

            var chs = word.ToCharArray();
            var node = root;
            for (int i = 0; i < chs.Length; i++)
            {
                var index = chs[i] - 'a';
                if (node.nexts[index] == null)
                {
                    node.nexts[index] = new TrieNode();
                }
                node.nexts[index].pass++;
                node = node.nexts[index];
            }
            node.end++;
        }

        public string FindPrefix(string word)
        {
            var res = new StringBuilder();
            var chs = word.ToCharArray();
            var node = root;
            for (int i = 0; i < chs.Length; i++)
            {
                var index = chs[i] - 'a';
                // 当前字符没有对应的node
                // 或 当前是个结尾字符
                if (node.nexts[index] == null || node.end > 0)
                {
                    break;
                }
                res.Append(chs[i]);
                node = node.nexts[index];
            }
            return node.end > 0 ? res.ToString() : "";
        }
    }
}