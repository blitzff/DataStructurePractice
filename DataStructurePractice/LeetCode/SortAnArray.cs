namespace DataStructurePractice.LeetCode;

public class SortAnArray
{
    public int[] SortArray(int[] arr)
    {
        //new QuickSort().Sort(arr, 0, arr.Length - 1);
        new MergeSort().Sort(arr, 0, arr.Length - 1);
        return arr;
    }

    public class MergeSort
    {
        public void Sort(int[] arr, int L, int R)
        {
            if (L >= R) return;

            var M = L + (R - L) / 2;
            Sort(arr, L, M);
            Sort(arr, M + 1, R);
            Merge(arr, L, M, R);
        }

        private void Merge(int[] arr, int L, int M, int R)
        {
            var p1 = L;
            var p2 = M + 1;
            var help = new int[R - L + 1];
            var index = 0;

            while (p1 <= M && p2 <= R)
            {
                help[index++] = arr[p1] < arr[p2] ? arr[p1++] : arr[p2++];
            }

            while (p1 <= M)
            {
                help[index++] = arr[p1++];
            }

            while (p2 <= R)
            {
                help[index++] = arr[p2++];
            }

            for (int i = 0; i < help.Length; i++)
            {
                arr[L + i] = help[i];
            }
        }
    }

    public class QuickSort
    {
        public void Sort(int[] arr, int L, int R)
    {
        if (L > R) return;
        var par = Partition(arr, L, R);
        Sort(arr, L, par[0] - 1);
        Sort(arr, par[1] + 1, R);
    }

    private int[] Partition(int[] arr, int L, int R)
    {
            var k = arr[new Random().Next(L, R + 1)];
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
            return new int[] { less + 1, greater - 1 };
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
}