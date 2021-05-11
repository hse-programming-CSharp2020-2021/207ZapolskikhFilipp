namespace DataBaseTask2
{
	class Sale : IEntity
	{
		public long Id { get; }
		public Buyer Buyer { get; }
		public Shop Shop { get; }
		public Good Good { get; }
		public int GoodCount { get; }
		public decimal GoodPrice { get; }

		public Sale(long id, Buyer buyer, Shop shop, Good good, int goodCount, decimal goodPrice)
		{
			Id = id;
			Buyer = buyer;
			Shop = shop;
			Good = good;
			GoodCount = goodCount;
			GoodPrice = goodPrice;
		}
	}
}
