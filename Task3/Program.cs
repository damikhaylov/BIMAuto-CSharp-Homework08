using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Вручную подготовьте текстовый файл с фрагментом текста. Напишите программу, которая 
            выводит статистику по файлу - количество символов, строк и слов в тексте.
            */

            Console.WriteLine("Подсчёт количества строк, слов, символов в файле\n");

            const string path = "../../text.txt";
            int countLines = 0;
            int countWords = 0;
            int countSymbols = 0;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        countLines++;
                        countWords += CountWordsInLine(line);
                        countSymbols += line.Length;
                    }
                }
                Console.WriteLine("Количество строк в файле {0}: {1}", path, countLines);
                Console.WriteLine("Количество слов в файле {0}: {1}", path, countWords);
                Console.WriteLine("Количество символов в файле {0} (не считая символов перевода строки): {1}", path, countSymbols);
            }
            else
            {
                Console.WriteLine("Файл {0} не существует", path);
            }
            Console.ReadKey();
        }
        static int CountWordsInLine(string line)
        // Метод подсчитывает число слов в строке
        {
            // Используется перегрузка метода Split, удаляющая из массива пустые элементы
            // при наличии нескольких пробелов между словами.
            char[] delimeters = new char[] { ' ' };
            return line.Split(delimeters, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
