namespace DataBaseTask2
{
    class Good : IEntity
    {
        public long Id { get; }
        public string Name { get; }
        public long ShopId { get; }
        public string Description { get; }
        public string Category { get; }

        public Good(long id, string name, long shopId, string description, string category)
        {
            Id = id;
            Name = name;
            ShopId = shopId;
            Description = description;
            Category = category;
        }
    }
}
