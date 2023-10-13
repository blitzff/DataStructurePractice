namespace DataStructurePractice.LeetCode;

public class RewardTopk
{
	class Student
	{
		public int id;
		public string report;
		private readonly HashSet<string> positiveSet;
		private readonly HashSet<string> negativeSet;
		public int point;

        public Student(
			int id,
			string report,
			HashSet<string> positiveSet,
			HashSet<string> negativeSet)
		{
			this.id = id;
			this.report = report;
			this.positiveSet = positiveSet;
			this.negativeSet = negativeSet;
			this.point = CalcPoint();
        }

        private int CalcPoint()
		{
			var point = 0;
			string[] words = report.Split(' ');
			foreach (string word in words)
			{
				if (positiveSet.Contains(word))
				{
					point += 3;
				}
				else if (negativeSet.Contains(word))
				{
					point -= 1;
				}
			}
			return point;
		}
	}

	private HashSet<string> positiveSet;
	private HashSet<string> negativeSet;

	public IList<int> TopStudents(
		string[] positive_feedback,
		string[] negative_feedback,
		string[] report,
		int[] student_id,
		int k)
	{
		positiveSet = new HashSet<string>(positive_feedback);
		negativeSet = new HashSet<string>(negative_feedback);

		var maxHeap = new PriorityQueue<Student, Student>(Comparer<Student>.Create((s1, s2) => 
		{
			if (s2.point != s1.point)
			{
				return s2.point - s1.point;
			}
			else
			{
				return s1.id - s2.id;
			}
		}));
		for (var i = 0; i < report.Length; i++)
		{
			var stu = new Student(student_id[i], report[i], positiveSet, negativeSet);
			maxHeap.Enqueue(stu, stu);
		}

		var res = new List<int>();
		// k <= n
		for (var i = 0; i < k; i++)
		{
			var stu = maxHeap.Dequeue();
			res.Add(stu.id);
		}
		return res;
	}

	/**
	 * topk 堆 按照每名学生的得分
	 * set
	 * */
}
