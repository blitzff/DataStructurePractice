namespace DataStructurePractice.LeetCode;

public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        // 题目所求
        var length = 1;
        // 题目要求
        var notVisited = new HashSet<string>(wordList);

        var q1 = new Queue<string>();
        var q2 = new Queue<string>();
        q1.Enqueue(beginWord); // 先入队一个节点
        while (q1.Count > 0)
        {
            var word = q1.Dequeue();
            // 提前终止
            if (word.Equals(endWord))
            {
                return length;
            }

            // 根据题意生成接下来的节点
            var neighbors = GetNeighbors(word);
            foreach (var neighbor in neighbors)
            {
                if (notVisited.Contains(neighbor))
                {
                    q2.Enqueue(neighbor);
                    notVisited.Remove(neighbor);
                }
            }

            // 队列1为空时当前层结束
            if (q1.Count == 0)
            {
                length++;
                q1 = q2;
                q2 = new Queue<string>();
            }
        }
        return 0;
    }

    private List<string> GetNeighbors(string word)
    {
        var neighbors = new List<string>();
        if (word == null || word.Length == 0) return neighbors;

        var chars = word.ToCharArray();
        // 在每一个位置上都用26个小写字母替换得到邻居字符串
        for (int i = 0; i < word.Length; i++)
        {
            var chari = chars[i];
            for (char j = 'a'; j <= 'z'; j++)
            {
                if (chari != j)
                {
                    chars[i] = j;
                    neighbors.Add(new string(chars));
                }
            }
            chars[i] = chari; // 恢复原字符串
        }
        return neighbors;
    }

    /**
     * 
     * */
}