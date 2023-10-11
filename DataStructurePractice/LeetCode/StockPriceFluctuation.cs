class StockPrice
{
	int maxTimestamp;
	Dictionary<int, int> timePriceMap;
	PriorityQueue<int[], int> priceMaxHeap;
	PriorityQueue<int[], int> priceMinHeap;

	public StockPrice()
	{
		maxTimestamp = 0;
		timePriceMap = new Dictionary<int, int>();
		priceMaxHeap = new PriorityQueue<int[], int>(Comparer <int>.Create((a, b) => b - a));
		priceMinHeap = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => a - b));
	}

	public void Update(int timestamp, int price)
	{
		maxTimestamp = Math.Max(maxTimestamp, timestamp);
		timePriceMap[timestamp] =  price;
		
		priceMaxHeap.Enqueue(new int[] { price, timestamp }, price);
		priceMinHeap.Enqueue(new int[] { price, timestamp }, price);
	}

	public int Current()
	{
		return timePriceMap[maxTimestamp];
	}

	public int Maximum()
	{
		while (true)
		{
			int[] priceTime = priceMaxHeap.Peek();
			int price = priceTime[0], timestamp = priceTime[1];
			if (timePriceMap[timestamp] == price)
			{
				return price;
			}
			// 将过期的(值!=timePriceMap中的值)删掉
			// 能这样做是由于在Update的时候不管啥情况, 尽管入
			priceMaxHeap.Dequeue();
		}
	}

	/// <summary>
	/// 对于返回股票最低价格操作，每次从最低价格队列的队首元素中得到价格和时间戳，
	/// 并从哈希表中得到该时间戳对应的实际价格，如果队首元素中的价格和实际价格不一致，
	/// 则队首元素为过期价格，将队首元素删除，重复该操作直到队首元素不为过期价格，此时返回队首元素中的价格。
	/// </summary>
	/// <returns></returns>
	public int Minimum()
	{
		while (true)
		{
			int[] priceTime = priceMinHeap.Peek();
			int price = priceTime[0], timestamp = priceTime[1];
			if (timePriceMap[timestamp] == price)
			{
				return price;
			}
			priceMinHeap.Dequeue();
		}
	}
}
