namespace DataStructurePractice.LeetCode;

public class RelativeSortArraySolution
{
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        var bucket = new int[1001]; // [0, 1000]
        for (int i = 0; i < arr1.Length; i++)
        {
            var bucketNo = arr1[i];
            bucket[bucketNo]++;
        }

        // 按arr2的相对顺序将arr1填充
        var j = 0;
        for (int i = 0; i < arr2.Length; i++)
        {
            var bucketNo = arr2[i];
            while (bucket[bucketNo] > 0)
            {
                arr1[j++] = bucketNo;
                bucket[bucketNo] --;
            }
        }

        // 将桶中剩余数字按升序赋值给arr1
        for (int i = 0; i < bucket.Length; i++)
        {
            while (bucket[i] > 0)
            {
                arr1[j++] = i;
                bucket[i] --;
            }
        }

        return arr1;
    }

    /**
     * arr1中可能出现arr2中不存在的元素
     * 
     * 1 <= arr1.length, arr2.length <= 1000
     * 0 <= arr1[i], arr2[i] <= 1000
     * arr2 中的元素 arr2[i] 各不相同
     * arr2 中的每个元素 arr2[i] 都出现在 arr1 中
     * 
     * 长度1000, 元素大小1001
     * 
     * 准备一个大小为1001的数组bucket
     * 计数排序统计一遍arr1
     * 然后先按照 
     *  次数 bucket[arr2[i]], 值arr2[i], 逐一为arr1[j]赋值
     *  复制完后桶中将为0, 意味着数字为索引号的数出现了0次
     * 最后再从头遍历一遍bucket, 将不为-1的按次数置给arr1[j]
     * 
     * */
}