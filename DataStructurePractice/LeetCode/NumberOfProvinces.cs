namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/number-of-provinces/
/// 1 <= n <= 200
/// n == isConnected.length
/// n == isConnected[i].length
/// isConnected[i][j] 为 1 或 0
/// isConnected[i][i] == 1
/// isConnected[i][j] == isConnected[j][i]
/// </summary>
public class NumberOfProvinces
{
    public int FindCircleNum(int[][] isConnected)
    {
        var n = isConnected.Length;

        var us = new UnionSet(n);

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (isConnected[i][j] == 1)
                {
                    us.Union(j, i);
                }
            }
        }

        return us.count;
    }

    public class UnionSet
    {
        public int[] father;
        public int[] size;
        public int count;

        public UnionSet(int n)
        {
            father = new int[n];
            size = new int[n];
            count = n;

            for (int i = 0; i < n; i++)
            {
                father[i] = i;
                size[i] = 1;
            }
        }

        public int FindFather(int a)
        {
            if (father[a] == a)
                return a;

            return father[a] = FindFather(father[a]);
        }

        public void Union(int a, int b)
        {
            var aHead = FindFather(a);
            var bHead = FindFather(b);

            if (aHead == bHead) return;

            var aSize = size[aHead];
            var bSize = size[bHead];

            var bigSet = aSize >= bSize ? aHead : bHead;
            var smallSet = aSize >= bSize ? bHead : aHead;

            father[smallSet] = bigSet;
            size[bigSet] = aSize + bSize;
            count--;
        }
    }

    /**
     * 1 <= n <= 200, 不需要考虑空的问题
     * 是个方形的矩阵
     * 只遍历一半对角线就行
     * 
     * 并查集：
     * - 每个索引代表一个城市, 一共n个, 矩阵描述了它们之间的关系;
     * - 省份的数量是最终的集合个数.
     * - father: int[n]
     * - size: int[n]
     * - count: int, 初始化为n
     * */
}