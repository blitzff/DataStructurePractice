namespace DataStructurePractice.LeetCode;

public class LFUCache
{
    class Node
    {
        public int key;
        public int val;
        public int freq;

        public Node prev;
        public Node next;

        public Node(int key, int val, int freq)
        {
            this.key = key;
            this.val = val;
            this.freq = freq;
        }
    }

    /// <summary>
    /// 最新的插到队尾
    /// 队首的是最旧的
    /// </summary>
    class DoubleLinkedList
    {
        public Node dummyHead;
        public Node dummyTail;

        public int Count { get; private set; }

        public DoubleLinkedList()
        {
            dummyHead = new Node(-1, -1, -1);
            dummyTail = new Node(-1, -1, -1);
            dummyHead.next = dummyTail;
            dummyTail.prev = dummyHead;
            Count = 0;
        }

        public void AddNewest(Node node)
        {
            var prev = dummyTail.prev;
            prev.next = node;
            node.prev = prev;
            node.next = dummyTail;
            dummyTail.prev = node;

            Count++;
        }

        public Node RemoveOldest()
        {
            var node = GetOldest();
            Remove(node);
            return node;
        }

        public void Remove(Node node)
        {
            Count--;
            var prev = node.prev;
            var next = node.next;
            prev.next = next;
            next.prev = prev;
        }

        public Node GetOldest()
        {
            if (Count == 0) throw new ArgumentException("No node in the list");
            return dummyHead.next;
        }

        public Node GetNewest()
        {
            if (Count == 0) throw new ArgumentException("No node in the list");
            return dummyTail.prev;
        }
    }

    private readonly int capacity;
    private int minFreq;

    private Dictionary<int, Node> keyValue = new Dictionary<int, Node>();
    private Dictionary<int, DoubleLinkedList> freqValue = new Dictionary<int, DoubleLinkedList>();

    public LFUCache(int capacity)
    {
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (capacity == 0) return -1;
        if (!keyValue.ContainsKey(key)) return -1;

        var node = keyValue[key];

        Update(node);
        
        return node.val;
    }

    private void Update(Node node)
    {
        // 从原有频率列表中移出
        var freqList = freqValue[node.freq];
        freqList.Remove(node);
        if (freqList.Count == 0)
        {
            freqValue.Remove(node.freq);
            minFreq = minFreq == node.freq ? ++minFreq : minFreq;
        }

        // 加入新频率列表
        freqValue.TryAdd(++node.freq, new DoubleLinkedList());
        freqValue[node.freq].AddNewest(node);
    }

    public void Put(int key, int value)
    {
        if (capacity == 0) return;

        if (keyValue.ContainsKey(key))
        {
            var node = keyValue[key];
            // 更新值
            node.val = value;

            Update(node);
        }
        else
        {
            // 添加后会超出容量
            if (keyValue.Count >= capacity)
            {
                // 移除最不经常使用的项
                var freqList = freqValue[minFreq];
                var newest = freqList.RemoveOldest();
                if (freqList.Count == 0)
                {
                    freqValue.Remove(minFreq);
                }
                // 移除cache
                keyValue.Remove(newest.key);
            }
            // 添加节点
            AddNewNode(key, value);
            // 更新最小频率到1
            minFreq = 1;
        }
    }

    private void AddNewNode(int key, int value)
    {
        var node = new Node(key, value, 1);
        // 插入节点
        keyValue[key] = node;
        // 维护频率
        freqValue.TryAdd(1, new DoubleLinkedList());
        freqValue[1].AddNewest(node);
    }

    /*
     * 双哈希表
     * 1. <键, 值>
     * 2. <频率, 频率列表>
     * 
     * 如果超出capacity 要移除最小的频率的最旧的节点(最不经常使用) least frequentyly used
     * 
     * 怎么找到最小频率?
     * 如果当前频率的双向链表只有一个元素, 并且当前是最小频率, 那么这个频率列表被移除到0个元素后, minFreq = freq+1
     * 因为freq是从1开始每次迭代1的, 所以它的顺序就是1,2,3,4,...
     * 
     * 注意:
     *  GetValueOrDefault 并不会插入键, 它在获取失败后仅返回默认值. 
     *  在每次加入新节点时TryAdd, TryAdd在有键时不会添加, 直接返回false
     */
}
