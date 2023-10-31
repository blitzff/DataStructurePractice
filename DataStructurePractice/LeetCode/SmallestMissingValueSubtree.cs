namespace DataStructurePractice.LeetCode;


[TestClass]
public class SmallestMissingValueSubtreeSolution
{
    public int[] SmallestMissingValueSubtree(int[] parents, int[] nums)
    {
        int n = parents.Length;
        // 表示一个图, id及id的孩子
        IList<int>[] children = new IList<int>[n];
        for (int i = 0; i < n; i++)
        {
            children[i] = new List<int>();
        }
        // 每个id的孩子id计入children列表
        for (int i = 1; i < n; i++)
        {
            children[parents[i]].Add(i);
        }

        int[] res = new int[n];
        Array.Fill(res, 1);
        ISet<int>[] geneSet = new ISet<int>[n];
        for (int i = 0; i < n; i++)
        {
            geneSet[i] = new HashSet<int>();
        }
        DFS(0, res, nums, children, geneSet);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(geneSet[i].Count);
        }
        return res;
    }

    // 返回以node为根的子树的最小缺失基因值
    public int DFS(int node, int[] res, int[] nums, IList<int>[] children, ISet<int>[] geneSet)
    {
        var geneval = nums[node];
        geneSet[node].Add(geneval); // 每棵子树统计自己的基因值
        foreach (int child in children[node])
        {
            // 所有子树中的最大的缺失基因值
            res[node] = Math.Max(res[node], DFS(child, res, nums, children, geneSet));
            // 总是让 geneSet[node] 是大, geneSet[child] 是小
            // 避免OOM
            // 在用例2的时候, 最后打印出的数量 6 1 1 3 1 1 正是因为此处的交换
            if (geneSet[node].Count < geneSet[child].Count)
            {
                ISet<int> temp = geneSet[node];
                geneSet[node] = geneSet[child];
                geneSet[child] = temp;
            }
            // 将小的加入大的
            foreach (int val in geneSet[child])
            {
                geneSet[node].Add(val);
            }
        }
        // 当前geneSet[node]包含所有子节点
        // O(n), res[node]最开始初始化默认值为1
        while (geneSet[node].Contains(res[node]))
        {
            res[node]++;
        }
        return res[node];
    }

    [TestMethod]
    public void test()
    {
        var parents = new int[] { -1, 0, 1, 0, 3, 3 };
        var nums = new int[] { 5, 4, 6, 2, 1, 3 };
        new SmallestMissingValueSubtreeSolution().SmallestMissingValueSubtree(parents, nums);
    }
}
