namespace DataStructurePractice.LeetCode;

public class MaxAreaOfIslandDfs
{
    public int MaxAreaOfIsland(int[][] grid)
    {

        var max = 0;
        var H = grid.Length;
        var W = grid[0].Length;
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (grid[h][w] == 1)
                {
                    max = Math.Max(max, dfs(grid, h, w));
                }
            }
        }
        return max;
    }

    public int dfs(int[][] grid, int x, int y)
    {
        if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length)
        {
            return 0;
        }

        if (grid[x][y] != 1)
        {
            return 0;
        }

        grid[x][y] = 0; // ����ǰλ�ñ��Ϊ�ѷ���

        var result = 1;
        var right = dfs(grid, x + 1, y);
        var down = dfs(grid, x, y + 1);
        var left = dfs(grid, x - 1, y);
        var up = dfs(grid, x, y - 1);

        result += right + down + left + up;
        return result;
    }

    /**
     * ��DFS�У��������¶���Ҫ���������ֻ�����Һ��£���ô
     * �������Ͻǵ�1�޷������㵽��
     * 1,0,1,
     * 1,1,1,
     * 0,0,1,
     * 
     * �ڲ��鼯�У����Ͻǵ�1�ᱻ�����������1���ڵļ��ϣ���
     * �Կ���ֻ�����Һ��¡�
     * */
}

