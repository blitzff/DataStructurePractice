namespace DataStructurePractice.LeetCode;

public class LRUCache
{
    private readonly int capacity;
    private Dictionary<int, Node> cache = new Dictionary<int, Node>();

    private Node head = new Node(-1, -1);
    private Node tail = new Node(-1, -1);

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        head.next = tail;
        tail.prev = head;
    }

    public int Get(int key)
    {
        if (cache.ContainsKey(key))
        {
            var node = cache[key];
            MoveBeforeTail(node);
            return node.value;
        }
        return -1;
    }

    private void MoveBeforeTail(Node node)
    {
        // node从原位置移除
        RemoveOriginalLocation(node);
        // node插入到队尾
        InsertBeforeTail(node);
    }

    private void RemoveOriginalLocation(Node node)
    {
        var prev = node.prev;
        var next = node.next;
        prev.next = next;
        next.prev = prev;
    }

    private void InsertBeforeTail(Node node)
    {
        // node插入到尾部
        var prev = tail.prev;
        prev.next = node;
        node.prev = prev;
        node.next = tail;
        tail.prev = node;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            var node = cache[key];
            node.value = value;
            // 更新最近访问节点
            MoveBeforeTail(node);
        }
        else // 没有节点
        {
            // 插入节点
            var node = new Node(key, value);
            cache[key] = node;
            // 插入新节点到链表尾
            InsertBeforeTail(node);
            // 删除最旧节点
            if (cache.Count > capacity)
            {
                if (head.next == tail) throw new Exception("没有节点插入");

                var oldest = head.next;
                RemoveOriginalLocation(oldest);
                cache.Remove(oldest.key);
            }
        }
    }

    class Node
    {
        public Node next;
        public Node prev;
        public int value;
        public int key;
        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
