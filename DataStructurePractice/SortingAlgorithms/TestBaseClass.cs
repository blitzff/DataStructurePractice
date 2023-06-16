namespace DataStructurePractice.SortingAlgorithms;

public abstract class TestBaseClass
{
    public abstract void Sort(int[] arr);

    [TestMethod]
    public virtual void test()
    {
        SortingHelper.TestSort(Sort);
    }
}