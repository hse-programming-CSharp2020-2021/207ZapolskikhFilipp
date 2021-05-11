namespace DataBaseTask2
{
    class Shop : IEntity
    {
        public long Id { get; }
        public string Name { get; }
        public string City { get; }
        public string District { get; }
        public string Country { get; }
        public string Phone { get; }

        public Shop(long id, string name, string city, string district, string country, string phone)
        {
            Id = id;
            Name = name;
            City = city;
            District = district;
            Country = country;
            Phone = phone;
        }
    }
}
