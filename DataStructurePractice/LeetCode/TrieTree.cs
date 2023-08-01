namespace DataStructurePractice.LeetCode;

// https://leetcode.cn/problems/QC3q1f/description/

/// <summary>
/// ÿ���ڵ����һ���ַ�
/// ������Сд��ĸ
/// </summary>
public class TrieNode
{
    /// <summary>
    /// ��������ڵ�ıߵ�����
    /// </summary>
    public int pass;
    /// <summary>
    /// �Դ˽ڵ�Ϊ�����ıߵ�����
    /// </summary>
    public int end;
    /// <summary>
    /// �Ӵ˽ڵ�����Ľڵ㼯��
    /// </summary>
    public TrieNode[] nexts;

    public TrieNode()
    {
        this.pass = 0;
        this.end = 0;
        this.nexts = new TrieNode[26];
    }
}

public class TrieTree
{
    /// <summary>
    /// dummy head.
    /// </summary>
    private TrieNode root;

    public TrieTree()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        if (word == null) { return; }

        var chars = word.ToCharArray();
        var node = root;
        for (int i = 0; i < chars.Length; i++)
        {
            var ch = chars[i] - 'a';
            if (node.nexts[ch] == null)
            {
                node.nexts[ch] = new TrieNode();
            }
            node = node.nexts[ch];
            node.pass++;
        }
        node.end++;
    }

    public void Delete(string word)
    {
        if (Search(word) == 0) return;

        var chars = word.ToCharArray();
        var node = root;
        for (int i = 0; i < chars.Length; i++)
        {
            var ch = chars[i] - 'a';
            // ����ch�ַ��ı�
            node.nexts[ch].pass --;
            if (node.nexts[ch].pass == 0)
            { // ���û���ַ����������ߣ� ɾ�������ߣ� ֱ�ӷ���
                node.nexts[ch] = null;
                return;
            }
            // ���������һ���ַ�
            node = node.nexts[ch];
        }
        // word�������ַ���������Ϻ�
        node.end--;
    }

    public int Search(string word)
    {
        if (word == null) { return 0; }

        var chars = word.ToCharArray();
        var node = root;
        for (int i = 0; i < chars.Length; i++)
        {
            var ch = chars[i] - 'a';
            // �ֵ����в������������ַ���
            if (node.nexts[ch] == null)
            {
                return 0; 
            }
            // ��ǰ�ַ����ڣ�������һ���ַ�
            node = node.nexts[ch];
        }
        // �������ʴ��ڣ��������һ���ַ�Ϊ��β����Ŀ
        return node.end;
    }

    public int StartWith(string word)
    {
        if (word == null) { return 0; }

        var chars = word.ToCharArray();
        var node = root;
        for (int i = 0; i < chars.Length; i++)
        {
            var ch = chars[i] - 'a';
            // �ֵ����в������������ַ���
            if (node.nexts[ch] == null)
            {
                return 0;
            }
            // ��ǰ�ַ����ڣ�������һ���ַ�
            node = node.nexts[ch];
        }
        // �������ʴ��ڣ��������һ���ַ�Ϊ��β����Ŀ
        return node.pass;
    }


    /**
     * ������һ���ַ���ת����ǰ׺��
     * ["abc", "ad", "abe"]
     * */
}