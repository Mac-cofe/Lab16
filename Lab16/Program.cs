using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;


namespace Lab16_Exp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Exp2";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();                       // Создадим новый каталог C:\Exp2
            }
            string path_file = @"C:\Exp2\Products.json";
            if (!File.Exists(path_file))
            {
                File.Create(path_file);                       // Создадим Файл C:\Exp2\Products.txt
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
             };

            Console.WriteLine("Заполним данные на 5 товаров");
            Console.WriteLine();
            Product[] arrayProduct = new Product[5];  // массив экземлпяров класса Product

            try
            {
                using (StreamWriter file = new StreamWriter(path_file, true))
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        arrayProduct[i] = new Product();
                        Console.WriteLine($"Введите данные о {i + 1}-ом товаре");
                        arrayProduct[i].Input();                                                 // ввод данных о товаре в массив
                    }
                    string jsonString = JsonSerializer.Serialize(arrayProduct, options);    
                    file.WriteLine(jsonString);
                    //Console.WriteLine(jsonString);                            // проверка, что записалось в jsonString
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }

            Console.WriteLine("Текст записан в файл");
            Console.ReadKey();
        }
}

class Product
{
    public int KodProduct { get; set; }
    public string NameProduct { get; set; }
    public double PriceProduct { get; set; }

        public void Input()                                     // ввод информации о товаре
        {
            try
            {
                Console.WriteLine("Введите код товара");
                KodProduct = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                NameProduct = Console.ReadLine();
                Console.WriteLine("Введите цену за 1 кг");
                PriceProduct = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }

        }

}
}
