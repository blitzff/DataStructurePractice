namespace DataStructurePractice.LeetCode;

public class Permutations
{
    private List<IList<int>> res = new List<IList<int>>();
    private int[] arr;

    public IList<IList<int>> Permute(int[] arr)
    {
        this.arr = arr;
        helper(0);
        return res;
    }

    private void helper(int i)
    {
        if (i == arr.Length)
        {
            res.Add(arr.ToList());
        }
        else if (i < arr.Length)
        {
            for (int j = i; j < arr.Length; j++) // 1.
            {
                swap(i, j); // 2.
                helper(i + 1); // 3.
                swap(i, j);
            }
        }
    }

    private void swap(int i, int j)
    {
        if (i == j) return;

        var temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    /**
     * 1. 每次从 [i, n-1] 选一个数和i位置交换
     * 2. i位置能选的有n-i个数
     * 3. 每次选择了i位置的数之后就继续选择i+1位置的数
     * */
}