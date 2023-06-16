namespace DataStructurePractice.SortingAlgorithms;

[TestClass]
public class BubbleSort : TestBaseClass
{
    /// <summary>
    /// Every iteration make 1 element sorted at the end of the array.
    /// </summary>
    /// <param name="array"></param>
    public override void Sort(int[] array)
    {
        if (array == null || array.Length == 0) return;

        for (int end = array.Length-1; end > 0; end--)
        {
            for (int i = 0; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    SortingHelper.SwapXor(array, i, i + 1);
                }
            }
        }
    }
}