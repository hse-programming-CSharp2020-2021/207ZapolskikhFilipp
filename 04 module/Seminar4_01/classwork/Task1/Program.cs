using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1
{
	[Serializable]
	class Student
	{
		public override string ToString() => $"Фамилия: {Surname}, курс: {Course}";

		public string Surname { get; init; }
		public int Course { get; init; }
	}
	[Serializable]
	class Group
	{
		public override string ToString() => string.Join<Student>(Environment.NewLine, Students);

		public string Name { get; init; }
		public Student[] Students { get; init; }
	}
	class Program
	{
		static void Main()
		{
			Group[] groups = new Group[] {
				new Group { Name = "БПИ207", Students = new Student[] {
													new Student { Surname = "Горохова", Course = 2 },
													new Student { Surname = "Шмаков", Course = 3 },
													new Student { Surname = "Безруков", Course = 1 } } },
				new Group { Name = "БПИ208", Students = new Student[] {
													new Student { Surname = "Иванов", Course = 4 },
													new Student { Surname = "Голубева", Course = 1 },
													new Student { Surname = "Смирнова", Course = 1 } } } };
			Group[] groups2 = new Group[2];

			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream stream = File.OpenWrite("groups.bin"))
				formatter.Serialize(stream, groups);
			using (FileStream stream = File.OpenRead("groups.bin"))
				groups2 = (Group[])formatter.Deserialize(stream);

			Array.ForEach(groups2, Console.WriteLine);
		}
	}
}
