using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;

namespace Lab16_Exp2
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Exp2\Products.json";
            double maxPrice = 0;
            string nameProduct = "";
            string product_s;
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            Console.WriteLine("В файле хранятся данные о следующих товарах:");
            product_s = File.ReadAllText(path);
            Console.WriteLine(product_s);

            Product[] product = JsonSerializer.Deserialize<Product[]>(product_s);
            
            Console.WriteLine("Информация из файла прочтена");
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].PriceProduct > maxPrice)
                {
                    maxPrice = product[i].PriceProduct;
                    nameProduct = product[i].NameProduct;
                }
            }
            Console.WriteLine($"Самый дорогой товар: {nameProduct}, его цена: {maxPrice} за 1 кг.");
            Console.ReadKey();
        }
    }


    public class Product
    {
        public int KodProduct { get; set; }
        public string NameProduct { get; set; }
        public double PriceProduct { get; set; }

    }

}
