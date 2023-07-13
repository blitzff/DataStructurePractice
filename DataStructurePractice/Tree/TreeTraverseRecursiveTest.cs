namespace DataStructurePractice.Tree;

[TestClass]
public class TreeTraverseRecursiveTest
{
    [TestMethod]
    public void test_nontraverse()
    {
        var root = TreeHelper.CreateTree();
        var pres = new TreeTraverseRecursive<int>().Preorder(root);
        var ins = new TreeTraverseRecursive<int>().Inorder(root);
        var posts = new TreeTraverseRecursive<int>().Postorder(root);

        Console.WriteLine("pres:");
        TreeHelper.Print(pres);

        Console.WriteLine("ins:");
        TreeHelper.Print(ins);

        Console.WriteLine("posts:");
        TreeHelper.Print(posts);
    }


    [TestMethod]
    public void test1000times_all()
    {
        for (int i = 0; i < 1000; i++)
        {
            test_pre();
            test_pre_null();
            test_post();
            test_post_null();
            test_in();
            test_in_null();
        }
    }

    [TestMethod]
    public void test_pre()
    {
        var root = TreeHelper.CreateTree();
        var rec = new TreeTraverseRecursive<int>().Preorder(root);
        var nonrec = new TreeTraverse<int>().Preorder(root);

        Assert.AreEqual(rec.Count, nonrec.Count);
        for (int i = 0; i < rec.Count; i++)
        {
            Assert.AreEqual(rec[i], nonrec[i]);
        }
    }

    [TestMethod]
    public void test_pre_null()
    {
        TreeNode<int> root = null;
        var rec = new TreeTraverseRecursive<int>().Preorder(root);
        var nonrec = new TreeTraverse<int>().Preorder(root);

        Assert.AreEqual(rec.Count, nonrec.Count);
        for (int i = 0; i < rec.Count; i++)
        {
            Assert.AreEqual(rec[i], nonrec[i]);
        }
    }

    [TestMethod]
    public void test_post()
    {
        var root = TreeHelper.CreateTree();
        var rec = new TreeTraverseRecursive<int>().Postorder(root);
        var nonrec = new TreeTraverse<int>().Postorder(root);

        Assert.AreEqual(rec.Count, nonrec.Count);
        for (int i = 0; i < rec.Count; i++)
        {
            Assert.AreEqual(rec[i], nonrec[i]);
        }
    }

    [TestMethod]
    public void test_post_null()
    {
        TreeNode<int> root = null;
        var rec = new TreeTraverseRecursive<int>().Postorder(root);
        var nonrec = new TreeTraverse<int>().Postorder(root);

        Assert.AreEqual(rec.Count, nonrec.Count);
        for (int i = 0; i < rec.Count; i++)
        {
            Assert.AreEqual(rec[i], nonrec[i]);
        }
    }

    [TestMethod]
    public void test_in()
    {
        var root = TreeHelper.CreateTree();
        var rec = new TreeTraverseRecursive<int>().Inorder(root);
        var nonrec = new TreeTraverse<int>().Inorder(root);

        Assert.AreEqual(rec.Count, nonrec.Count);
        for (int i = 0; i < rec.Count; i++)
        {
            Assert.AreEqual(rec[i], nonrec[i]);
        }
    }

    [TestMethod]
    public void test_in_null()
    {
        TreeNode<int> root = null;
        var rec = new TreeTraverseRecursive<int>().Inorder(root);
        var nonrec = new TreeTraverse<int>().Inorder(root);

        Assert.AreEqual(rec.Count, nonrec.Count);
        for (int i = 0; i < rec.Count; i++)
        {
            Assert.AreEqual(rec[i], nonrec[i]);
        }
    }

    [TestMethod]
    public void test_level()
    {
        var root = TreeHelper.CreateTree();
        var list = new TreeTraverse<int>().LevelOrder(root);
        for (int i = 0; i < list.Count; i++)
        {
            Assert.AreEqual(i, list[i]);
        }
    }
}