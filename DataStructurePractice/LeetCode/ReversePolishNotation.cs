namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/8Zf90G/
/// </summary>
public class ReversePolishNotation
{
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        foreach (var token in tokens)
        {
            var op = 0;
            var isNum = int.TryParse(token.ToString(), out op);
            if (isNum)
            {
                stack.Push(op);
            }
            else
            {
                var op2 = stack.Pop();
                var op1 = stack.Pop();
                switch (token)
                {
                    case "+": op = op1 + op2; break;
                    case "-": op = op1 - op2; break;
                    case "*": op = op1 * op2; break;
                    case "/": op = op1 / op2; break;
                }
                stack.Push(op);
            }
        }
        return stack.Pop();
    }

    /**
     * tokens[i] 要么是一个算符（"+"、"-"、"*" 或 "/"），要么是一个在范围 [-200, 200] 内的整数
     * 整数除法只保留整数部分。
     * 给定逆波兰表达式总是有效的。换句话说，表达式总会得出有效数值且不存在除数为 0 的情况。
     * 
     * 遍历字符串
     * 操作数入栈, 遇到操作符, 出栈两个操作数, 后 [操作符] 前 = 结果, 结果入栈
     * */
}