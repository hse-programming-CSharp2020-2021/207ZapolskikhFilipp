using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
	[Serializable]
	public class Human
	{
		public string Name { get; set; }

		public Human() { }
		public Human(string name)
		{
			this.Name = name;
		}
		public override string ToString() => Name;
	}
	[Serializable]
	public class Professor : Human
	{
		public Professor() { }
		public Professor(string name) : base(name) { }
	}
	[Serializable]
	public class Dept
	{
		public string DeptName { get; set; }
		List<Human> staff;
		public List<Human> Staff { get { return staff; } set { staff = value; } }

		public Dept() { }
		public Dept(string name, Human[] staffList)
		{
			this.DeptName = name;
			staff = new List<Human>(staffList);
		}
		public override string ToString() => $"{DeptName}: {string.Join(", ", Staff)}";
	}
	[Serializable]
	public class University
	{
		public string UniversityName { get; set; }
		public List<Dept> Departments { get; set; }

		public override string ToString() => $"Name: {UniversityName}, departments:{Environment.NewLine}" +
			$"{string.Join(Environment.NewLine, Departments)}";
	}
	class Program
	{
		static void Main()
		{
			Dept[] depts = new Dept[2];
			depts[0] = new Dept("CS", new Human[] { new Human("Vseleon"), new Professor("Fedotov") });
			depts[1] = new Dept("HSB", new Human[] { new Human("Alice"), new Professor("Bob"), new Human("George") });
			University university = new() { UniversityName = "HSE", Departments = new List<Dept>(depts) };
			University university2;

			XmlSerializer formatter = new(typeof(University), new Type[] { typeof(Dept), typeof(Human), typeof(Professor) });
			using (FileStream stream = File.OpenWrite("hse.xml"))
				formatter.Serialize(stream, university);
			using (FileStream stream = File.OpenRead("hse.xml"))
				university2 = (University)formatter.Deserialize(stream);

			Console.WriteLine(university2);
		}
	}
}
