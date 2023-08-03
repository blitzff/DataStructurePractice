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
    /// �ӵ�ǰλ�ó���, ����������·������.
    /// </summary>
    /// <param name="mat"></param>
    /// <param name="maxMat">��¼ÿ��λ������������</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private int dfs(int[][] mat, int[,] maxMat, int row, int col)
    {
        // ���仯����, ������λ�õĽڵ��ߵ������ʱ�����ֱ��ʹ��������
        if (maxMat[row, col] != 0)
        {
            return maxMat[row, col];
        }

        int max = 1;
        int val = mat[row][col];
        // ����, ���ֻ�е������ϵ�ֵ > ��ǰֵʱ��ȥ�Ǹ�����
        // ��μ���ӵ�ǰ�ڵ����������������?
        // ��ݹ麯���ܹ�����ĳ�����ϵ�����������, ��ô��ǰ�ڵ��
        // ���������Ⱦ��� max_direction + 1
        if (row > 0 && mat[row - 1][col] > val) // �Ϸ�Ԫ��
        {
            max = Math.Max(max, 1 + dfs(mat, maxMat, row - 1, col));
        }

        if (row < mat.Length - 1 && mat[row + 1][col] > val) // �·�Ԫ��
        {
            max = Math.Max(max, 1 + dfs(mat, maxMat, row + 1, col));
        }

        if (col > 0 && mat[row][col - 1] > val) // ��Ԫ��
        {
            max = Math.Max(max, 1 + dfs(mat, maxMat, row, col - 1));
        }

        if (col < mat[0].Length - 1 && mat[row][col + 1] > val) // �ҷ�Ԫ��
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