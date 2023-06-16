namespace DataStructurePractice.SortingAlgorithms;

public static class SortingHelper
{
    public static void TestSort(Action<int[]> sorting)
    {
        TestNull(sorting);
        Test0LenArr(sorting);
        TestOrdered(sorting);
        TestUnordered(sorting);
        Console.WriteLine("Test Finished");
    }

    private static void TestUnordered(Action<int[]> sorting)
    {
        for (int len = 0; len < 99; len++)
        {
            for (int times = 0; times < 999; times++)
            {
                var arr = GenerateUnorderedArray(len);
                sorting(arr);
                IsOrdered(arr);
            }
        }
    }

    private static void TestOrdered(Action<int[]> sorting)
    {
        var orderedArr = GenerateOrderedArray();
        sorting(orderedArr);
        IsOrdered(orderedArr);
    }
    private static void TestNull(Action<int[]> sorting)
    {
        sorting(null);
    }

    private static void Test0LenArr(Action<int[]> sorting)
    {
        sorting(new int[0]);
    }

    public static int[] GenerateUnorderedArray(int len = 199)
    {
        Random random = new Random();
        int[] arr = new int[len];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(-999, 999);
        }
        return arr;
    }

    public static int[] GenerateOrderedArray()
    {
        int[] arr = new int[199];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }
        return arr;
    }

    private static void AreEqual(int[] arr1, int[] arr2)
    {
        if (arr1 == arr2) return;

        Assert.AreEqual(arr1.Length, arr2.Length);

        for (int i = 0; i < arr1.Length; i++)
        {
            Assert.AreEqual(arr1[i], arr2[i]);
        }
    }

    public static void IsOrdered(int[] arr)
    {
        var dpArr = new int[arr.Length];
        Array.Copy(arr, dpArr, arr.Length);

        Array.Sort(dpArr);

        AreEqual(dpArr, arr);
    }

    public static void Swap(int[] arr, int i, int j)
    {
        var t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    /// <summary>
    /// If the i == j, the swap will make it 0,
    /// because the arr[i] and the arr[j] are all
    /// read from the same location.
    /// At the first step, arr[i] ^ arr[j] == 0,
    /// then arr[i] == 0, arr[j] == 0.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    public static void SwapXor(int[] arr, int i, int j)
    {
        if (i == j) return;

        arr[i] = arr[i] ^ arr[j];
        arr[j] = arr[i] ^ arr[j];
        arr[i] = arr[i] ^ arr[j];
    }
}