namespace DataStructurePractice.LeetCode;

public class ArrayConcatenationValue
{
	public long FindTheArrayConcVal(int[] nums)
	{
		if (nums.Length == 1) return (long)nums[0];

		long res = 0;
		var start = 0;
		var end = nums.Length - 1;
		while (end - start > 1)
		{
			res += (long)(nums[start] * Math.Pow(10, nums[end].ToString().Length)) + nums[end];
			end--;
			start++;
		}
		if (end == start)
		{
			res += nums[end];
		}
		return res;
	}
}
