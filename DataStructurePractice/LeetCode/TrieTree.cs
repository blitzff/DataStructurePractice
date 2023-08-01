namespace DataStructurePractice.LeetCode;

// https://leetcode.cn/problems/QC3q1f/description/

/// <summary>
/// 每个节点代表一个字符
/// 仅包含小写字母
/// </summary>
public class TrieNode
{
    /// <summary>
    /// 经过这个节点的边的数量
    /// </summary>
    public int pass;
    /// <summary>
    /// 以此节点为结束的边的数量
    /// </summary>
    public int end;
    /// <summary>
    /// 从此节点出发的节点集合
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
            // 经过ch字符的边
            node.nexts[ch].pass --;
            if (node.nexts[ch].pass == 0)
            { // 如果没有字符经过这条边， 删掉这条边， 直接返回
                node.nexts[ch] = null;
                return;
            }
            // 否则继续下一个字符
            node = node.nexts[ch];
        }
        // word的所有字符都处理完毕后
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
            // 字典树中不存在这样的字符串
            if (node.nexts[ch] == null)
            {
                return 0; 
            }
            // 当前字符存在，继续下一个字符
            node = node.nexts[ch];
        }
        // 整个单词存在，返回最后一个字符为结尾的数目
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
            // 字典树中不存在这样的字符串
            if (node.nexts[ch] == null)
            {
                return 0;
            }
            // 当前字符存在，继续下一个字符
            node = node.nexts[ch];
        }
        // 整个单词存在，返回最后一个字符为结尾的数目
        return node.pass;
    }


    /**
     * 将这样一组字符串转换成前缀树
     * ["abc", "ad", "abe"]
     * */
}