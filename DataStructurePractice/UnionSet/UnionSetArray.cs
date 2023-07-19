namespace DataStructurePractice.UnionSet;

/// <summary>
/// һ����˵����Ŀ�������ά��������ϵ��������
/// �����ά������Ǹ����εģ���һά��������Ϊ���ϵı�ʶ��
/// 
/// ����һ�ַ�ʽ�ǽ�ֵ��ӦΪ���ã����õ�ַ��Ϊһ�����ϵ�Ψ
/// һ��ʶ�����ֵ����洢��ϵ�����������顣
/// ��UnionSet��
/// </summary>
public class UnionSetArray
{
    private int[] father;      // ���������飨������
    private int[] size;      //���ɴ��������ģ��������ڵ�����Ӧ�ķ����Ĵ�С
    private int count;    // ��ͨ����������
    
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

        // ���������ҵ����ڵ�
        while (p != father[p])
        {
            stack.Push(p);
            p = father[p];
        }

        // ·��ѹ��
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

        // ��С���ĸ��ڵ����ӵ������ĸ��ڵ�
        // ����ط�С����sizeû�����£���������ϢҲ�����ٱ�ʹ�ã�
        // ��Ϊ����ͨ��father���ҵ�ͷ���ģ���С����ͷ�ڵ��Ѿ������ˡ�
        var bigHead = size[i] >= size[j] ? i : j;
        var smallHead = size[i] >= size[j] ? j : i;
        
        father[smallHead] = bigHead;
        size[bigHead] = size[i] + size[j];

        // ÿ�ϲ�һ�Σ���������-1
        count--;
    }
}