namespace DataStructurePractice.CrackingTheCodingInterview;

/// <summary>
/// https://leetcode.cn/problems/cong-wei-dao-tou-da-yin-lian-biao-lcof/?envType=study-plan-v2&envId=coding-interviews
/// </summary>
[TestClass]
public class Solution06_ReversePrint
{
    public static int[] ReversePrint(LinkedListNode<int> node)
    {
        if (node == null) return new int[0];

        var stack = new Stack<int>();
        while (node.Next != null)
        {
            stack.Push(node.Value);
            node = node.Next;
        }
        return stack.ToArray();
    }
}