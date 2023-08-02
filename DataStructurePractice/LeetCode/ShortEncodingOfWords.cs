namespace DataStructurePractice.LeetCode;

public class ShortEncodingOfWords
{
    public int MinimumLengthEncoding(string[] words)
    {
        var tree = new TrieTree();
        foreach (var w in words)
        {
            tree.Insert(w);
        }

        tree.dfs();
        return tree.size;
    }



    /**
     * 按照words的反向构造一棵前缀树
     * 最后的结果是 叶结点的个数(#的个数) + 前缀树中所有字符的长度
     * */

    class TrieNode
    {
        public int pass = 0;
        public int end = 0;
        public TrieNode[] nexts = new TrieNode[26];
    }

    class TrieTree
    {
        public TrieNode root = new TrieNode();
        public int size = 0;

        public void Insert(string word)
        {
            var node = root;
            for (int i = word.Length-1; i >= 0; i--)
            {
                var index = word[i] - 'a';
                if (node.nexts[index] == null)
                {
                    node.nexts[index] = new TrieNode();
                }
                node = node.nexts[index];
                node.pass++;
            }
            node.end++;
        }

        public void dfs()
        {
            dfs(root, 1);
        }

        private void dfs(TrieNode root, int length)
        {
            var isLeaf = true;
            foreach (var child in root.nexts)
            {
                if (child != null)
                {
                    isLeaf = false;
                    dfs(child, length + 1);
                }
            }
            // 只有在叶子节点，没有进入上面的循环时isLeaf没有被设为false
            if (isLeaf)
            {
                size += length;
            }
        }
    }
}