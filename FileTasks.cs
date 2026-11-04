using System.Text;

namespace Laba3;

internal class FileTasks
{
    public static void FillBinary(string path, int count, Random random)
    {
        using var w = new BinaryWriter(File.Create(path));
        for (int i = 0; i < count; i++)
        {
            w.Write(random.Next(-100, 101));
        } 
    }

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

    public static List<int> ReadBinary(string path)
    {
        var list = new List<int>();
        BinaryReader r = new BinaryReader(File.OpenRead(path));
        while (r.BaseStream.Position < r.BaseStream.Length)
        {
            list.Add(r.ReadInt32());
        }

        r.Close();
        return list;
    }

    public static void FillIntLines(string path, int count, Random random)
    {
        List<string> lines = new List<string>();
        for (int i = 0; i < count; i++)
        {
            lines.Add(random.Next(-100, 101).ToString());
        }
        File.WriteAllLines(path, lines, Encoding.UTF8);
    }

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

    public static void PrintTxt(string path)
    {
        foreach (string line in File.ReadLines(path))
        {
            if (string.IsNullOrWhiteSpace(line))
            { 
               continue;
            }
            string text = line.Trim();
            Console.WriteLine(text);
        }
    }

    public static void FillIntRows(string path, int rows, Random random)
    {
        List<string> lines = new List<string>();
        for (int i = 0; i < rows; i++)
        {
            int cnt = random.Next(1, 8);
            var nums = new string[cnt];
            for (int j = 0; j < cnt; j++)
            {
                nums[j] = random.Next(-100, 101).ToString();
            }
                
            lines.Add(string.Join(" ", nums));
        }
        File.WriteAllLines(path, lines, Encoding.UTF8);
    }

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

    public static void PrintIntRows(string path)
    {
        foreach (string line in File.ReadLines(path))
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string p in parts)
            {
                Console.Write($"{p}\t ");
            }
            Console.WriteLine();
        }
    }

    public static void CreateText(string path)
    {
        string[] lines =
        {
            "Привет, мир",
            "Hello world",
            "",
            "Строка номер четыре",
            "123 abc"
        };
        File.WriteAllLines(path, lines, Encoding.UTF8);
    }

    public static void FirstCharsToFile(string place1, string place2)
    {
        List<string> res = new List<string>();
        foreach (string line in File.ReadLines(place1))
        {
            res.Add(line.Length > 0 ? line[0].ToString() : "");
        }
        File.WriteAllLines(place2,res, Encoding.UTF8);
    }
}
