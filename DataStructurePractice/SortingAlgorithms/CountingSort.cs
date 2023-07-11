namespace DataStructurePractice.SortingAlgorithms;

[TestClass]
public class CountingSort : TestBaseClass
{
    /// <summary>
    /// Generally, the arr stastified some conditions.
    /// </summary>
    /// <param name="arr"></param>
    public override void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        // for example, [-10, 4], offset = 10 => [0, 14]
        var min = arr.Min();
        var max = arr.Max();

        var help = new int[max - min + 1];
        var offset = 0 - min;
        for (int i = 0; i < arr.Length; i++)
        {
            var idx = arr[i] + offset;
            help[idx] += 1;
        }
        int j = 0;
        for (int i = 0; i < help.Length; i++)
        {
            while (help[i] > 0)
            {
                arr[j++] = i - offset;
                help[i]--;
            }
        }
    }
}