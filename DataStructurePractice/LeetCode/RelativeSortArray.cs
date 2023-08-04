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

        // ��arr2�����˳��arr1���
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

        // ��Ͱ��ʣ�����ְ�����ֵ��arr1
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
     * arr1�п��ܳ���arr2�в����ڵ�Ԫ��
     * 
     * 1 <= arr1.length, arr2.length <= 1000
     * 0 <= arr1[i], arr2[i] <= 1000
     * arr2 �е�Ԫ�� arr2[i] ������ͬ
     * arr2 �е�ÿ��Ԫ�� arr2[i] �������� arr1 ��
     * 
     * ����1000, Ԫ�ش�С1001
     * 
     * ׼��һ����СΪ1001������bucket
     * ��������ͳ��һ��arr1
     * Ȼ���Ȱ��� 
     *  ���� bucket[arr2[i]], ֵarr2[i], ��һΪarr1[j]��ֵ
     *  �������Ͱ�н�Ϊ0, ��ζ������Ϊ�����ŵ���������0��
     * ����ٴ�ͷ����һ��bucket, ����Ϊ-1�İ������ø�arr1[j]
     * 
     * */
}