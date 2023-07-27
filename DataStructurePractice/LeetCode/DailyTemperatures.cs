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
     * 结果数组和输入数组一样长
     * 栈中保存的是下标
     * 
     * 如果栈为空或当前元素<=栈顶, 入栈当前元素的索引
     * 如果当前元素>栈顶, 
     *  while 栈不为空 且 当前元素>栈顶:
     *      栈顶元素索引出栈, 
     *      var topIndex = stack.Pop();
     *      更新days[topIndex]为 i-topIndex
     *  入栈当前元素
     *  然后进行下一轮迭代
     * */
}