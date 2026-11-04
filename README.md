# Распопов Егор ИТ-12 Лабораторная №3

# Задание 1

## Задача 9

### Текст задачи

1.9. Заполнение двумерных массивов.

1. Первый массив, размерностью N x M, заполняется данными, вводимыми с клавиатуры, так что заполнение ведется по строкам от первых элементов строки к последним.
2. Второй массив, размерностью N x N, заполняется случайными числами так, что четные числа заносятся в элементы массива, которые на шахматной доске были бы черными, а нечетные числа заносятся в элементы, которые на шахматной доске были бы белыми.
3. Третий массив, размерностью N x N, заполняется для произвольного N так же, как для N=5:

```csharp
11  0  0  0  0
 7 12  0  0  0
 4  8 13  0  0
 2  5  9 14  0
 1  3  6 10 15
 ```

### Алгоритм решения

1. Создается класс Array с закрытым полем _array типа int[,].
2. Конструктор Array(int n, int m) заполняет двумерный массив построчно элементами, вводимыми пользователем с клавиатуры с проверкой ввода с помощью класса Validator.
3. Конструктор Array(int n, Random random) создает квадратную матрицу N x N. Проверяется условие "шахматной доски": если (i + j) % 2 == 1 (черная клетка), генерируется четное случайное число random.Next(0, 50) * 2, иначе (белая клетка) — нечетное random.Next(0, 50) * 2 + 1.
4. Конструктор Array(int n) заполняет нижний треугольник матрицы по диагоналям, параллельным побочной/главной, последовательно возрастающими числами начиная с левого нижнего угла, аналогом шаблона для N=5.
5. Вывод массивов на экран реализован с помощью метода Print().

Реализация конструкторов класса Array:

```csharp
namespace Laba3;

internal class Array
{
    private int[,]? _array;

    public Array(int n, int m)
    {
        Validator validator = new Validator();
        _array = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                _array[i, j] = validator.ReadInt($"Введите элемент на позиции [{i},{j}]: ");
            }
        }
    }

    public Array(int n, Random random)
    {
        _array = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                bool black = (i + j) % 2 == 1;
                _array[i, j] = black ? random.Next(0, 50) * 2 : random.Next(0, 50) * 2 + 1;
            }
    }

    public Array(int n)
    {
        _array = new int[n, n];
        int c = 0;
        for (int k = 1; k <= n; k++)
        {
            for (int t = 0; t < k; t++)
            {
                _array[n - k + t, t] = ++c;
            }
        }               
    }

    public void Print()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                Console.Write($"{_array[i, j],4}");
            }   
            Console.WriteLine();
        }
    }
}
```

### Тестирование

<img width="389" height="569" alt="image" src="https://github.com/user-attachments/assets/3c128e33-d184-4fb9-bcc7-bbc51e30df03" />

# Задание 2

## Задача 9

### Текст задачи

2.9. Работа с двумерными массивами.

Задан двумерный массив. Найдите сумму элементов первого столбца без одного последнего элемента, сумму элементов второго столбца без двух последних, сумму третьего столбца без трех последних и т.д. Последний столбец не обрабатывается. Среди найденных сумм найдите максимальную.

### Алгоритм решения

1. В класс Array добавляется метод BestColumn().
2. Осуществляется перебор столбцов от 0 до m - 2 (последний столбец m - 1 пропускается).
3. Для каждого столбца j суммируются элементы от строки 0 до n - (j + 2).
4. В процессе выполнения находится максимальное значение суммы среди всех рассмотренных столбцов (best).

Реализация метода:

```csharp
public int BestColumn()
{
    int n = _array.GetLength(0);
    int m = _array.GetLength(1);

    int best = -1000;
    int sum = 0;
    for (int j = 0; j < m - 1; j++)
    {
        sum = 0;
        for (int i = 0; i < n - (j + 1); i++)
        {
            sum += _array[i, j];
        }
        if (sum > best)
        {
            best = sum;
        }
    }

    return best;
}
```

### Тестирование

<img width="367" height="379" alt="image" src="https://github.com/user-attachments/assets/b9c14dd9-4dea-4624-89b2-c3f46abbc2c3" />

# Задание 3

## Задача 9

### Текст задачи

3.9. Работа с двумерными массивами как с матрицами.

Посчитать значение матричного выражения:
(A + 4 * B) - C^T

Принять решение с использованием перегрузки операторов и перегрузки метода ToString().

### Алгоритм решения

1. В классе Array перегружены бинарные операторы + и - для сложения и вычитания матриц одинаковой размерности (с проверкой размеров в методе CheckSameSize), а также оператор * для умножения матрицы на число k.
2. Метод Transpose() возвращает новый объект Array, представляющий транспонированную матрицу.
3. Метод ToString() переопределяется для формирования удобного табличного текстового представления двумерного массива.
4. Выражение вычисляется одной строкой: (arr1 + 4 * arr2) - arr3.Transpose().

Реализация перегрузки операторов и методов:

```csharp
public static Array operator +(Array x, Array y)
{
    CheckSameSize(x, y);

    int n = x._array.GetLength(0);
    int m = x._array.GetLength(1);
    int[,] newArr = new int[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            newArr[i, j] = x._array[i, j] + y._array[i, j];
        }
    }

    return new Array(newArr);
}

public static Array operator -(Array x, Array y)
{
    CheckSameSize(x, y);

    int n = x._array.GetLength(0);
    int m = x._array.GetLength(1);
    int[,] newArr = new int[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            newArr[i, j] = x._array[i, j] - y._array[i, j];
        }
    }

    return new Array(newArr);
}

public static Array operator *(int k, Array x)
{
    int n = x._array.GetLength(0);
    int m = x._array.GetLength(1);
    int[,] newArr = new int[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            newArr[i, j] = x._array[i, j] * k;
        }
    }

    return new Array(newArr);
}

public Array Transpose()
{
    int n = _array.GetLength(0);
    int m = _array.GetLength(1);
    int[,] newArr = new int[m, n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            newArr[j, i] = _array[i, j];
        }
    }

    return new Array(newArr);
}

public override string ToString()
{
    string s = "";
    for (int i = 0; i < _array.GetLength(0); i++)
    {
        for (int j = 0; j < _array.GetLength(1); j++)
        {
            s += $"{_array[i, j],4}";
        }
        s += "\n";
    }
    return s; 
}
```

