namespace DataStructurePractice.LeetCode;

public class TupleWithSameProduct
{
	public int TupleSameProduct(int[] nums)
	{
		var productMap = new Dictionary<int, int>();
		for(var i = 0; i < nums.Length; i++)
		{
			for (var j = i+1; j < nums.Length; j++)
			{
				var product = nums[i] * nums[j];
				productMap.TryAdd(product, 0);
				productMap[product]++;
			}
		}

		var ans = 0;
		foreach (var product in productMap.Keys)
		{
			var num = productMap[product];
			if (num >= 2)
			{
				ans += (num * (num - 1) / 2);
			}
		}

		return ans * 8;
	}

	/*
	 * n * (n-1) / 2
	 * */
}
