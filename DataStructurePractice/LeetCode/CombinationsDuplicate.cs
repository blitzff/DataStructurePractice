namespace DataStructurePractice.LeetCode;

public class CombinationDuplicate
{
    private List<IList<int>> res = new List<IList<int>>();
    private int[] nums;
    public IList<IList<int>> CombinationSum(int[] nums, int target)
    {
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
            dfs(target, i + 1, path);

            path.Add(nums[i]);
            dfs(target - nums[i], i, path);
            path.RemoveAt(path.Count - 1);
        }
    }

    /**
     * 依旧是回溯法，
     * 区别在于，一个位置能被选择多次
     * */
}