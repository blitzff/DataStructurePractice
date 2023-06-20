namespace DataStructurePractice.SortingAlgorithms;

[TestClass]
public class MergeSort : TestBaseClass
{
    public override void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        Sort(arr, 0, arr.Length - 1);
    }

    private void Sort(int[] arr, int L, int R)
    {
        if (L >= R) return;

        var M = (R - L) / 2 + L;
        Sort(arr, L, M);
        Sort(arr, M + 1, R);
        Merge(arr, L, M, R);    // The sorting is actually happening in this Merge process.
    }

    private void Merge(int[] arr, int L, int M, int R)
    {
        var help = new int[R - L + 1];
        var i = 0;
        var p1 = L;
        var p2 = M + 1;
        while (p1 <= M && p2 <= R)
        {
            help[i++] = arr[p1] > arr[p2] ? arr[p2++] : arr[p1++];
        }
        while (p1 <= M)
        {
            help[i++] = arr[p1++];
        }
        while (p2 <= R)
        {
            help[i++] = arr[p2++];
        }
        for (i = 0; i < help.Length; i++)
        {
            arr[L + i] = help[i];
        }
    }
}