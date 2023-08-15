using System.Text;

namespace DataStructurePractice.LeetCode;

public class FindReplaceKs
{
    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
    {

        var chs = s.ToCharArray();
        var stack = new Stack<char>();
        for (int i = chs.Length-1; i >= 0; i--)
        {
            stack.Push(chs[i]);
        }

        var ops = new int[indices.Length];
        for (int i = 0; i < ops.Length; i++)
        {
            ops[i] = i;
        }
        // 按照indicies的值排序的索引
        Array.Sort(ops, Comparer<int>.Create((a, b) => indices[a] - indices[b]));

        var sb = new StringBuilder();
        var current = 0;
        for (int i = 0; i < indices.Length; i++)
        {
            var index = ops[i];
            // 掠过中间的不用匹配的字符，加入结果字符串
            while (current < indices[index])
            {
                current++;
                sb.Append(stack.Pop());
            }
            // 开始匹配
            var sbt = new StringBuilder();
            var c = 0;
            for (; c < sources[index].Length; c++)
            {
                // 最后一个匹配的时候前面都符合但是字符串没元素了
                // 或者不符合条件
                if (stack.Count == 0 
                    || sources[index][c] != stack.Peek()) break;

                sbt.Append(stack.Pop());
                current++;
            }
            // 不符合条件恢复
            if (c != sources[index].Length)
            {
                for (int t = sbt.Length-1; t >= 0; t--)
                {
                    stack.Push(sbt[t]);
                    current--;
                }
            }
            // 符合条件，加入结果字符串
            else
            {
                sb.Append(targets[index]);
            }
        }

        while (stack.Count > 0)
        {
            sb.Append(stack.Pop());
        }

        return sb.ToString();
    }

    /**
     * 替换后的不影响原字符串
     * - 索引
     * - 不会导致满足新的条件了
     * 
     * 用一个栈
     * 一个StringBuilder
     * 如果符合条件，出栈原字符，如果不符合，再入栈回去， 一个变量记录当前索引
     * 
     * 最后如果栈不为空，将栈倒出来拼到stringbuilder上
     * */
}
