using System.Collections.ObjectModel;

namespace DataStructurePractice.UnionSet;

public class UnionSet<V>
{
    /// <summary>
    /// V to node, never change after initialize.
    /// </summary>
    public readonly Dictionary<V, Node<V>> valueNodeMap = new Dictionary<V, Node<V>>();

    /// <summary>
    /// Record every node and the set it belongs to (set's head node).
    /// </summary>
    public Dictionary<Node<V>, Node<V>> nodeParentMap = new Dictionary<Node<V>, Node<V>>();

    /// <summary>
    /// Record set's head only and its size.
    /// </summary>
    public Dictionary<Node<V>, int> headSizeMap = new Dictionary<Node<V>, int>();

    public UnionSet(Collection<V> values)
    {
        foreach (var val in values)
        {
            var node = new Node<V>(val);
            valueNodeMap.Add(val, node);
            nodeParentMap.Add(node, node);
            headSizeMap.Add(node, 1);
        }
    }

    private Node<V> FindHead(V v)
    {
        var stack = new Stack<Node<V>>();

        var node = valueNodeMap[v];
        while (node != nodeParentMap[node])
        {
            stack.Push(node);
            node = nodeParentMap[node];
        }

        while (stack.Count >= 0)
        {
            nodeParentMap[stack.Pop()] = node;
        }

        return node;
    }

    public void Union(V a, V b)
    {
        if (!valueNodeMap.ContainsKey(a) || !valueNodeMap.ContainsKey(b))
        {
            return;
        }

        var aHead = FindHead(a);
        var bHead = FindHead(b);

        if (aHead == bHead)
        {
            return;
        }

        var aSize = headSizeMap[aHead];
        var bSize = headSizeMap[bHead];

        var bigHead = aSize >= bSize ? aHead : bHead;
        var smallHead = aSize >= bSize ? bHead : aHead;

        nodeParentMap[smallHead] = bigHead;
        headSizeMap[bigHead] = aSize + bSize;
        headSizeMap.Remove(smallHead);
    }

    public bool IsSameSet(V a, V b)
    {
        if (!valueNodeMap.ContainsKey(a) || !valueNodeMap.ContainsKey(b))
        {
            return false;
        }

        return FindHead(a) == FindHead(b);
    }

    public class Node<V>
    {
        private V value;
        public V Value { get; private set; }
        public Node(V value)
        {
            this.value = value;
        }
    }
}

