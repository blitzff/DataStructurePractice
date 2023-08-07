namespace DataStructurePractice.LeetCode;

[TestClass]
public class CombinationsK
{
    private IList<IList<int>> res = new List<IList<int>>();
    private int k;
    private int n;

    public IList<IList<int>> Combine(int n, int k)
    {
        if (k > n) return res;

        this.k = k; this.n = n;
        dfs(1, new List<int>());

        return res;
    }

    private void dfs(int i, List<int> path)
    {
        if (path.Count == k)
        {
            res.Add(path.ToList());
        }
        else if (i <= n)
        {
            dfs(i + 1, path);

            path.Add(i);
            dfs(i + 1, path);
            path.RemoveAt(path.Count - 1);
        }
    }

    [TestMethod]
    public void test()
    {
        new CombinationsK().Combine(4, 2);
    }
}