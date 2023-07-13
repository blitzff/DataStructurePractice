namespace DataStructurePractice.Tree;

public class TreeTraverseRecursive<T> : ITraverse<T>
{

    public IList<T> Preorder(TreeNode<T> root)
    {
        var nodes = new List<T>();
        Preorder(root, nodes);
        return nodes;
    }

    private void Preorder(TreeNode<T> root, IList<T> nodes)
    {
        if (root == null) return;

        nodes.Add(root.Value);
        Preorder(root.Left, nodes);
        Preorder(root.Right, nodes);
    }

    public IList<T> Inorder(TreeNode<T> root)
    {
        var nodes = new List<T>();
        Inorder(root, nodes);
        return nodes;
    }

    private void Inorder(TreeNode<T> root, IList<T> nodes)
    {
        if (root == null) return;

        Inorder(root.Left, nodes);
        nodes.Add(root.Value);
        Inorder(root.Right, nodes);
    }

    public IList<T> Postorder(TreeNode<T> root)
    {
        var nodes = new List<T>();
        Postorder(root, nodes);
        return nodes;
    }

    private void Postorder(TreeNode<T> root, IList<T> nodes)
    {
        if (root == null) return;

        Postorder(root.Left, nodes);
        Postorder(root.Right, nodes);
        nodes.Add(root.Value);
    }
}