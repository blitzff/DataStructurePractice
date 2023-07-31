namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/6eUYwP/
/// �������Ľڵ�����ķ�Χ�� [0,1000]
/// -109 <= Node.val <= 109 
/// -1000 <= targetSum <= 1000 
/// </summary>
public class PathSumIII
{
    public int PathSum(TreeNode root, int targetSum)
    {
        var map = new Dictionary<int, int>() { { 0, 1 } };

        return FindRes(root, targetSum, map, 0);
    }

    /// <summary>
    /// ����������ͳ��ǰn���, ����pathSum-targetSum���ֵĴ���
    /// </summary>
    /// <param name="root"></param>
    /// <param name="targetSum"></param>
    /// <param name="map"></param>
    /// <param name="pathSum"></param>
    /// <returns></returns>
    private int FindRes(TreeNode root, int targetSum, Dictionary<int, int> map, int pathSum)
    {
        if (root == null) return 0;

        pathSum += root.val;
        // �Ӹ��ڵ㿪ʼ���Ķ��ĺ���pathSum-targetSum, Ҳ���Ǵ��Ķ�����ǰ�ڵ�ĺ���targetSum
        // �����������
        var count = map.GetValueOrDefault(pathSum - targetSum, 0);
        // �������������ʱ��, ��ǰ�ڵ�����ǰn��͵�һ����.
        map[pathSum] = map.GetValueOrDefault(pathSum, 0) + 1;

        count += FindRes(root.left, targetSum, map, pathSum);
        count += FindRes(root.right, targetSum, map, pathSum);

        // �뿪���������ʱ��, ��ǰ�ڵ㲻����ǰn�����.
        map[pathSum] -= 1;

        return count;
    }
}