using static DataStructurePractice.Graph.Graph;

namespace DataStructurePractice.LeetCode;

public class Traverse
{
    public static void bfs(Node node)
    {
        var queue = new Queue<Node>();
        var set = new HashSet<Node>();
        queue.Enqueue(node);
        set.Add(node);
        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            Console.WriteLine(cur.Id);
            foreach (var n in cur.Children)
            {
                if (!set.Contains(n))
                {
                    set.Add(n);
                    queue.Enqueue(n);
                }
            }
        }
    }

    public static void dfs(Node node)
    {
        var stack = new Stack<Node>();
        var set = new HashSet<Node>();
        stack.Push(node);
        set.Add(node);
        while (stack.Count > 0)
        {
            // 如果有相邻节点是没被遍历过的，那么再把这个节点和相邻的一个节点放回栈中
            // 否则，这个节点就是最后一个节点，取出来
            var cur = stack.Pop();
            // cur节点出入栈多次
            foreach (var n in cur.Children)
            {
                if (!set.Contains(n))
                {
                    stack.Push(cur);
                    
                    stack.Push(n);
                    set.Add(n);

                    Console.WriteLine(n.Id);

                    break;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="root"></param>
    /// <param name="record"></param>
    private void dfs(Node root, List<int> record)
    {
        record.Add(root.Id);
        // record.ToList();

        foreach (var n in root.Children)
        {
            dfs(n, record);
            record.RemoveAt(record.Count - 1);
        }
    }

}