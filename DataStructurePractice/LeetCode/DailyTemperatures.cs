namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/iIQa4I/
/// </summary>
public class DailyTemperaturesSolution
{
    public int[] DailyTemperatures(int[] temps)
    {
        var days = new int[temps.Length];

        var stack = new Stack<int>();

        for (int i = 0; i < temps.Length; i++)
        {
            while (stack.Count != 0 && temps[i] > temps[stack.Peek()])
            {
                var topIndex = stack.Pop();
                days[topIndex] = i - topIndex;
            }
            stack.Push(i);
        }

        return days;
    }

    /**
     * ����������������һ����
     * ջ�б�������±�
     * 
     * ���ջΪ�ջ�ǰԪ��<=ջ��, ��ջ��ǰԪ�ص�����
     * �����ǰԪ��>ջ��, 
     *  while ջ��Ϊ�� �� ��ǰԪ��>ջ��:
     *      ջ��Ԫ��������ջ, 
     *      var topIndex = stack.Pop();
     *      ����days[topIndex]Ϊ i-topIndex
     *  ��ջ��ǰԪ��
     *  Ȼ�������һ�ֵ���
     * */
}