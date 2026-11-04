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

    private static void CheckSameSize(Array x, Array y)
    {
        if (x._array.GetLength(0) != y._array.GetLength(0) || x._array.GetLength(1) != y._array.GetLength(1))
        {
            throw new ArgumentException("Размеры матриц не совпадают.");
        }
    }

    public Array(int[,] newArr)
    {
        _array = (int[,])newArr.Clone();
    }

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
}