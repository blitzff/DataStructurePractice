namespace DataStructurePractice.LeetCode;

public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        // ��Ŀ����
        var length = 1;
        // ��ĿҪ��
        var notVisited = new HashSet<string>(wordList);

        var q1 = new Queue<string>();
        var q2 = new Queue<string>();
        q1.Enqueue(beginWord); // �����һ���ڵ�
        while (q1.Count > 0)
        {
            var word = q1.Dequeue();
            // ��ǰ��ֹ
            if (word.Equals(endWord))
            {
                return length;
            }

            // �����������ɽ������Ľڵ�
            var neighbors = GetNeighbors(word);
            foreach (var neighbor in neighbors)
            {
                if (notVisited.Contains(neighbor))
                {
                    q2.Enqueue(neighbor);
                    notVisited.Remove(neighbor);
                }
            }

            // ����1Ϊ��ʱ��ǰ�����
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
        // ��ÿһ��λ���϶���26��Сд��ĸ�滻�õ��ھ��ַ���
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
            chars[i] = chari; // �ָ�ԭ�ַ���
        }
        return neighbors;
    }

    /**
     * 
     * */
}