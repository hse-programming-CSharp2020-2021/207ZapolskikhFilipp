namespace DataBaseTask2
{
	class Sale : IEntity
	{
		public long Id { get; }
		public long BuyerId { get; }
		public long ShopId { get; }
		public long GoodId { get; }
		public int GoodCount { get; }
		public decimal GoodCost { get; }

		public Sale(long id, long buyerId, long shopId, long goodId, int goodCount, decimal goodCost)
		{
			Id = id;
			BuyerId = buyerId;
			ShopId = shopId;
			GoodId = goodId;
			GoodCount = goodCount;
			GoodCost = goodCost;
		}
	}
}
