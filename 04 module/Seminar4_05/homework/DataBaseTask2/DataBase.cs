using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace DataBaseTask2
{
    class DataBase
    {
        readonly IDictionary<Type, object> _tables = new Dictionary<Type, object>();
		readonly JsonSerializerOptions serializerOptions
            = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };

        public string Name { get; }

        public DataBase(string name) => Name = name;

        public void CreateTable<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (_tables.ContainsKey(tableType))
                throw new DataBaseException($"Table already exists {tableType.Name}!");

            _tables[tableType] = new List<T>();
        }

        public void InsertInto<T>(IEntityFactory<T> values) where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            ((List<T>)_tables[tableType]).Add(values.Instance);
        }

        public IEnumerable<T> Table<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            return (IEnumerable<T>)_tables[tableType];
        }

        public void Save()
		{
            try
			{
                foreach (Type type in _tables.Keys)
                    File.WriteAllText($"DB{type.Name}.json", JsonSerializer.Serialize(_tables[type], serializerOptions));
			}
            catch (Exception exception)
			{
                Console.WriteLine("Unable to save database tables");
                Console.WriteLine(exception.Message);
			}
		}

        void Read(Type[] tableTypes)
		{
            try
            {
                foreach (Type type in tableTypes)
                    _tables[type] = JsonSerializer.Deserialize(File.ReadAllText($"DB{type.Name}.json"),
                        typeof(List<>).MakeGenericType(new Type[] { type }), serializerOptions);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to read database tables");
                Console.WriteLine(exception.Message);
            }
        }

        public static DataBase FromFiles(string name, Type[] tableTypes)
		{
            DataBase db = new DataBase(name);
            db.Read(tableTypes);
            return db;
		}
    }
}
