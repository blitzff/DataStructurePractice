namespace DataStructurePractice.SortingAlgorithms;

[TestClass]
public class HeapSort : TestBaseClass
{
    public override void Sort(int[] arr)
    {
        // TODO
    }

    private void HeapInsert(int[] arr, int index)
    {
        for (int father = (index - 1) / 2
            ; arr[father] < arr[index]
            ; index = father, father = (index - 1)/2)
        {
            SortingHelper.Swap(arr, index, father);
        }
    }
}