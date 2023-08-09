using System.Text;

namespace DataStructurePractice.LeetCode;

public class GenerateParentheses
{
    private int N;
    private List<string> res = new List<string>();
    public IList<string> GenerateParenthesis(int n)
    {
        this.N = n;
        dfs(0, 0, new StringBuilder());
        return res;
    }

    private void dfs(int lefti, int righti, StringBuilder path)
    {
        if (lefti < righti) return;

        if (lefti == N && righti == N)
        {
            res.Add(path.ToString());
        }
        else if (lefti < N && righti < N)
        {
            path.Append('(');
            dfs(lefti+1, righti, path);
            path.Remove(path.Length - 1, 1);

            path.Append(')');
            dfs(lefti, righti+1, path);
            path.Remove(path.Length - 1, 1);
        }
        else if (lefti < N)
        {
            path.Append('(');
            dfs(lefti + 1, righti, path);
            path.Remove(path.Length - 1, 1);
        }
        else if (righti < N)
        {
            path.Append(')');
            dfs(lefti, righti + 1, path);
            path.Remove(path.Length - 1, 1);
        }
    }

    /**
     * ÿһ������ѡ�������Ż���������
     * ����������ln, rn
     * 
     * ˼·û����
     * 
     * ��ô��֤��Ч��
     * ))()(( ���ֲ�������Ч
     * lefti >= righti ?
     * ���ˣ�������������
     * */
}