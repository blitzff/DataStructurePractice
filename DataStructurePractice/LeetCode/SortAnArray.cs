namespace DataStructurePractice.LeetCode;

public class SortAnArray
{
    public int[] SortArray(int[] arr)
    {
        Sort(arr, 0, arr.Length - 1);
        return arr;
    }

    private void Sort(int[] arr, int L, int R)
    {
        if (L > R) return;
        var par = Partition(arr, L, R);
        Sort(arr, L, par[0] - 1);
        Sort(arr, par[1] + 1, R);
    }

    private int[] Partition(int[] arr, int L, int R)
    {
        var k = arr[new Random().Next(L, R+1)];
        var less = L - 1;
        var greater = R + 1;
        var i = L;
        while (i < greater)
        {
            if (arr[i] < k)
            {
                Swap(arr, i++, ++less);
            }
            else if (arr[i] > k)
            {
                Swap(arr, i, --greater);
            }
            else
            {
                i++;
            }
        }
        return new int[] { less+1, greater-1 };
    }

    private void Swap(int[] arr, int i, int j)
    {
        var temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    /**
     * 先写partition过程
     * 参数、返回值是什么？
     * */
}