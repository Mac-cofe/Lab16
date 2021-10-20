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
using Newtonsoft.Json;

namespace Lab16_Exp2
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Exp2\Products.json";
            //string[] products;
            int i = 0;
            int k = 0;
            string product_s = "";
            //string line;
            //double maxPrice = 0;
            //string nameProduct_maxPrice = "";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            Console.WriteLine("В файле хранятся данные о следующих товарах:");

            using (FileStream fstream = File.OpenRead(path))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                product_s = Encoding.UTF8.GetString(array);
                //Console.WriteLine($"Текст из файла: {product_s}");
            }

            //Console.WriteLine(product_s);

            Product product6 = System.Text.Json.JsonSerializer.Deserialize<Product>(product_s);
            
            








            //Console.WriteLine($"Самый дорогой товар {nameProduct_maxPrice}, его стоимость {maxPrice} за 1 кг.");
            Console.WriteLine("Текст прочитан");
            Console.ReadKey();
        }
    }

    class Product
    {
        public int KodProduct { get; set; }
        public string NameProduct { get; set; }
        public double PriceProduct { get; set; }

    }
}
