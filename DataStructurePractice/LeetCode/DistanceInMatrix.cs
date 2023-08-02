namespace DataStructurePractice.LeetCode;

public class DistanceInMatrix
{
    /// <summary>
    /// ����Ĺ�����ȱ�����һ��Ԫ�ص���������λ��
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
                if (val == 0) // ������0, ������Ϊ0
                {
                    // �Ӱ���0�Ŀ�ʼ������ȱ���
                    queue.Enqueue(new int[] { i, j });
                    distances[i][j] = 0;
                }
                else // ������0, ������Ϊmax
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
                        // ��max����˳���, ����������, ʹ���������ܹ���������
                        queue.Enqueue(new int[] { childRow, childCol });
                    }
                }
            }
        }
        return distances;
    }
}