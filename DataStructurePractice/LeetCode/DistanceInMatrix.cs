namespace DataStructurePractice.LeetCode;

public class DistanceInMatrix
{
    /// <summary>
    /// 这里的广度优先遍历是一个元素的上下左右位置
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public int[][] UpdateMatrix(int[][] mat)
    {
        var rows = mat.Length;
        var cols = mat[0].Length;
        var distances = new int[rows][];
        var queue = new Queue<int[]>();
        for (int i = 0; i < rows; i++)
        {
            distances[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                var val = mat[i][j];
                if (val == 0) // 本身是0, 距离设为0
                {
                    // 从挨着0的开始广度优先遍历
                    queue.Enqueue(new int[] { i, j });
                    distances[i][j] = 0;
                }
                else // 本身不是0, 距离设为max
                {
                    distances[i][j] = int.MaxValue;
                }
            }
        }

        List<int[]> directions = new List<int[]>
        {
            new int[] { -1, 0 }, 
            new int[] { 1, 0 },
            new int[] { 0, 1 }, 
            new int[] { 0, -1 }
        };
        while (queue.Count > 0)
        {
            var position = queue.Dequeue();
            var curDistance = distances[position[0]][position[1]];
            foreach (var direction in directions)
            {
                var childRow = position[0] + direction[0];
                var childCol = position[1] + direction[1];
                if (childRow >= 0 && childRow < rows
                    && childCol >= 0 && childCol < cols)
                {
                    if (curDistance + 1 < distances[childRow][childCol])
                    {
                        distances[childRow][childCol] = curDistance + 1;
                        // 由max变成了常数, 将其加入队列, 使挨着它的能够被遍历到
                        queue.Enqueue(new int[] { childRow, childCol });
                    }
                }
            }
        }
        return distances;
    }
}