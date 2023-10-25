using DataStructurePractice.LeetCode;

namespace DataStructurePractice.Tree;

[TestClass]
public class BinarySearchTree
{
    private TreeNode root = null;

    #region Insert
    public void Insert(int key)
    {
        root = InsertInner(root, key);
    }

    private TreeNode InsertInner(TreeNode node, int key)
    {
        // 1. 最后的位置返回一个新创建的节点
        if (node == null)   return new TreeNode(key);

        // 2. 新创建的节点被赋值给它的父层节点左右孩子
        if (key < node.val) node.left = InsertInner(node.left, key);
        else if (key > node.val) node.right = InsertInner(node.right, key);

        // 3. 对于其余的节点, 只是又赋值了一次
        return node;
    }
    #endregion

    #region Delete
    public void Delete(int key)
    {
        root = DeleteInner(root, key);
    }

    /// <summary>
    /// 三种情况:
    /// 1. 叶子节点, 直接删除
    /// 2. 有一个子节点
    ///     a. 将当前node替换成这个子节点
    ///     b. 将子节点从原来的位置删除
    /// 3. 被删除的节点有两个孩子
    ///     a. 得到中序遍历的后继节点
    ///     b. 替换当前节点为后继节点
    ///     c. 移除后继节点
    /// </summary>
    private TreeNode DeleteInner(TreeNode root, int key)
    {
        if (root == null) throw new ArgumentNullException("Key is not existed.");

        // 3. 对于非key的节点来说, 直接从2返回自己, 也就是仅仅赋值了一下
        if (key < root.val) 
            root.left = DeleteInner(root.left, key);
        else if (key > root.val) 
            root.right = DeleteInner(root.right, key);
        else // 1. 找到要删除的节点
        {
            // 1.1 叶子节点直接删除, 就是返回null给它的父节点
            // 1.2 有一个节点时, 返回当前节点(root)的子节点(root.left/root.right)给它的父节点
            if (root.left == null) return root.right;
            if (root.right == null) return root.left;

            // 1.3 找到后继节点, 也就是右子树上最左节点
            // 将它的值赋给当前节点
            // 移除后继节点
            // => 2 返回当前节点给自己的父节点
            root.val = InorderSuccessor(root.right);
            root.right = DeleteInner(root.right, root.val);
        }

        // 2
        return root;
    }
    
    private int InorderSuccessor(TreeNode node)
    {
        var min = node.val;
        while (node.left != null)
        {
            min = node.left.val;
            node = node.left;
        }
        return min;
    }
    #endregion

    #region Inorder
    public void Inorder()
    {
        InorderInner(root);
        Console.WriteLine();
    }

    private void InorderInner(TreeNode node)
    {
        if (node == null) return;

        InorderInner(node.left);
        Console.Write(node.val + "\t");
        InorderInner(node.right);
    }
    #endregion

    [TestMethod]
    public void test()
    {
        var tree = new BinarySearchTree();

        tree.Insert(8);
        tree.Insert(3);
        tree.Insert(1);
        tree.Insert(6);
        tree.Insert(7);
        tree.Insert(10);
        tree.Insert(14);
        tree.Insert(4);

        tree.Inorder();

        tree.Delete(6);
        tree.Insert(12);
        tree.Delete(4);

        tree.Inorder();
    }
}
