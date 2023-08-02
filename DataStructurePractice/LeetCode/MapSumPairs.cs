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
    /// �ҵ�ǰ׺����ֹ�ڵ㣬Ȼ��dfsͳ���Դ�ǰ׺Ϊ��ͷ�ĵ��ʵĺ�
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
                return 0; // prefix����ǰ׺���е�����

            node = node.nexts[index];
        }
        // ����ҵ����е�prefix�����һ���ڵ�

        return dfs(node);
    }

    private int dfs(TrieNode node)
    {
        // ���õ������ǵ�Ҷ�ӽڵ㣬ֱ�ӵ���
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