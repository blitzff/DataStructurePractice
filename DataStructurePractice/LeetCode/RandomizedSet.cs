using System.Collections;

namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/FortPu/
/// </summary>
[TestClass]
public class RandomizedSet
{
    IList<int> nums;
    Dictionary<int, int> numIndexMap;
    Random random;

    public RandomizedSet()
    {
        nums = new List<int>();
        numIndexMap = new Dictionary<int, int>();
        random = new Random();
    }

    public bool Insert(int val)
    {
        if (numIndexMap.ContainsKey(val))
        {
            return false;
        }

        numIndexMap[val] = nums.Count;
        nums.Add(val);

        return true;
    }

    public bool Remove(int val)
    {
        if (!numIndexMap.ContainsKey(val))
        {
            return false;
        }
        int removalIndex = numIndexMap[val];
        int lastIndex = nums.Count - 1;
        int lastNum = nums[lastIndex];
        
        numIndexMap[lastNum] = removalIndex;
        numIndexMap.Remove(val);
        // 这句必须要在lastNum赋值之后，因为有可能只有一个元素，
        // 那么就是自己跟自己交换再remove掉。

        nums[removalIndex] = lastNum;
        nums.RemoveAt(lastIndex);
        return true;
    }

    public int GetRandom()
    {
        int randomIndex = random.Next(nums.Count);
        return nums[randomIndex];
    }

    [TestMethod]
    public void test()
    {
        var set = new RandomizedSet();
        var list = new ArrayList();
        list.Add(set.Remove(0));
        list.Add(set.Remove(0));
        list.Add(set.Insert(0));
        list.Add(set.GetRandom());
        list.Add(set.Remove(0));
        list.Add(set.Insert(0));
        foreach (var item in list)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

/**
 * 同时利用数组和哈希表的特点 来达到:
 *  1. 增删查O(1) (哈希表)
 *  2. 等概率返回 (数组)
 *  
 *  在Remove的时候, 将当前的值所在的位置和数组的末尾交换, 然后去掉数组末尾的值
 *  来保证O(1)
 */