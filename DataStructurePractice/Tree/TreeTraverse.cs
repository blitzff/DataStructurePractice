namespace DataStructurePractice.Tree;

[TestClass]
public class TreeTraverse<T> : ITraverse<T>
{
    public IList<T> Preorder(TreeNode<T> root)
    {
        var list = new List<T>();

        if (root == null) return list;

        var stack = new Stack<TreeNode<T>>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            list.Add(node.Value);
            if (node.Right != null) { stack.Push(node.Right); }
            if (node.Left != null) { stack.Push(node.Left); }
        }

        return list;
    }

    public IList<T> Inorder(TreeNode<T> root)
    {
        var list = new List<T>();

        if (root == null) return list;

        var stack = new Stack<TreeNode<T>>();
        
        while (stack.Count > 0 || root != null) 
        {
            if (root != null)
            {
                stack.Push(root);
                root = root.Left;
            }
            else
            {
                root = stack.Pop();
                list.Add(root.Value);
                root = root.Right;
            }
        }

        return list;
    }

    public IList<T> Postorder(TreeNode<T> root)
    {
        var list = new List<T>();

        if (root == null) return list;

        var stack1 = new Stack<TreeNode<T>>();
        var stack2 = new Stack<TreeNode<T>>();

        stack1.Push(root);
        while (stack1.Count > 0)
        {
            var node = stack1.Pop();
            stack2.Push(node);
            if (node.Left != null) { stack1.Push(node.Left); }
            if (node.Right != null) { stack1.Push(node.Right); }
        }

        while (stack2.Count > 0)
        {
            list.Add(stack2.Pop().Value);
        }

        return list;
    }

    public IList<T> LevelOrder(TreeNode<T> root)
    {
        var list = new List<T>();
        if (root == null) return list;

        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            list.Add(node.Value);
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
        }

        return list;
    }
}