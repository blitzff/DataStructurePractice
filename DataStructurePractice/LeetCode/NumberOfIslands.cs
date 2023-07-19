namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/number-of-islands/
/// 
/// m == grid.length
/// n == grid[i].length
/// 1 <= m, n <= 300
/// grid[i][j] ��ֵΪ '0' �� '1'
/// </summary>
public class Solution
{
    public int NumIslands(char[][] grid)
    {
        var us = new UnionSet(grid);

        var h = grid.Length;
        var w = grid[0].Length;

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (grid[i][j] == '0')
                {
                    continue;
                }

                var idown = i + 1;
                var jright = j + 1;
                // i, jright; idown, j
                var rightId = i * w + jright;
                var downId = idown * w + j;
                var curId = i * w + j;
                
                if (jright < w && us.idNodeMap.ContainsKey(rightId))
                {
                    us.Union(us.idNodeMap[rightId], us.idNodeMap[curId]);
                }

                if (idown < h && us.idNodeMap.ContainsKey(downId))
                {
                    us.Union(us.idNodeMap[downId], us.idNodeMap[curId]);
                }
            }
        }

        return us.fatherSizeMap.Count;
    }

    /**
     * ���鼯��
     *  - ��ʲô����������
     *      1. ����[i][j]��������μ�¼��Ӧ���ڵ㣬��
     *      2. ���ã���i,j��װ��һ���ڵ���
     *  - ��Ҫһ��i,j�����õ�ӳ���Ա�����Ѵ�Ľڵ㣬��idΪi*w+j
     *  - idNodeMap
     *  - nodeFatherMap : ÿ�����켰���Ӧ�ĸ��ڵ�
     *  - fatherSizeMap : ��������
     * 
     * ����
     * ��ǰΪ1��
     *  - �Ҳ���²����ҲΪ1����ô�����뵱ǰ�ڵ�ϲ�
     * ��ǰ��Ϊ1��
     *  - ������һ��Ԫ��
     * */

    public class UnionSet
    {
        public Dictionary<int, Node> idNodeMap = new Dictionary<int, Node>();
        public Dictionary<Node, Node> nodeFatherMap = new Dictionary<Node, Node>();
        public Dictionary<Node, int> fatherSizeMap = new Dictionary<Node, int>();

        public UnionSet(char[][] grid)
        {
            var h = grid.Length;
            var w = grid[0].Length;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    var land = grid[i][j];
                    if (land == '1')
                    {
                        var node = new Node(i, j);
                        idNodeMap[i * w + j] = node;
                        nodeFatherMap[node] = node;
                        fatherSizeMap[node] = 1;
                    }
                }
            }
        }

        public Node FindFather(Node node)
        {
            var stack = new Stack<Node>();

            while (node != nodeFatherMap[node])
            {
                stack.Push(node);
                node = nodeFatherMap[node];
            }

            while (stack.Count > 0)
            {
                nodeFatherMap[stack.Pop()] = node;
            }
            return node;
        }

        public bool IsSameSet(Node a, Node b)
        {
            return FindFather(a) == FindFather(b);
        }

        public void Union(Node a, Node b)
        {
            var aHead = FindFather(a);
            var bHead = FindFather(b);
            if (aHead == bHead) { return; }

            var aSize = fatherSizeMap[aHead];
            var bSize = fatherSizeMap[bHead];

            var bigHead = aSize >= bSize ? aHead : bHead;
            var smallHead = aSize >= bSize ? bHead : aHead;

            nodeFatherMap[smallHead] = bigHead;

            fatherSizeMap[bigHead] = aSize + bSize;
            fatherSizeMap.Remove(smallHead);
        }
    }

    public class Node
    {
        public int i;
        public int j;

        public Node(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }

    /**
     * ʵ�ֵĹ����г�����������
     * 1. һ��������id���ʼ���ǵ�i*10+j����һ��һ��Ԫ�س���10��id�ļ���ͻ������
     * 2. �ںϲ�����ʱ����û���Ǳ߽磬��Ϊ��Ϊ���Խ��Ͳ����ڲ��鼯���������������
     * ��������⣺���磬n��1�еģ���ĳһ�г��߽��id��Ȼ�ܳ����ڲ��鼯�У����ǽڵ��
     * ����������⡣
     * 
     * �ܵĴ�˼·��û����ģ�66.
     * */
}