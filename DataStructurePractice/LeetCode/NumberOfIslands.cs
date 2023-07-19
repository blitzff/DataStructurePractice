namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/number-of-islands/
/// 
/// m == grid.length
/// n == grid[i].length
/// 1 <= m, n <= 300
/// grid[i][j] 的值为 '0' 或 '1'
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
     * 并查集：
     *  - 用什么来做索引？
     *      1. 索引[i][j]，考虑如何记录对应父节点，×
     *      2. 引用，将i,j封装到一个节点里
     *  - 需要一个i,j到引用的映射以便查找已存的节点，定id为i*w+j
     *  - idNodeMap
     *  - nodeFatherMap : 每个岛屿及其对应的父节点
     *  - fatherSizeMap : 岛屿数量
     * 
     * 遍历
     * 当前为1：
     *  - 右侧和下侧如果也为1，那么将其与当前节点合并
     * 当前不为1：
     *  - 遍历下一个元素
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
     * 实现的过程中出了两处错误
     * 1. 一个是索引id，最开始考虑的i*10+j，但一旦一行元素超过10，id的计算就会出错了
     * 2. 在合并岛屿时故意没考虑边界，因为认为如果越界就不会在并查集的索引表里，但，这
     * 会带来问题：例如，n行1列的，在某一行出边界后，id仍然能出现在并查集中，但是节点的
     * 意义出现问题。
     * 
     * 总的大思路是没问题的，66.
     * */
}