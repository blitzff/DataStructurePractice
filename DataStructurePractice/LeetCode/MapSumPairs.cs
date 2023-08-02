namespace DataStructurePractice.LeetCode;

public class MapSum
{
    TrieNode root = new TrieNode();

    public void Insert(string word, int val)
    {
        if (word == null) return;

        var chars = word.ToCharArray();
        var node = root;
        for (int i = 0; i < chars.Length; i++)
        {
            var index = chars[i] - 'a';
            if (node.nexts[index] == null)
            {
                node.nexts[index] = new TrieNode();
            }
            node = node.nexts[index];
        }
        node.value = val;
    }

    /// <summary>
    /// 找到前缀的终止节点，然后dfs统计以此前缀为开头的单词的和
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public int Sum(string prefix)
    {
        var node = root;
        for (int i = 0; i < prefix.Length; i++)
        {
            var index = prefix[i] - 'a';
            if (node.nexts[index] == null) 
                return 0; // prefix长于前缀树中的内容

            node = node.nexts[index];
        }
        // 最后找到树中的prefix的最后一个节点

        return dfs(node);
    }

    private int dfs(TrieNode node)
    {
        // 不用单独考虑到叶子节点，直接到底
        if (node == null) return 0;

        var result = node.value;

        foreach (var next in node.nexts)
        {
            result += dfs(next);
        }

        return result;
    }

    class TrieNode
    {
        public int value;
        public TrieNode[] nexts = new TrieNode[26];
    }
}