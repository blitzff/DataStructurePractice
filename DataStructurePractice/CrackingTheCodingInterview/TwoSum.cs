namespace DataStructurePractice.CrackingTheCodingInterview;


/// <summary>
/// https://leetcode.cn/problems/two-sum/description/
/// 
/// 非排序数组, 无法使用双指针.
/// </summary>
public class TwoSumSolution
{
    public int[] TwoSum(int[] arr, int target)
    {
        // <值, 索引>
        var dic = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            var val = arr[i];
            if (dic.ContainsKey(target - val))
                return new int[] { i, dic[target - val] };

            dic[val] = i;
        }
        return new int[0];
    }
}