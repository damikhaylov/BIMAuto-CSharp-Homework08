using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // В качетсве исходной папки будем использовать директорию на два уровня выше текущей

            Console.WriteLine("Вывод содержимого дирректории на два уровня выше текущей, " +
                "включая поддиректории\n");

            string upupDirPath = System.IO.Directory.GetParent(".").Parent.FullName;
            if (System.IO.Directory.Exists(upupDirPath))
            {
                Console.WriteLine(upupDirPath + "\n");
                ShowDirContent(upupDirPath);
            }
            else
            {
                Console.WriteLine("На этом компьютере нет дирректории на два уровня выше, " +
                                  "чем текущая. Программа не может быть выполнена из текущего " +
                                  "расположения.");
            }

            Console.ReadKey();
        }
        static void ShowDirContent(string path, int indent = 0)
        // Метод показывает содержимое текущей директории и её поддиректорий
        // path - путь к директории, indent - уровень отступа при выводе содержимого
        {
            if (System.IO.Directory.Exists(path))
            {
                // по уровню отступа формируется строка отступа из символов пробела
                string indentString = new String(' ', 2 * indent);

                System.IO.DirectoryInfo curDir = new System.IO.DirectoryInfo(path);

                foreach (System.IO.DirectoryInfo subDir in curDir.GetDirectories())
                {
                    // имена поддиректорий выводятся в квадратных скобках
                    Console.WriteLine(indentString + "[{0}]", subDir.Name);
                    // для поддиректорий метод выполняется рекурсивно с увеличением уровня отступа
                    ShowDirContent(subDir.FullName, indent + 1);
                }

                foreach (System.IO.FileInfo file in curDir.GetFiles())
                {
                    Console.WriteLine(indentString + file.Name);
                }
            }

        }
    }
}
