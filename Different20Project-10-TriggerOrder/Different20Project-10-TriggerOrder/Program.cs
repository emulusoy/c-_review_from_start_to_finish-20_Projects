using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Different20Project_10_TriggerOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Entities1 context = new Entities1();

            Console.WriteLine("##############");

            Console.WriteLine("1-urun listesi");
            Console.WriteLine("2-siparis listesi");
            Console.WriteLine("3-Kasa durumu");
            Console.WriteLine("4-yeni urun satisi");
            Console.WriteLine("5-urun stok guncelle");
            Console.WriteLine();
            Console.WriteLine("##############");

            Console.Write("SECCC");
            string number= Console.ReadLine();

            if (number == "1")
            {
                var values=context.TblProduct.ToList(); 
                foreach (var item in values)
                {
                    Console.WriteLine(item.ProductId + item.ProductName+item.ProductPrice+item.ProductStock);
                }
            }
        }
    }
}
