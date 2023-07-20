namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/max-area-of-island/
/// 
/// m == grid.length
/// n == grid[i].length
/// 1 <= m, n <= 50
/// grid[i][j] Ϊ 0 �� 1
/// </summary>
public class MaxAreaOfIslandSolution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var us = new UnionSet(grid, m, n);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    var curId = i * n + j;
                    var idown = i + 1;
                    var jright = j + 1;
                    if (jright < n && grid[i][jright] == 1)
                    {
                        us.Union(i * n + jright, curId);
                    }
                    if (idown < m && grid[idown][j] == 1)
                    {
                        us.Union(idown * n + j, curId);
                    }
                }
            }
        }

        if (us.count == 0) return 0;
        return us.size.Max();
    }

    public class UnionSet
    {
        public int[] father;
        public int[] size;
        public int count = 0;

        public UnionSet(int[][] grid, int m, int n)
        {
            father = new int[m*n];
            size = new int[m*n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var curId = i * n + j;

                    if (grid[i][j] == 1)
                    {
                        size[curId] = 1;
                        father[curId] = curId;
                        count++;
                    }
                    else
                    {
                        size[curId] = 0;
                        father[curId] = -1;
                    }
                }
            }
        }

        public int FindFather(int p)
        {
            if (p == father[p])
            {
                return p;
            }

            return father[p] = FindFather(father[p]);
        }

        public void Union(int p, int q)
        {
            var pHead = FindFather(p);
            var qHead = FindFather(q);

            if (pHead == qHead) return;

            var pSize = size[pHead];
            var qSize = size[qHead];

            var bigHead = pSize >= qSize ? pHead : qHead;
            var smallHead = pSize >= qSize ? qHead : pHead;

            father[smallHead] = bigHead;
            size[bigHead] = pSize + qSize;
            count--;
        }
    }

    /**
     * size.Max
     * 
     * ���鼯
     * - id: i * n + j
     * - ���黹���ֵ�? ��������Ļ�, ���ںܶ�0��������˷ѿռ�, ���� 1 <= m, n <= 50, ���Բ����������
     * - father : int[m*n]
     * - size : int[m*n]
     * - count : int
     * 
     * ���ܳ��ֵĴ���:
     * 1. Union�����еı���
     * 2. UnionSet�ĳ�ʼ�����̵Ŀ���
     * 3. ����ʱ����grid�߽�Ŀ���
     * */
}