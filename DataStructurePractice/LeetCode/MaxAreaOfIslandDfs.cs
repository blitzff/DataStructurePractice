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

        grid[x][y] = 0; // 将当前位置标记为已访问

        var result = 1;
        var right = dfs(grid, x + 1, y);
        var down = dfs(grid, x, y + 1);
        var left = dfs(grid, x - 1, y);
        var up = dfs(grid, x, y - 1);

        result += right + down + left + up;
        return result;
    }

    /**
     * 在DFS中，左右上下都需要遍历，如果只遍历右和下，那么
     * 下面右上角的1无法被计算到。
     * 1,0,1,
     * 1,1,1,
     * 0,0,1,
     * 
     * 在并查集中，右上角的1会被并入它下面的1所在的集合，所
     * 以可以只考虑右和下。
     * */
}

