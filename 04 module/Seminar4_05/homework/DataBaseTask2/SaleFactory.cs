namespace DataBaseTask2
{
	class SaleFactory : IEntityFactory<Sale>
	{
		long id;
		Buyer buyer;
		Shop shop;
		Good good;
		int goodCount;
		decimal goodPrice;

		public SaleFactory(long id, Buyer buyer, Shop shop, Good good, int goodCount, decimal goodPrice)
		{
			this.id = id;
			this.buyer = buyer;
			this.shop = shop;
			this.good = good;
			this.goodCount = goodCount;
			this.goodPrice = goodPrice;
		}

		public Sale Instance => new Sale(id, buyer, shop, good, goodCount, goodPrice);
	}
}
