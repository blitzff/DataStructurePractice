namespace DataStructurePractice.LeetCode;

[TestClass]
public class MinFallingPath
{
    private int[][] grid;
    private int min = int.MaxValue;
    public int MinFallingPathSum(int[][] grid)
    {
        if (grid.Length == 1) return grid[0][0];
        this.grid = grid;

        // 从第一行的每个位置开始
        for (int i = 0; i < grid.Length; i++)
        {
            var path = new List<int>();
            dfs(i, 0, path);
        }

        return min == int.MaxValue ? 0 : min;
    }

    // 当前行的每个位置，每次递归到下一行
    private void dfs(int col, int row, List<int> path)
    {
        if (row == grid.Length)
        {
            min = Math.Min(path.Sum(), min);
        }
        else if (row < grid.Length)
        {
            path.Add(grid[row][col]);

            for (int nextCol = 0; nextCol < grid[0].Length; nextCol++)
            {
                if (col != nextCol)
                {
                    dfs(nextCol, row + 1, path);
                }
            }

            path.RemoveAt(path.Count - 1);
        }
    }

    [TestMethod]
    public void test()
    {
        var arr = new int[][]
        {
            new int[] {1,2,3},
            new int[] {4,5,6},
            new int[] {7,8,9}
        };
        new MinFallingPath().MinFallingPathSum(arr);
    }
}

