namespace DataStructurePractice.LeetCode;

public class SubSetsSolution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var res = new List<IList<int>>();
        dfs(0, nums, new List<int>(), res);
        return res;
    }

    private void dfs(int i, int[] nums, List<int> path, List<IList<int>> res)
    {
        if (i > nums.Length) return;

        // 到达有元素的下一个位置, 也就是nums.Length时
        // 将结果添加到res, 然后返回到上层调用4处
        // 从4处需要去掉当前层的元素, 然后再向上返回
        if (i == nums.Length)
        {
            res.Add(path.ToList());
            return;
        }

        // 不添加当前元素, 继续下一层
        dfs(i + 1, nums, path, res);

        // 添加当前元素, 继续下一层
        path.Add(nums[i]);
        dfs(i+1, nums, path, res);

        // 4 返回上层前去掉当前层的元素
        if (path.Count > 0)
        {
            path.RemoveAt(path.Count - 1);
        }
    }

    /**
     * 子集(组合)与顺序无关
     * 
     * 每一个位置可以选择加入或者不加入,
     * 所有叶子节点即为所求
     * */
}