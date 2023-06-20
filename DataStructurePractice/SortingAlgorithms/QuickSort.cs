namespace DataStructurePractice.SortingAlgorithms;

[TestClass]
public class QuickSort : TestBaseClass
{
    public override void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        Sort(arr, 0, arr.Length - 1);
    }

    private void Sort(int[] arr, int L, int R)
    {
        if (L >= R) return;

        var eqs = Partition(arr, L, R); // The sorting is actually happening in this Partition process.
        Sort(arr, L, eqs[0]-1);
        Sort(arr, eqs[1]+1, R);
    }

    /// <summary>
    /// Arrange the array to three parts using the last element:
    ///     less than | equal | greater than
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="L"></param>
    /// <param name="R"></param>
    /// <returns>new int[]{eqL, eqR}</returns>
    private int[] Partition(int[] arr, int L, int R)
    {
        var k = arr[R];
        var lt = L - 1;
        var gt = R + 1;
        var i = L;
        while (i < gt)
        {
            if (arr[i] < k)
            {
                SortingHelper.Swap(arr, i++, ++lt);
            }
            else if (arr[i] > k)
            {
                SortingHelper.Swap(arr, i, --gt);
            }
            else
            {
                i++;
            }
        }
        return new int[] { lt+1, gt-1 };
    }
}