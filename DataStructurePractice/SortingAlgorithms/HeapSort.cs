namespace DataStructurePractice.SortingAlgorithms;

[TestClass]
public class HeapSort : TestBaseClass
{
    public override void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        for (int i = 0; i < arr.Length; i++)
        {
            HeapInsert(arr, i);
        }

        for (int heapSize = arr.Length; heapSize > 0; heapSize--)
        {
            SortingHelper.Swap(arr, 0, heapSize-1 /*the last index*/);
            Heapify(arr, 0, heapSize-1 /*because of the swap, the heapSize - 1*/);
        }
    }

    /// <summary>
    /// Everytime insert an element to the heap, bubble up the element 
    /// to make the heap still heap.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index">from where to start insert to heap</param>
    private void HeapInsert(int[] arr, int index)
    {
        for (int father = (index - 1) / 2
            ; arr[father] < arr[index]
            ; index = father, father = (index - 1)/2)
        {
            SortingHelper.Swap(arr, index, father);
        }
    }

    /// <summary>
    /// Sink down an element to make the heap still heap.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index">from where to start the heapify</param>
    /// <param name="heapSize"></param>
    private void Heapify(int[] arr, int index, int heapSize)
    {
        var left = index * 2 + 1;
        while (left < heapSize)
        {
            // find the biggest element between left, right
            var right = left + 1;
            var largestChildIdx = right < heapSize && arr[right] > arr[left]
                ? right : left;
            // find the biggest element among father, left, right
            var largestIdx = arr[largestChildIdx] > arr[index]
                ? largestChildIdx : index;

            if (largestIdx == index) break;

            SortingHelper.Swap(arr, largestIdx, index);
            
            index = largestIdx;
            left = index * 2 + 1;
        }
    }
}