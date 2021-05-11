namespace DataBaseTask2
{
    class BuyerFactory : IEntityFactory<Buyer>
    {
        static long _id = 1;
        string name;
        string surname;
        string address;
        string city;
        string district;
        string country;
        string zipcode;

        public BuyerFactory(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public BuyerFactory(string name, string surname, string address, string city, string district, string country,
            string zipcode) : this(name, surname)
		{
            this.address = address;
            this.city = city;
            this.district = district;
            this.country = country;
            this.zipcode = zipcode;
		}

        public Buyer Instance => new Buyer(_id++, name, surname, address, city, district, country, zipcode);
    }
}
