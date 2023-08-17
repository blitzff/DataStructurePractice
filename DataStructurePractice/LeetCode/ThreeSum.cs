namespace DataStructurePractice.LeetCode;

internal class ThreeSumSolution
{
    private List<IList<int>> res = new List<IList<int>>();
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var left = 0;
        while (left < nums.Length)
        {
            TwoSum(nums, left, left+1, nums.Length - 1);
            var last = left;
            while (left < nums.Length && nums[left] == nums[last])
            {
                left++;
            }
        }
        return res;
    }

    /**
     * 三数之和a+b+c==0 => 两数之和为-c
     * 
     * 遍历nums：
     *  如果当前不是0号元素，那么跳过值和last相同的
     *  记录当前值为last
     *  创建新的list, 初始化时加入i
     *  从当前值到结束找和为-nums[i]的所有数对, 返回它们的列表集合
     *  将这个list加入结果集
     * 返回结果
     * */

    /// <summary>
    /// 从指定位置开始查找和为c的两个元素，返回元素值
    /// </summary>
    /// <param name="nums">升序</param>
    /// <param name="targetIdx">目标值的索引</param>
    /// <param name="lIdx">[0, len-1] 且小于 rightIndex</param>
    /// <param name="rIdx">[0, len-1]</param>
    /// <returns></returns>
    /// <param name="res"></param>
    private void TwoSum(
        int[] nums,
        int targetIdx,
        int lIdx,
        int rIdx)
    {
        var target = -nums[targetIdx];
        while (lIdx < rIdx)
        {
            var sum = nums[lIdx] + nums[rIdx];
            if (sum == target)
            {
                res.Add(new List<int>() { nums[targetIdx], nums[lIdx], nums[rIdx] });
                var last = lIdx;
                while (lIdx < rIdx && nums[lIdx] == nums[last])
                {
                    lIdx++;
                }
            }
            else if (sum < target)
            {
                lIdx ++;
            }
            else
            {
                rIdx--;
            }
        }
    }
}
