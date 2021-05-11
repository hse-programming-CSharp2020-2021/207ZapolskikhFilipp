using System.Text.Json.Serialization;

namespace DataBaseTask2
{
	class Buyer : IEntity
	{
		public long Id { get; }
		public string Name { get; }
		public string Surname { get; }
		public string Address { get; }
		public string City { get; }
		public string District { get; }
		public string Country { get; }
		public string ZipCode { get; }

		public Buyer(long id, string name, string surname)
		{
			Id = id;
			Name = name;
			Surname = surname;
		}
		[JsonConstructor]
		public Buyer(long id, string name, string surname, string address, string city, string district,
			string country, string zipcode) : this(id, name, surname)
		{
			Address = address;
			City = city;
			District = district;
			Country = country;
			ZipCode = zipcode;
		}
	}
}
