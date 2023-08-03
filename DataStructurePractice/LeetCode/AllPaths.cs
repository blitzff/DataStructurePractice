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
     * ��ĿҪ���Ǵ�0��n-1��·��, ����������·��.
     * 
     * ˼·1: ������ת������Ϥ��ͼ�ṹ, Ȼ��DFS, ��¼һ��; ���׳���...
     * ˼·2: ֱ����������DFS����
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