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
     * ����words�ķ�����һ��ǰ׺��
     * ���Ľ���� Ҷ���ĸ���(#�ĸ���) + ǰ׺���������ַ��ĳ���
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
            // ֻ����Ҷ�ӽڵ㣬û�н��������ѭ��ʱisLeafû�б���Ϊfalse
            if (isLeaf)
            {
                size += length;
            }
        }
    }
}