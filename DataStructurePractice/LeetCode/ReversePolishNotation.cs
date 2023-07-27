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
     * tokens[i] Ҫô��һ�������"+"��"-"��"*" �� "/"����Ҫô��һ���ڷ�Χ [-200, 200] �ڵ�����
     * ��������ֻ�����������֡�
     * �����沨�����ʽ������Ч�ġ����仰˵�����ʽ�ܻ�ó���Ч��ֵ�Ҳ����ڳ���Ϊ 0 �������
     * 
     * �����ַ���
     * ��������ջ, ����������, ��ջ����������, �� [������] ǰ = ���, �����ջ
     * */
}