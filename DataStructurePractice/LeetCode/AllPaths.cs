namespace DataStructurePractice.LeetCode;

[TestClass]
public class AllPaths
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] mat)
    {
        N = mat.Length;

        dfs(mat, 0, new List<int>());

        return res;
    }

    List<IList<int>> res = new List<IList<int>>();
    int N;

    private void dfs(int[][] mat, int index, List<int> record)
    {
        record.Add(index);
        if (index == N - 1)
        {
            res.Add(record.ToList());
        }

        var nexts = mat[index];
        foreach (var n in nexts)
        {
            dfs(mat, n, record);
            record.RemoveAt(record.Count - 1);
        }
    }

    /**
     * 题目要求是从0到n-1的路径, 并不是所有路径.
     * 
     * 思路1: 将数组转换成熟悉的图结构, 然后DFS, 记录一遍; 容易出错...
     * 思路2: 直接在数组上DFS遍历
     * */

    [TestMethod]
    public void test()
    {
        new AllPaths().AllPathsSourceTarget(
            new int[][]
            {
                new int[] { 4,3,1 },
                new int[] { 3,2,4 },
                new int[] {  },
                new int[] { 4 },
                new int[] {  }
            });
    }

}