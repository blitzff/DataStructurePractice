namespace DataStructurePractice.LeetCode;

public class AvoidFloodSolution
{
	public int[] AvoidFlood(int[] rains)
	{
		int[] ans = new int[rains.Length];
		Array.Fill(ans, 1);
		SortedSet<int> st = new SortedSet<int>();
		Dictionary<int, int> mp = new Dictionary<int, int>();

		for (int i = 0; i < rains.Length; ++i)
		{
			// 第i天晴天时, 将i加入有序集合
			if (rains[i] == 0)
			{
				st.Add(i);
			}
			else
			{
				ans[i] = -1;
				// 不是第一次下雨
				if (mp.ContainsKey(rains[i]))
				{
					// 贪心: 找到比下雨天晚的最早的晴天
					int it = st.FirstOrDefault(n => n >= mp[rains[i]], -1);
					if (it == -1) return new int[0];
					// 找到的话, 更新ans
					ans[it] = rains[i];
					// 这个晴天被使用掉
					st.Remove(it);
				}
				// 更新下雨天的时间
				mp[rains[i]] = i;
			}
		}
		return ans;
	}
}