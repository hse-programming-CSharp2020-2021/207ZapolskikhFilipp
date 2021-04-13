using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Task2DataContract
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public string Name { get; set; }
        public Human() { }
        public Human(string name)
        {
            this.Name = name;
        }
    }
    [DataContract]
    public class Professor : Human
    {
        public Professor()
        {

        }
        public Professor(string name) : base(name) { }
    }
    [DataContract]
    public class Dept
    {
        [DataMember]
        public string DeptName { get; set; }
        List<Human> staff;
        [DataMember]
        public List<Human> Staff { get { return staff; } set { staff = value; } }
        public Dept() { }
        public Dept(string name, Human[] staffList)
        {
            this.DeptName = name;
            staff = new List<Human>(staffList);
        }
    }
    [DataContract]
    public class University
    {
        public University() { }
        [DataMember]
        public string UniversityName { get; set; }
        [DataMember]
        public List<Dept> Departments { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            University HSE = new University();
            HSE.UniversityName = "NRU HSE";

            Human[] deptStaff = { new Professor("Ivanov"),
                      new Professor("Petrov")
                    };

            Dept SE = new Dept("SE", deptStaff);
            HSE.Departments = new List<Dept>();
            HSE.Departments.Add(SE);

            University MSU = new University();
            MSU.UniversityName = "MSU";

            Human[] deptStaffM = { new Professor("Ivanov"),  new Professor("Chizov"),
                      new Professor("Petrov")
                    };

            Dept SEM = new Dept("SEM", deptStaffM);
            MSU.Departments = new List<Dept>();
            MSU.Departments.Add(SEM);

            University[] universities = new University[] { HSE, MSU };

            DataContractSerializer serializer = new(typeof(University[]), new Type[] { typeof(Professor) });
            // Сериализация
            using (Stream file = new FileStream("ContractSer.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.WriteObject(file, universities);
            }

            // Десериализация
            University[] deserial;
            using (Stream file = File.OpenRead("ContractSer.xml"))
            {
                deserial = (University[])serializer.ReadObject(file);
                Console.WriteLine("XML - " + deserial[0].UniversityName);
                Console.WriteLine("XML - " + deserial[1].UniversityName);
            }

            foreach (Dept d in deserial[0].Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }

            foreach (Dept d in deserial[1].Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }

            Console.ReadKey();
        }
    }
}