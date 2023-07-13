namespace DataStructurePractice.Tree;

public static class TreeHelper
{
    private static Random random = new Random();

    public static TreeNode<int> CreateTree()
    {
        var nodeNum = random.Next(7, 20);
        var count = 1;

        var root = new TreeNode<int>(0);
        var queue = new Queue<TreeNode<int>>();
        queue.Enqueue(root);
        while (!queue.IsEmpty() && count <= nodeNum)
        {
            var node = queue.Dequeue();
            var leftNode = RandomTrue() ? new TreeNode<int>(count++) : null;
            var rightNode = RandomTrue() ? new TreeNode<int>(count++) : null;
            if (leftNode != null)
            {
                node.Left = leftNode;
                queue.Enqueue(leftNode);
            }
            if (rightNode != null)
            {
                node.Right = rightNode;
                queue.Enqueue(rightNode);
            }
        }
        return root;
    }

    private static bool IsEmpty(this Queue<TreeNode<int>> queue)
    {
        return queue.Count == 0;
    }

    private static bool RandomTrue()
    {
        return random.Next(0, 10) >= 3;
    }

    public static void Print<T>(IList<T> list)
    {
        foreach (var val in list)
        {
            Console.Write($"{val}\t");
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}