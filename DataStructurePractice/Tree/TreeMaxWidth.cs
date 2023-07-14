namespace DataStructurePractice.Tree;

[TestClass]
public class TreeMaxWidth
{
    [TestMethod]
    public void test()
    {
        var root = TreeHelper.CreateTree();
        var pres = new TreeTraverseRecursive<int>().Preorder(root);
        var ins = new TreeTraverseRecursive<int>().Inorder(root);

        TreeHelper.Print(pres);
        TreeHelper.Print(ins);

        var width = new TreeMaxWidth().Solution(root);
        Console.WriteLine(width);
    }

    public int Solution<T>(TreeNode<T> root)
    {
        if (root == null) return 0;

        var maxLevelNodes = 1;
        var curLevelNodes = 0;
        var curEnd = root;
        TreeNode<T> nextEnd = null; // root.Right might be null, so value it at traverse process

        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var curNode = queue.Dequeue();
            
            if (curNode.Left != null)
            {
                var left = curNode.Left;
                queue.Enqueue(left);
                nextEnd = left;
            }
            if (curNode.Right != null)
            {
                var right = curNode.Right;
                queue.Enqueue(right);
                nextEnd = right;
            }
            
            curLevelNodes++;

            if (curNode == curEnd)
            {
                maxLevelNodes = Math.Max(maxLevelNodes, curLevelNodes);
                curLevelNodes = 0;
                curEnd = nextEnd;
            }
        }
        return maxLevelNodes;
    }
}