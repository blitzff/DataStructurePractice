namespace DataStructurePractice.LeetCode;

[TestClass]
public class CourseScheduleII
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var graph = new Dictionary<int, GraphNode>();
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new GraphNode(i, 0);
        }
        foreach (var pair in prerequisites)
        {
            var to = pair[0];
            var from = pair[1];

            var fromNode = graph[from];
            fromNode.children.Add(graph[to]);
            graph[to].inDepth++;
        }

        var queue = new Queue<GraphNode>();
        foreach (var node in graph.Values)
        {
            if (node.inDepth == 0) queue.Enqueue(node);
        }

        var res = new List<int>();
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            res.Add(node.id);
            foreach (var child in node.children)
            {
                child.inDepth--;
                if (child.inDepth == 0) queue.Enqueue(child);
            }
        }
        return res.Count == numCourses ? res.ToArray() : new int[0];
    }

    [TestMethod]
    public void test()
    {
        int[][] pre = new int[][]
        {
            new int[]{ 1, 0 }
        };
        new CourseScheduleII().FindOrder(2, pre);
    }
    
}

public class GraphNode
{
    public int id;
    public int inDepth;
    public List<GraphNode> children = new List<GraphNode>();

    public GraphNode(int id, int inDepth)
    {
        this.id = id;
        this.inDepth = inDepth;
    }
}