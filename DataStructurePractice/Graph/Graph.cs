
namespace DataStructurePractice.Graph;

public class Graph
{
    /// <summary>
    /// ÿ���ڵ��Id����ڵ����õĶ�Ӧ��ϵ
    /// </summary>
    public Dictionary<int, Node> IdNodeMap { get; } = new Dictionary<int, Node>();
    /// <summary>
    /// ���бߵļ���
    /// </summary>
    public HashSet<Edge> Edges { get; } = new HashSet<Edge>();

    public class Node
    {
        /// <summary>
        /// �ڵ��ʶ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ֱ�����
        /// </summary>
        public int In { get; set; }
        /// <summary>
        /// ֱ�ӳ���
        /// </summary>
        public int Out { get; set; }
        /// <summary>
        /// ֱ�ӳ�ȥ�ĺ��ӽڵ�
        /// </summary>
        public List<Node> Children { get; } = new List<Node>();
        /// <summary>
        /// ����ֱ�ӳ�ȥ�ĺ��ӽڵ�ı�
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

