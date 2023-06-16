namespace DataStructurePractice.SortingAlgorithms;

[TestClass]
public class InsertionSort : TestBaseClass
{
    public override void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        for (int i = 1; i < arr.Length; i++)
        {
            for (int j = i;  j > 0 && arr[j - 1] > arr[j]; j--)
            {
                SortingHelper.Swap(arr, j, j - 1);
            }
        }
    }
}