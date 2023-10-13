namespace DataStructurePractice.LeetCode;

[TestClass]
public class MovementOfRobots
{
    class Node
    {
        public int location;
        public char direction;
        public Node(int location, char direction)
        {
            this.location = location;
            this.direction = direction;
        }
    }

    public int SumDistance(int[] nums, string s, int d)
    {
        var list = new List<Node>();
        for (var i = 0; i < nums.Length; i++)
        {
            list.Add(new Node(nums[i], s[i]));
        }

        list.Sort(Comparer<Node>.Create((a, b) => a.location - b.location));

        var indexMap = new Dictionary<int, List<Node>>();
        foreach (var node in list)
        {
            if (!indexMap.Keys.Contains(node.location))
            {
                indexMap[node.location] = new List<Node>();
            }
            indexMap[node.location].Add(node);
        }

        for (var i = 0; i < d; i++)
        {
            foreach (var node in list)
            {
                if (node.direction == 'R')
                {
                    indexMap[node.location].Remove(node);
                    if (indexMap[node.location].Count == 0)
                    {
                        indexMap.Remove(node.location);
                    }
                    node.location = (node.location + 1);
                    if (!indexMap.Keys.Contains(node.location))
                    {
                        indexMap[node.location] = new List<Node>();
                    }
                    indexMap[node.location].Add(node);
                }
                else
                {
                    indexMap[node.location].Remove(node);
                    if (indexMap[node.location].Count == 0)
                    {
                        indexMap.Remove(node.location);
                    }
                    node.location = (node.location - 1);
                    if (!indexMap.Keys.Contains(node.location))
                    {
                        indexMap[node.location] = new List<Node>();
                    }
                    indexMap[node.location].Add(node);
                }
            }

            foreach (var node in list)
            {
                if (indexMap[node.location].Count > 1)
                {
                    foreach (var n in indexMap[node.location])
                    {
                        n.direction = n.direction == 'R' ? 'L' : 'R';
                    }
                }
            }
        }
        return CalcDistance(list);
    }

    private int CalcDistance(List<Node> list)
    {
        var res = 0;
        var n = list.Count;
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                res = (res + Math.Abs(list[i].location - list[j].location)) % 1000000007;
            }
        }
        return res;
    }

    [TestMethod]
    public void test()
    {
        Console.WriteLine(-5 % 1000000007);
    }

    [TestMethod]
    public void test_calc_distance()
    {
        var list = new List<Node>()
        {
            new Node(-38, 'L'),
            new Node(-74, 'L'),
            new Node(-43, 'L'),
            new Node(71, 'L'),
            new Node(-12, 'L'),
            new Node(46, 'L'),
            new Node(56, 'L'),
            new Node(-45, 'L'),
            new Node(43, 'L'),
        };
        var o = new MovementOfRobots();
        var res = o.CalcDistance(list);
        Console.WriteLine(res);
    }

    [TestMethod]
    public void test_sum_distance()
    {
        var o = new MovementOfRobots();
        var res = o.SumDistance(new int[] { -36, -72, -41, 69, -14, 44, 58, -47, 45 }, "LLLRRRLRL", 2);
        Console.WriteLine(res);
    }
}
