namespace DataBaseTask2
{
    class ShopFactory : IEntityFactory<Shop>
    {
        static long _id = 1;
        string name;
        string city;
        string district;
        string country;
        string phone;

        public ShopFactory(string name, string city, string district, string country, string phone)
        {
            this.name = name;
            this.city = city;
            this.district = district;
            this.country = country;
            this.phone = phone;
        }

        public Shop Instance => new Shop(_id++, name, city, district, country, phone);
    }
}
