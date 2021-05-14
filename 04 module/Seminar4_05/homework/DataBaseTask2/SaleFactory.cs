namespace DataBaseTask2
{
	class SaleFactory : IEntityFactory<Sale>
	{
		long id;
		long buyerId;
		long shopId;
		long goodId;
		int goodCount;
		decimal goodCost;

		public SaleFactory(long id, long buyerId, long shopId, long goodId, int goodCount, decimal goodCost)
		{
			this.id = id;
			this.buyerId = buyerId;
			this.shopId = shopId;
			this.goodId = goodId;
			this.goodCount = goodCount;
			this.goodCost = goodCost;
		}

		public Sale Instance => new Sale(id, buyerId, shopId, goodId, goodCount, goodCost);
	}
}
