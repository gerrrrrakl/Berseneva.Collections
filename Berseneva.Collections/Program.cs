using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Berseneva.Collections.Orders;
using System.Text;
using System.Text.Encodings;
using System.Text.Encodings.Web;
using System.IO;
using System.Threading.Tasks;
using System.Linq;





namespace Berseneva.Collections
{
    class Program
    {
        static void unicId(List<Orders> ord)
        {
            var uniq = "Все записи уникальны";
            var unique = ord.GroupBy(o => o.Id);
            foreach (var item in unique)
                if (item.Count() > 1)
                {
                    uniq = "Id не уникален";
                }
            Console.WriteLine("unicId - метод, проверяющий уникальность записей по свойству Id: " + uniq);
        }

        static void Averageage(List<Orders> ord)
        {
            var avge = ord.Average(x => x.Age);
            Console.WriteLine("Среднее арифметическое возраста покупателей: " + avge);
        }

        static List<Orders> SortOrders(List<Orders> selectedperson)
        {
            selectedperson.Sort(delegate (Orders Age1, Orders Age2)
                { return Age2.Age.CompareTo(Age1.Age); });

            Console.WriteLine("метод SortOrders - отсортированный список по  Age в обратном порядке.");
            foreach (Orders pers in selectedperson)
                Console.WriteLine("{0,3}", pers.Age);


            return selectedperson;

        }


        static List<Orders> ListAge(List<Orders> ageperson)
        {
            var Ageperson = new List<Orders>();
            int j = 0;
            for (int i = 0; i < ageperson.Count; i++)
            {
                if (ageperson[i].Age < 18)

                {
                    Ageperson.Add(ageperson[i]);
                    Console.WriteLine(Ageperson[j]);
                    j++;
                }
            }
            return Ageperson;
        }

        static void GenList(List<Orders> emailperson)
        {
            Console.WriteLine("метод GenList - генерация записей: ");
            var count = emailperson.Count + 1;
            for (var j = count; j < count + 6; j++)
            {
                var person = new Orders();

            Gen1:

                Random rand = new Random();
                int code = rand.Next(920, 939);
                int num = rand.Next(100, 999);
                int num2 = rand.Next(10, 99);
                int num3 = rand.Next(10, 99);
                Random random = new Random();
                person.Id = j;
                person.Email = new((Guid.NewGuid().ToString("n").Substring(0, 18)) + "@yandex.ru");
                person.Phone = "+7 (" + code.ToString() + ") " + num.ToString() + "-" + num2.ToString() + "-" + num3.ToString();
                person.Age = 18;
                person.City = "Город";
                person.Street = "Улица";
                person.Tag = "Сумка";
                person.Price = 999;
                person.CustomerId = new(Guid.NewGuid().ToString("n").Substring(0, 18));
                person.ProductId = new(Guid.NewGuid().ToString("n").Substring(0, 20));

                if ((emailperson.Exists(x => x.ProductId == person.ProductId))
                     || (emailperson.Exists(x => x.CustomerId == person.CustomerId))
                     || (emailperson.Exists(x => x.Phone == person.Phone))
                     || (emailperson.Exists(x => x.Email == person.Email)))
                {
                    goto Gen1;
                }
                Console.WriteLine("{0,25} {1,25} {2,30} {3,25} {4,25}", person.Id, person.Phone, person.Email, person.CustomerId, person.ProductId);
                emailperson.Add(person);
            }

        }
        

            static void Main(string[] args)
            {
                var path = @"D:..\..\..\Orders.csv";


                System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding encoding = Encoding.GetEncoding("windows-1251");

                var lines = File.ReadAllLines(path, encoding);
                var selectedperson = new List<Orders>();
                var ageperson = new List<Orders>();
                var BaseList = new List<Orders>();

                for (var i = 1; i < lines.Length; i++)

                {
                    var splits = lines[i].Split(';');
                    var person = new Orders();

                    person.Id = Convert.ToInt32(splits[0]);
                    person.Name = splits[1];
                    person.Email = splits[2];
                    person.Phone = splits[3];
                    person.Age = Convert.ToInt32(splits[4]);
                    person.City = splits[5];
                    person.Street = splits[6];
                    person.Tag = splits[7];
                    person.Price = Convert.ToInt32(splits[8]);
                    person.CustomerId = splits[9];
                    person.ProductId = splits[10];
                    BaseList.Add(person);
                    selectedperson.Add(person);
                }
            Console.WriteLine("Baselist");
            foreach (Orders pers in BaseList)
                   Console.WriteLine("{0,3}  ",  pers.Age);


            unicId(BaseList);
            SortOrders(selectedperson);
            Console.WriteLine();
            Averageage(selectedperson);
            Console.WriteLine();

            ageperson = ListAge(selectedperson);

            GenList(ageperson);
            Console.WriteLine("2 дополненный список Age + сгенерированный: ");
            foreach (Orders pers in ageperson)
                Console.WriteLine("{0,3}  {1,35}  {2,35} ", pers.Id, pers.Phone, pers.Email);



        }
    }
}