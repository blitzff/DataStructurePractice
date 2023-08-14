namespace DataStructurePractice.LeetCode;

public class HanotaSolution
{
    public void Hanota(IList<int> from, IList<int> other, IList<int> to)
    {
        move(from, to, other, from.Count);
    }

    //第一个参数是初始，第二个参数是目标，第三个参数是缓存。
    public void move(IList<int> from, IList<int> to, IList<int> other, int n)
    {
        if (n == 1)
        {
            to.Add(from[from.Count - 1]);
            from.RemoveAt(from.Count - 1);
            return;
        }
        move(from, other, to, n - 1);             //上面n-1个，从from移动到other
        to.Add(from[from.Count - 1]);             //最底下的一个，从from移动到to
        from.RemoveAt(from.Count - 1);
        move(other, to, from, n - 1);             //上面n-1个，从other移动到to
    }

    /**
     * 怎么确定递归中的那 递推的1步 呢?
     * 不要细想具体过程? 从宏观上拆分, 然后考虑每一步.
     * */
}
