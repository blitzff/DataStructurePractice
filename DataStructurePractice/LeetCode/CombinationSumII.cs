namespace DataStructurePractice.LeetCode;

public class CombinationSumII
{
    private int[] nums;
    private List<IList<int>> res = new List<IList<int>>();
    public IList<IList<int>> CombinationSum2(int[] nums, int target)
    {
        Array.Sort(nums);
        this.nums = nums;
        dfs(target, 0, new List<int>());
        return res;
    }

    private void dfs(int target, int i, List<int> path)
    {
        if (target == 0)
        {
            res.Add(path.ToList());
        }
        else if (target > 0 && i < nums.Length)
        {
            dfs (target, GetNexti(i), path);

            path.Add(nums[i]);
            dfs(target - nums[i], i + 1, path);
            path.RemoveAt(path.Count - 1);
        }
    }

    private int GetNexti(int i)
    {
        var k = nums[i ++];
        while (i < nums.Length && nums[i] == k)
        {
            i++;
        }
        return i;
    }
}