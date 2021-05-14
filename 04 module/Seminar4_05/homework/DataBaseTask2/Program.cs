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
            /*DataBase db = new DataBase("ShopDataBase");

            db.CreateTable<Good>();
            db.CreateTable<Shop>();
            db.CreateTable<Buyer>();
            db.CreateTable<Sale>();

            db.InsertInto(new ShopFactory("Auchan", "Izhevsk", "Ustinovsky", "Russia", "8 (800) 700-58-00"));
            db.InsertInto(new ShopFactory("Magnit", "Orenburg", "Dzerzhinsky", "Russia", "8 (800) 200-90-02"));

            db.InsertInto(new GoodFactory("Nescafe", 2, "Богатый и насыщенный вкус кофе Nescafe Gold Origins Sumatra" +
                " пробуждает чувства и дарит наслаждение", "Coffee"));
            db.InsertInto(new GoodFactory("Rossiya - Shchedraya dusha!", 1, "Восхитительная композиция молочного и к" +
                "лубничного белого шоколада с хрустящей посыпкой. Оригинальный шоколад с открытыми ингредиентами в и" +
                "зысканной упаковке. Формат большой упаковки, подходящий в подарок, для всей семьи, а также чаепития" +
                " вне дома", "Chocolate"));
            db.InsertInto(new GoodFactory("Cezar", 1, "Рекомендуемый способ приготовления готового блюда: пельмени, " +
                "не размораживая, опустить в кипящую подсоленную воду (из расчёта на 600г пельменей 2 литра воды), а" +
                "ккуратно перемешать, довести до кипения и варить при непрерывном кипении воды 7 минут до готовности",
                "Dumplings"));
            db.InsertInto(new GoodFactory("Lipton", 2, "Крепкий и бодрящий чай Lipton English Breakfast – это идеаль" +
                "ный напиток для начала дня, который подарит энергию, силы и вдохновение, настроит на нужную волну с" +
                " самого утра. Вкус, пробуждающий, как первый луч солнца, – что может быть лучше? Одна чашка высокок" +
                "ачественного черного чая с насыщенным вкусом и благородным, мягким ароматом взбодрит в утренние час" +
                "ы и сделает ваше пробуждение комфортным, а день максимально продуктивным. Секрет чая Lipton - много" +
                "летний опыт в купажировании чая и новые технологии, которые позволяют дополнительно обогащать чай н" +
                "атуральным соком из свежих чайных листьев", "Tea"));
            db.InsertInto(new GoodFactory("Russkiy Dar", 1, "Квас \"Русский дар Традиционный\" - это рецепт, с гордо" +
                "стью пронесенный через века. В нем сила ржаного хлеба и свежесть чистой воды, которые дарят вкус на" +
                "стоящего кваса. Времена меняются, а любовь к нему остается, потому что в каждом глотке кваса \"Русс" +
                "кий дар\" вся широта русской души!", "Kvass"));

            db.InsertInto(new BuyerFactory("Alice", "Dumont", "Sovetskaya, 74", "Orenburg", "Central", "Russia", "460006"));
            db.InsertInto(new BuyerFactory("Bob", "Walker", "Truda, 62", "Izhevsk", "Ustinovsky", "Russia", "426067"));

            db.InsertInto(new SaleFactory(43868, 1, 1, 5, 1, 50));
            db.InsertInto(new SaleFactory(29845, 1, 1, 3, 2, 418));
            db.InsertInto(new SaleFactory(34866, 1, 1, 2, 2, 200));
            db.InsertInto(new SaleFactory(28736, 2, 1, 3, 2, 418));
            db.InsertInto(new SaleFactory(92847, 2, 1, 2, 2, 200));
            db.InsertInto(new SaleFactory(24564, 2, 2, 1, 3, 867));*/

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
            var query1 = from sale in db.Table<Sale>()
                         join good in db.Table<Good>() on sale.GoodId equals good.Id
                         group (sale, good) by sale.BuyerId into buyer
                         orderby db.Table<Buyer>().Where(x => x.Id == buyer.Key).Single().Name.Length descending
                         select buyer.Select(x => x.good.Name);
            Console.WriteLine($"Query 1: {string.Join(", ", query1.First().ToArray())}");

            var query2 = from sale in db.Table<Sale>()
                         group sale by sale.GoodCost / sale.GoodCount into price
                         orderby price.Key descending
                         join good in db.Table<Good>() on price.First().GoodId equals good.Id
                         select good.Category;
            Console.WriteLine($"Query 2: {query2.First()}");

            var query3 = from sale in db.Table<Sale>()
                         join shop in db.Table<Shop>() on sale.ShopId equals shop.Id
                         group sale by shop.City into city
                         orderby city.Sum(x => x.GoodCost)
                         select city.Key;
            Console.WriteLine($"Query 3: {query3.First()}");

            var query4 = from sale in db.Table<Sale>()
                         join buyer in db.Table<Buyer>() on sale.BuyerId equals buyer.Id
                         group (sale, buyer) by sale.GoodId into good
                         orderby good.Sum(x => x.sale.GoodCount) descending
                         select good.Select(x => x.buyer.Surname);
            Console.WriteLine($"Query 4: {string.Join(", ", query4.First().ToArray())}");

            var query5 = from shop in db.Table<Shop>()
                         group shop by shop.Country into country
                         orderby country.Count()
                         select country.Count();
            Console.WriteLine($"Query 5: {query5.First()}");

            var query6 = from sale in db.Table<Sale>()
                         join buyer in db.Table<Buyer>() on sale.BuyerId equals buyer.Id
                         join shop in db.Table<Shop>() on sale.ShopId equals shop.Id
                         where buyer.City != shop.City
                         select sale.Id;
            Console.WriteLine($"Query 6: {string.Join(", ", query6.ToArray())}");

            Console.WriteLine($"Query 7: {db.Table<Sale>().Select(sale => sale.GoodCost).Sum()}");
        }
    }
}