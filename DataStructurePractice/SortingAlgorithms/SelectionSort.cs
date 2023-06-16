namespace DataStructurePractice.SortingAlgorithms;

[TestClass]
public class SelectionSort : TestBaseClass
{
    public override void Sort(int[] arr)
    {
        if (arr == null || arr.Length == 0) return;

        for (int end = arr.Length-1; end > 0; end--)
        {
            var maxIdx = 0;
            for (int i = 0; i <= end; i++)
            {
                if (arr[maxIdx] < arr[i]) maxIdx = i;
            }
            SortingHelper.Swap(arr, maxIdx, end);
        }
    }
}