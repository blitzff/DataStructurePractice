
namespace DataStructurePractice.Graph;

public class Graph
{
    /// <summary>
    /// 每个节点的Id和其节点引用的对应关系
    /// </summary>
    public Dictionary<int, Node> IdNodeMap { get; } = new Dictionary<int, Node>();
    /// <summary>
    /// 所有边的集合
    /// </summary>
    public HashSet<Edge> Edges { get; } = new HashSet<Edge>();

    public class Node
    {
        /// <summary>
        /// 节点标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 直接入度
        /// </summary>
        public int In { get; set; }
        /// <summary>
        /// 直接出度
        /// </summary>
        public int Out { get; set; }
        /// <summary>
        /// 直接出去的孩子节点
        /// </summary>
        public List<Node> Children { get; } = new List<Node>();
        /// <summary>
        /// 连接直接出去的孩子节点的边
        /// </summary>
        public List<Edge> Edges { get; }

        public Node(
            int value,
            int @in,
            int @out,
            List<Node> children,
            List<Edge> edges)
        {
            Id = value;
            In = @in;
            Out = @out;
            Children = children;
            Edges = edges;
        }
    }

    public class Edge
    {
        public int Weight { get; }
        public Node From { get; set; }
        public Node To { get; set; }
        public Edge(
            int weight,
            Node from,
            Node to)
        {
            Weight = weight;
            From = from;
            To = to;
        }
    }
}

