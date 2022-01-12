using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Программно создайте текстовый файл и запишите в него 10 случайных чисел. Затем программно
            откройте созданный файл, рассчитайте сумму чисел в нем, ответ выведите на консоль.
            */

            Console.WriteLine("Запись в файл 10-ти случайных числе и последующее суммирование чисел, " +
                              "прочитанных из файла\n");

            const string pathToFile = "log.txt";
            WriteRandomNumbersToFile(pathToFile);
            Console.WriteLine("Сумма чисел, прочитанных из файла {0}, равна {1}",
                              pathToFile,
                              SumNumbersFromFile(pathToFile));
            Console.ReadKey();

        }
        static void WriteRandomNumbersToFile(string path,
                                             int count = 10,
                                             int minlimit = 0,
                                             int maxlimit = 100)
        // Метод записывает в текстовый файл заданное количество случайных чисел
        {
            Random rnd = new Random();
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(rnd.Next(minlimit, maxlimit + 1));
                }
            }
        }

        static int SumNumbersFromFile(string path)
        // Метод суммирует конвертированные в числа значения всех строк в файле
        {
            if (File.Exists(path))
            {
                int sum = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sum += Convert.ToInt32(line);
                    }
                }
                return sum;
            }
            else
            {
                return -1;
            }
        }
    }
}
