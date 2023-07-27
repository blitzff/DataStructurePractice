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
     * 栈中有元素
     *  从栈顶peek一个a, 和数组中下一个元素b比较:
     *      栈顶元素a向左:
     *       b左: 入栈, 遍历下一个元素
     *       b右: 入栈, 遍历下一个元素
     *      
     *      栈顶元素a向右:
     *       b左: 
     *           |a| > |b|, 遍历下一个数组元素
     *           |a|== |b|, pop, 遍历下一个数组元素
     *           |a| < |b|, pop, 更新a到新栈顶, b不动, 进入下一次循环
     *       b右: 入栈, 遍历下一个元素
     * 栈中无元素:
     *   入栈
     *  
     *  自变量有 stack, stack.Peek(), arr[i] 要处理这些的边界
     *  
     *  注意:
     *   1. 栈在拷贝到数组的时候, stack.Count是会跟随Pop操作变小, 直接用系统API ToArray更好
     *   2. 算法主体思路正确, 但是栈会在过程中变为空, 要处理一下
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