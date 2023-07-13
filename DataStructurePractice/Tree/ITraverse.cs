namespace DataStructurePractice.Tree;

public interface ITraverse<T>
{
    IList<T> Preorder(TreeNode<T> root);
    IList<T> Inorder(TreeNode<T> root);
    IList<T> Postorder(TreeNode<T> root);
}