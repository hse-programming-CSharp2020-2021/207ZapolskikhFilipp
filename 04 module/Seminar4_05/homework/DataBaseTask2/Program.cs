using System;
using System.Linq;

namespace DataBaseTask2
{
    class Program
    {
        static void Main()
        {
            DataBase db = DataBase.FromFiles("ShopDataBase",
                new Type[] { typeof(Buyer), typeof(Good), typeof(Sale), typeof(Shop) });

            var auchanId = (from shop in db.Table<Shop>()
                            where shop.Name == "Auchan"
                            select shop.Id).First();

            var allAuchanGoods = from good in db.Table<Good>()
                                 where good.ShopId == auchanId
                                 select good.Name;

            foreach (var goodName in allAuchanGoods)
                Console.WriteLine(goodName);

            MakeQueries(db);
            Console.ReadKey();
            db.Save();
        }
        static void MakeQueries(DataBase db)
		{
            
		}
    }
}