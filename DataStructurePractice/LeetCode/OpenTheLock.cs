namespace DataStructurePractice.LeetCode;

[TestClass]
public class OpenTheLock
{
    public int OpenLock(string[] deadends, string target)
    {
        var deadSet = new HashSet<string>(deadends);
        if (deadends.Contains("0000")) return -1;
        var count = 0;

        var visited = new HashSet<string>();
        var q1 = new Queue<string>();
        var q2 = new Queue<string>();
        q1.Enqueue("0000");
        visited.Add("0000");
        while (q1.Count > 0)
        {
            var current = q1.Dequeue();
            // ����ʲô����ʱ����
            if (current.Equals(target)) { return count; }

            // ��β���nexts
            var nexts = GetNexts(current);
            foreach (var n in nexts)
            {
                if (!deadSet.Contains(n) && !visited.Contains(n))
                {
                    q2.Enqueue(n);
                    visited.Add(n);
                }
                // �������dead�����������ԣ�count�������¼���
            }

            if (q1.Count == 0)
            {
                count++;
                q1 = q2;
                q2 = new Queue<string>();
            }
        }
        return -1;
    }

    private List<string> GetNexts(string code)
    {
        // ÿ��λ���Ͽ�����ǰһ���������һ��
        var nexts = new List<string>();

        var chars = code.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            var originalCh = chars[i];
            // +1
            chars[i] = chars[i] == '9' ? '0' : (char)(chars[i] + 1);
            nexts.Add(new string(chars));
            chars[i] = originalCh; // ��ԭ

            // -1
            chars[i] = chars[i] == '0' ? '9' : (char)(chars[i] - 1);
            nexts.Add(new string(chars));
            chars[i] = originalCh;
        }
        return nexts;
    }

    [TestMethod]
    public void test()
    {
        var deadends = new string [] { "8888" };
        var target = "0009";
        new OpenTheLock().OpenLock(deadends, target);
    }
}