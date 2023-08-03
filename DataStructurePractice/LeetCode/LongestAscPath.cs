namespace DataStructurePractice.LeetCode;

[TestClass]
public class LongestAscPath
{
    public int LongestIncreasingPath(int[][] graphMat)
    {
        int rows = graphMat.Length;
        int cols = graphMat[0].Length;
        int[,] maxMat = new int[rows, cols];
        int max = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                max = Math.Max(max, dfs(graphMat, maxMat, i, j));
            }
        }

        return max;
    }

    /// <summary>
    /// 从当前位置出发, 返回最大递增路径长度.
    /// </summary>
    /// <param name="mat"></param>
    /// <param name="maxMat">记录每个位置最大递增长度</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private int dfs(int[][] mat, int[,] maxMat, int row, int col)
    {
        // 记忆化搜索, 当其它位置的节点走到这儿的时候可以直接使用这个结果
        if (maxMat[row, col] != 0)
        {
            return maxMat[row, col];
        }

        int max = 1;
        int val = mat[row][col];
        // 递增, 因此只有当方向上的值 > 当前值时才去那个方向
        // 如何计算从当前节点出发的最大递增长度?
        // 设递归函数能够给我某方向上的最大递增长度, 那么当前节点的
        // 最大递增长度就是 max_direction + 1
        if (row > 0 && mat[row - 1][col] > val) // 上方元素
        {
            max = Math.Max(max, 1 + dfs(mat, maxMat, row - 1, col));
        }

        if (row < mat.Length - 1 && mat[row + 1][col] > val) // 下方元素
        {
            max = Math.Max(max, 1 + dfs(mat, maxMat, row + 1, col));
        }

        if (col > 0 && mat[row][col - 1] > val) // 左方元素
        {
            max = Math.Max(max, 1 + dfs(mat, maxMat, row, col - 1));
        }

        if (col < mat[0].Length - 1 && mat[row][col + 1] > val) // 右方元素
        {
            max = Math.Max(max, 1 + dfs(mat, maxMat, row, col + 1));
        }

        maxMat[row, col] = max;
        return max;
    }


    [TestMethod]
    public void test()
    {
        new LongestAscPath().LongestIncreasingPath(new int[][]
        {
            new int []{9, 9, 4},
            new int []{6, 6, 8},
            new int []{2, 1, 1}
        });
    }
}