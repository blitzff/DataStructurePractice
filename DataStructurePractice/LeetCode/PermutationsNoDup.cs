namespace DataStructurePractice.LeetCode;

public class PermutationsNoDup
{
    private List<IList<int>> res = new List<IList<int>>();
    private int[] arr;
    public IList<IList<int>> PermuteUnique(int[] arr)
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
            var set = new HashSet<int>();
            for (int j = i; j < arr.Length; j++)
            {
                if (!set.Contains(arr[j]))
                {
                    set.Add(arr[j]);
                    swap(i, j);
                    helper(i + 1);
                    swap(i, j);
                }
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
}