### Тестирование и проверка

<img width="366" height="413" alt="image" src="https://github.com/user-attachments/assets/29d341b6-b43a-484d-a8fc-f6a0164ca10b" />
<img width="269" height="58" alt="image" src="https://github.com/user-attachments/assets/4aef0910-4c09-4e27-91fd-63045d5b3018" />
<img width="178" height="70" alt="image" src="https://github.com/user-attachments/assets/f0e2c62c-5736-46ff-a194-1d6c98a12ebc" />
<img width="282" height="61" alt="image" src="https://github.com/user-attachments/assets/7b36c0ed-e574-4dc3-ae9a-87d69e0394ad" />

# Задание 4

## Задача 9

### Текст задачи

4.9. Бинарные файлы.

Получить в другом файле последовательного доступа все компоненты исходного файла, кроме тех, которые кратны k.

### Алгоритм решения

1. Метод FileTasks.FillBinary заполняет исходный файл бинарными данными (случайными целыми числами).
2. Метод FileTasks.CopyExceptMultiples считывает числа из исходного файла с помощью BinaryReader и записывает во второй файл с помощью BinaryWriter только те из них, для которых условие x % k != 0 истинно.
3. Проверяется корректность значения k (не должно быть равно 0).

Реализация метода:

```csharp
public static void CopyExceptMultiples(string place1, string place2, int k)
{
    if (k == 0)
    {
        throw new ArgumentException("k не должно быть 0.");
    }
    using BinaryReader r = new BinaryReader(File.OpenRead(place1));
    using BinaryWriter w = new BinaryWriter(File.Create(place2));
    while (r.BaseStream.Position < r.BaseStream.Length)
    {
        int x = r.ReadInt32();
        if (x % k != 0)
        {
            w.Write(x);
        }
    }
}
```

### Тестирование

<img width="464" height="182" alt="image" src="https://github.com/user-attachments/assets/6c93814a-327d-45ea-a720-06ac8f4aa404" />

# Задание 6

## Задача 9

### Текст задачи

6.9. Текстовые файлы (по одному числу в строке).

В файле найти сумму максимального и минимального элементов.

### Алгоритм решения

1. Метод FileTasks.FillIntLines создает текстовый файл, записывая случайные целые числа по одному в строке.
2. Метод FileTasks.SumMaxMin поочередно считывает строки файла посредством File.ReadLines, находит максимальный (max) и минимальный (min) элементы и возвращает их сумму. Для предотвращения переполнения результат приводится к типу long.

Реализация метода:

```csharp
public static long SumMaxMin(string path)
{
    bool any = false;
    int max = int.MinValue, min = int.MaxValue;
    foreach (string line in File.ReadLines(path))
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            continue;
        }
        int x = int.Parse(line.Trim());
        if (x > max)
        {
            max = x;
        }
        if (x < min)
        {
            min = x;
        }
        any = true;
    }
    if (!any) throw new InvalidOperationException("Файл пуст.");
    return (long)max + min;
}
```

### Тестирование

<img width="397" height="321" alt="image" src="https://github.com/user-attachments/assets/1970b7af-a72b-4f8d-981b-04e85a3d6851" />

# Задание 7

## Задача 9

### Текст задачи

7.9. Текстовые файлы (по несколько чисел в строке).

Вычислить сумму чётных элементов.

### Алгоритм решения

1. Метод FileTasks.FillIntRows генерирует строки со случайным количеством целых чисел, разделенных пробелами.
2. Метод FileTasks.SumEven считывает файл постранично, разбивает каждую строку на элементы с помощью Split и суммирует только четные числа (x % 2 == 0).

Реализация метода:

```csharp
public static long SumEven(string path)
{
    long s = 0;
    foreach (string line in File.ReadLines(path))
    {
        var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string p in parts)
        {
            int x = int.Parse(p);
            if (x % 2 == 0)
            {
                s += x;
            }
        }
    }
    return s;
}
```

### Тестирование

<img width="405" height="237" alt="image" src="https://github.com/user-attachments/assets/bd231952-b9f8-4cbf-ac13-953563aedb27" />

# Задание 8

## Задача 9

### Текст задачи

8.9. Текстовый файл.

Создать новый текстовый файл, каждая строка которого содержит первый символ соответствующей строки исходного файла.

### Алгоритм решения

1. Метод FileTasks.CreateText создает исходный текстовый файл со строками текста.
2. Метод FileTasks.FirstCharsToFile считывает исходный файл и формирует список строк, состоящих из первого символа каждой строки (line[0]), если строка не пуста. Полученный результат сохраняется в новый файл в кодировке UTF-8.

Реализация метода:
```csharp
public static void FirstCharsToFile(string place1, string place2)
{
    List<string> res = new List<string>();
    foreach (string line in File.ReadLines(place1))
    {
        res.Add(line.Length > 0 ? line[0].ToString() : "");
    }
    File.WriteAllLines(place2, res, Encoding.UTF8);
}
```

### Тестирование

<img width="367" height="307" alt="image" src="https://github.com/user-attachments/assets/fe6a2621-e4b7-442e-bd83-10f8bb421a5a" />
