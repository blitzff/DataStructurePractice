namespace DataStructurePractice.UnionSet;

/// <summary>
/// 一般来说，题目会给出二维数组做关系的描述，
/// 这个二维数组会是个方形的，用一维的索引作为集合的标识。
/// 
/// 还有一种方式是将值对应为引用，引用地址成为一个集合的唯
/// 一标识；用字典来存储关系，而不是数组。
/// 见UnionSet。
/// </summary>
public class UnionSetArray
{
    private int[] father;      // 父链接数组（索引）
    private int[] size;      //（由触点索引的）各个根节点所对应的分量的大小
    private int count;    // 连通分量的数量
    
    public int Count { get; private set; }

    public UnionSetArray(int N)
    {
        count = N;

        father = new int[N];
        for (int i = 0; i < N; i++) father[i] = i;

        size = new int[N];
        for (int i = 0; i < N; i++) size[i] = 1;
    }

    public bool IsSameSet(int p, int q)
    {
        return FindHead(p) == FindHead(q);
    }

    public int FindHead(int p)
    {
        var stack = new Stack<int>();

        // 跟随链接找到根节点
        while (p != father[p])
        {
            stack.Push(p);
            p = father[p];
        }

        // 路径压缩
        while (stack.Count > 0)
        {
            father[stack.Pop()] = p;
        }

        return p;
    }
    public void Union(int p, int q)
    {
        int i = FindHead(p);
        int j = FindHead(q);
        
        if (i == j) return;

        // 将小树的根节点连接到大树的根节点
        // 这个地方小树的size没被更新，但它的信息也不会再被使用，
        // 因为都是通过father来找到头结点的，而小树的头节点已经更新了。
        var bigHead = size[i] >= size[j] ? i : j;
        var smallHead = size[i] >= size[j] ? j : i;
        
        father[smallHead] = bigHead;
        size[bigHead] = size[i] + size[j];

        // 每合并一次，集合数量-1
        count--;
    }
}