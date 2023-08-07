namespace DataStructurePractice.LeetCode;

public class SubSetsSolution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var res = new List<IList<int>>();
        dfs(0, nums, new List<int>(), res);
        return res;
    }

    private void dfs(int i, int[] nums, List<int> path, List<IList<int>> res)
    {
        if (i > nums.Length) return;

        // ������Ԫ�ص���һ��λ��, Ҳ����nums.Lengthʱ
        // �������ӵ�res, Ȼ�󷵻ص��ϲ����4��
        // ��4����Ҫȥ����ǰ���Ԫ��, Ȼ�������Ϸ���
        if (i == nums.Length)
        {
            res.Add(path.ToList());
            return;
        }

        // ����ӵ�ǰԪ��, ������һ��
        dfs(i + 1, nums, path, res);

        // ��ӵ�ǰԪ��, ������һ��
        path.Add(nums[i]);
        dfs(i+1, nums, path, res);

        // 4 �����ϲ�ǰȥ����ǰ���Ԫ��
        if (path.Count > 0)
        {
            path.RemoveAt(path.Count - 1);
        }
    }

    /**
     * �Ӽ�(���)��˳���޹�
     * 
     * ÿһ��λ�ÿ���ѡ�������߲�����,
     * ����Ҷ�ӽڵ㼴Ϊ����
     * */
}