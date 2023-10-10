namespace DataStructurePractice.LeetCode;

public class VeganFriendly
{
    public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
    {
		return restaurants.Where(ele => (veganFriendly == 1 ? ele[2] == 1 : true) // 注意这个地方的括号.
			 && ele[4] <= maxDistance
			 && ele[3] <= maxPrice)
			 .OrderByDescending(ele => ele[1])
			 .ThenByDescending(ele => ele[0])
			 .Select(ele => ele[0])
			 .ToList();
	}
}
