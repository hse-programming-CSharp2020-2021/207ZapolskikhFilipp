namespace DataBaseTask2
{
    class GoodFactory : IEntityFactory<Good>
    {
        static long _id = 1;
        string name;
        long shopId;
        string description;
        string category;

        public GoodFactory(string name, long shopId, string description, string category)
        {
            this.name = name;
            this.shopId = shopId;
            this.description = description;
            this.category = category;
        }

        public Good Instance => new Good(_id++, name, shopId, description, category);
    }
}
