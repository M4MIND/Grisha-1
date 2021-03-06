using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Multiple<string> collection1 = new Multiple<string>();
            Multiple<string> collection2 = new Multiple<string>();

            collection1.Add(new Item<string>("1"));
            collection1.Add("2");
            collection1.Add("4");

            collection2.Add(new Item<string>("1"));
            collection2.Add("2");
            collection2.Add("3");

            Console.WriteLine("Collection 1");
            Dumper(collection1);

            Console.WriteLine("Collection 2");
            Dumper(collection2);

            Console.WriteLine("Объединение");
            Dumper(Multiple<string>.Union(collection1, collection2));
            Console.WriteLine("Пересечение");
            Dumper(Multiple<string>.Intersect(collection1, collection2));
            Console.WriteLine("Разность");
            Dumper(Multiple<string>.Difference(collection1, collection2));
        }

        static void Dumper(Multiple<string> collection)
        {
            collection.collection.ForEach(i =>
            {
                Console.WriteLine($"-> {i.Value}");
            });
            Console.WriteLine("");
        }
    }
    
}
