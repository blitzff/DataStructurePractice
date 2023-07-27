namespace DataStructurePractice.LeetCode;

/// <summary>
/// https://leetcode.cn/problems/XagZNi/
/// </summary>
[TestClass]
public class AsteroidCollisionSolution
{
    public int[] AsteroidCollision(int[] arr)
    {
        // arr.Length >= 2
        var stack = new Stack<int>();
        stack.Push(arr[0]);

        var i = 1;
        while (i < arr.Length)
        {
            if (stack.Count == 0)
            {
                stack.Push(arr[i]);
                i++;
                continue;
            }

            var a = stack.Peek();
            var b = arr[i];
            if (a > 0 && b < 0)
            {
                var aAbs = Math.Abs(a);
                var bAbs = Math.Abs(b);
                if (aAbs > bAbs)
                {
                    i++;
                }
                else if (aAbs == bAbs)
                {
                    stack.Pop();
                    i++;
                }
                else
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Push(b);
                i++;
            }
        }

        return stack.Reverse().ToArray();
    }

    /**
     * ջ����Ԫ��
     *  ��ջ��peekһ��a, ����������һ��Ԫ��b�Ƚ�:
     *      ջ��Ԫ��a����:
     *       b��: ��ջ, ������һ��Ԫ��
     *       b��: ��ջ, ������һ��Ԫ��
     *      
     *      ջ��Ԫ��a����:
     *       b��: 
     *           |a| > |b|, ������һ������Ԫ��
     *           |a|== |b|, pop, ������һ������Ԫ��
     *           |a| < |b|, pop, ����a����ջ��, b����, ������һ��ѭ��
     *       b��: ��ջ, ������һ��Ԫ��
     * ջ����Ԫ��:
     *   ��ջ
     *  
     *  �Ա����� stack, stack.Peek(), arr[i] Ҫ������Щ�ı߽�
     *  
     *  ע��:
     *   1. ջ�ڿ����������ʱ��, stack.Count�ǻ����Pop������С, ֱ����ϵͳAPI ToArray����
     *   2. �㷨����˼·��ȷ, ����ջ���ڹ����б�Ϊ��, Ҫ����һ��
     * */

    [TestMethod]
    public void test()
    {
        new AsteroidCollisionSolution().AsteroidCollision(
            new int[]
            {
                5,10,-5
            });
    }
}