using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Выберите любую папку на своем компьютере, имеющую вложенные директории.
            Выведите на консоль ее содержимое и содержимое всех подкаталогов.
            */

            // В качетсве исходной папки будем использовать директорию на два уровня выше текущей.
            // Предполагаем, что при запуске из VisualStudioбудет выведено содержимое
            // директории задачи

            Console.WriteLine("Вывод содержимого дирректории (расположенной на два уровня " +
                "выше текущей), включая поддиректории\n");

            string upupDirPath = "../../.";
            if (Directory.Exists(upupDirPath))
            {
                Console.WriteLine(Path.GetFullPath(upupDirPath) + "\n");
                PrintDirContent(upupDirPath);
            }
            else
            {
                Console.WriteLine("На этом компьютере нет дирректории на два уровня выше, " +
                                  "чем текущая. Программа не может быть выполнена из текущего " +
                                  "расположения.");
            }

            Console.ReadKey();
        }
        static void PrintDirContent(string path, int indent = 0)
        // Метод показывает содержимое текущей директории и её поддиректорий
        // path - путь к директории, indent - уровень отступа при выводе содержимого
        {
            if (Directory.Exists(path))
            {
                // по уровню отступа формируется строка отступа из символов пробела
                string indentString = new String(' ', 2 * indent);

                DirectoryInfo curDir = new DirectoryInfo(path);

                foreach (DirectoryInfo subDir in curDir.GetDirectories())
                {
                    // имена поддиректорий выводятся в квадратных скобках
                    Console.WriteLine(indentString + "[{0}]", subDir.Name);
                    // для поддиректорий метод выполняется рекурсивно с увеличением уровня отступа
                    PrintDirContent(subDir.FullName, indent + 1);
                }

                foreach (FileInfo file in curDir.GetFiles())
                {
                    Console.WriteLine(indentString + file.Name);
                }
            }

        }
    }
}
