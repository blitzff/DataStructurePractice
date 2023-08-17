namespace DataStructurePractice.LeetCode;

internal class CourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        if (prerequisites == null || prerequisites.Length == 0) return true;
        // 统计入度
        var graph = new Dictionary<int, Node>();
        // 有不依赖于任何课的课, 因此如果在pre时初始化节点就会漏掉, 从而导致最终
        // count != numCourses
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new Node();
        }
        foreach (var pre in prerequisites)
        {
            var to = pre[0];
            var from = pre[1];
            // 所有课程对互不相同
            graph[from].children.Add(graph[to]);
            graph[to].inDepth++;
        }

        // 队列, 遍历图节点找到入度为0的节点, 入队
        var queue = new Queue<Node>();
        foreach (var node in graph.Values)
        {
            if (node.inDepth == 0)
            {
                queue.Enqueue(node);
            }
        }

        // 每次从队列出队1个节点, 将其指向的孩子的入度-1, 如果为0接着入队
        var count = 0;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            count++;
            foreach (var child in node.children)
            {
                child.inDepth--;
                if (child.inDepth == 0)
                {
                    queue.Enqueue(child);
                }
            }
        }

        return count == numCourses;
    }

    class Node
    {
        public int inDepth;
        public List<Node> children = new List<Node>();
    }
}
