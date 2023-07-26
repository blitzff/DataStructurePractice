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
        // ������Ҫ��lastNum��ֵ֮����Ϊ�п���ֻ��һ��Ԫ�أ�
        // ��ô�����Լ����Լ�������remove����

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
 * ͬʱ��������͹�ϣ����ص� ���ﵽ:
 *  1. ��ɾ��O(1) (��ϣ��)
 *  2. �ȸ��ʷ��� (����)
 *  
 *  ��Remove��ʱ��, ����ǰ��ֵ���ڵ�λ�ú������ĩβ����, Ȼ��ȥ������ĩβ��ֵ
 *  ����֤O(1)
 */