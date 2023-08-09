namespace DataStructurePractice.LeetCode;

public class Permutations
{
    private List<IList<int>> res = new List<IList<int>>();
    private int[] arr;

    public IList<IList<int>> Permute(int[] arr)
    {
        this.arr = arr;
        helper(0);
        return res;
    }

    private void helper(int i)
    {
        if (i == arr.Length)
        {
            res.Add(arr.ToList());
        }
        else if (i < arr.Length)
        {
            for (int j = i; j < arr.Length; j++) // 1.
            {
                swap(i, j); // 2.
                helper(i + 1); // 3.
                swap(i, j);
            }
        }
    }

    private void swap(int i, int j)
    {
        if (i == j) return;

        var temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    /**
     * 1. ÿ�δ� [i, n-1] ѡһ������iλ�ý���
     * 2. iλ����ѡ����n-i����
     * 3. ÿ��ѡ����iλ�õ���֮��ͼ���ѡ��i+1λ�õ���
     * */
}