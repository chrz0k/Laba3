namespace Laba3;

using System;
using System.IO;
using System.Text;

internal class Program
{
    public static void Pause()
    {
        Console.WriteLine("============================");
        Console.Write("Нажмите любую кнопку для продолжения...");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        Validator validator = new Validator();

        int choice = 1;
        while (choice != 0)
        {
            Console.Clear();
            Console.WriteLine("=== Лабораторная работа №3 ===");
            Console.WriteLine(" 0) Выход из программы");

            Console.WriteLine(" 1) 1.9.");
            Console.WriteLine(" 2) 2.9.");
            Console.WriteLine(" 3) 3.9.");
            Console.WriteLine(" 4) 4.9.");
            Console.WriteLine(" 5) 5.9.");
            Console.WriteLine(" 6) 6.9.");
            Console.WriteLine(" 7) 7.9.");
            Console.WriteLine(" 8) 8.9.");

            Console.WriteLine("============================");
            choice = validator.ReadInt("Выберите пункт(): ", 0, 8);
            Console.WriteLine("============================");

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Заполнение первого массива NxM:");
                        int n = validator.ReadInt("Введите N строк: ");
                        int m = validator.ReadInt("Введите M столбцов: ");
                        Array arr1 = new Array(n, m);
                        Console.WriteLine();

                        Console.WriteLine("Заполнение второго массива NxN:");
                        n = validator.ReadInt("Введите N: ");
                        Array arr2 = new Array(n, new Random());
                        Console.WriteLine();

                        Console.WriteLine("Заполнение третьего массива NxN:");
                        n = validator.ReadInt("Введите N: ");
                        Array arr3 = new Array(n);
                        Console.WriteLine();

                        Console.WriteLine("Массивы: ");
                        Console.WriteLine("1й массив:");
                        arr1.Print();

                        Console.WriteLine("2й массив:");
                        arr2.Print();

                        Console.WriteLine("3й массив:");
                        arr3.Print();

                        Pause();
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Заполнение массива NxN:");
                        int n = validator.ReadInt("Введите N: ");
                        Array arr = new Array(n, n);
                        Console.WriteLine();

                        Console.WriteLine("Массив:");
                        arr.Print();
                        Console.WriteLine($"Ответ: {arr.BestColumn()}");

                        Pause();
                        break;
                    }

                case 3:
                    {
                        int n = validator.ReadInt("Введите значение N для всех матриц: ");
                        
                        Console.WriteLine("Заполнение первого массива NxN:");
                        Array arr1 = new Array(n, n);
                        Console.WriteLine();

                        Console.WriteLine("Заполнение второго массива NxN:");
                        Array arr2 = new Array(n, n);
                        Console.WriteLine();

                        Console.WriteLine("Заполнение третьего массива NxN:");
                        Array arr3 = new Array(n, n);
                        Console.WriteLine();

                        Console.WriteLine("Массивы:");
                        Console.WriteLine($"1й массив:\n{arr1}");
                        Console.WriteLine($"2й массив:\n{arr2}");
                        Console.WriteLine($"3й массив:\n{arr3}");

                        Console.WriteLine("Дан пример: (А+4*В)-Ст");
                        Console.WriteLine($"Ответ:\n{(arr1 + 4 * arr2) - arr3.Transpose()}");

                        Pause();
                        break;
                    }

                case 4:
                    {
                        int n = validator.ReadInt("Введите кол-во цифр для исходного файла: ", 1, 20);
                        FileTasks.FillBinary("Ex4.bin", n, new Random());
                        Console.WriteLine("Исходный файл: " + string.Join(" ", FileTasks.ReadBinary("Ex4.bin")));
                        Console.WriteLine();

                        n = validator.ReadInt("Введите k(убрать элементы которые кратны k): ", 1, 100);
                        FileTasks.CopyExceptMultiples("Ex4.bin", "Ex4_edit.bin", n);
                        Console.WriteLine($"\nФайл без кратных {n}: " + string.Join(" ", FileTasks.ReadBinary("Ex4_edit.bin")));

                        Pause();
                        break;
                    }

                case 5:
                    {
                        Console.WriteLine("Не сделал :(");

                        Pause();
                        break;
                    }

                case 6:
                    {
                        int n = validator.ReadInt("Введите кол-во цифр для исходного файла: ");
                        FileTasks.FillIntLines("Ex6.txt", n, new Random());
                        Console.WriteLine("Исходный файл: ");
                        FileTasks.PrintTxt("Ex6.txt");
                        Console.WriteLine("\nОтвет (max+min) : " + FileTasks.SumMaxMin("Ex6.txt"));

                        Pause();
                        break;
                    }

                case 7:
                    {
                        int n = validator.ReadInt("Введите кол-во строк для исходного файла: ");
                        FileTasks.FillIntRows("Ex7.txt", n, new Random());
                        Console.WriteLine("Исходный файл: ");
                        FileTasks.PrintIntRows("Ex7.txt");
                        Console.WriteLine("\nСумма четных чисел: " + FileTasks.SumEven("Ex7.txt"));

                        Pause();
                        break;
                    }

                case 8:
                    {
                        FileTasks.CreateText("Ex8.txt");
                        Console.WriteLine("Исходный файл:");
                        FileTasks.PrintTxt("Ex8.txt");
                        FileTasks.FirstCharsToFile("Ex8.txt", "Ex8_edit.txt");
                        Console.WriteLine("\nРезультат:\n" + File.ReadAllText("Ex8_edit.txt", Encoding.UTF8));

                        Pause();
                        break;
                    }

                case 0:
                    Console.WriteLine("Выход из программы.");
                    break;

                default:
                    Console.WriteLine("Ошибка! Введено неверное значение.");
                    Pause();
                    break;
            }
        }
    }
}