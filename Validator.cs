namespace Laba3;

internal class Validator
{
    public int ReadInt(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            string? inputString = Console.ReadLine();
            if (int.TryParse(inputString, out int result))
            {
                return result;
            }

            Console.WriteLine("Ошибка!");
            Console.Write(prompt);
        }
    }

    public int ReadInt(string prompt, int min, int max)
    {
        Console.Write(prompt);
        while (true)
        {
            string? inputString = Console.ReadLine();
            if (int.TryParse(inputString, out int result))
            {
                if (result >= min && result <= max)
                {
                    return result;
                }
            }

            Console.WriteLine("Ошибка!");
            Console.Write(prompt);
        }
    }

    public double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            string? inputString = Console.ReadLine();
            if (double.TryParse(inputString, out double result))
            {
                return result;
            }

            Console.WriteLine("Ошибка!");
            Console.Write(prompt);
        }
    }

    public double ReadDouble(string prompt, double min, double max)
    {
        Console.Write(prompt);
        while (true)
        {
            string? inputString = Console.ReadLine();
            if (double.TryParse(inputString, out double result))
            {
                if (result >= min && result <= max)
                {
                    return result;
                }
            }

            Console.WriteLine("Ошибка!");
            Console.Write(prompt);
        }
    }

    public char ReadChar(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            string? inputString = Console.ReadLine();
            if (char.TryParse(inputString, out char result))
            {
                return result;
            }

            Console.WriteLine("Ошибка!");
            Console.Write(prompt);
        }
    }
}