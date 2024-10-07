namespace Task01;
using static BeautifulTyping;

class Program
{
    // Метод для назначения значений.
    static void AssignValues(out string[,] a, int n, int m)
    {
        a = new string[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double x = i * m + j + 1;
                double value = Math.Pow(Math.Pow(x, 3) + 1, 0.5)
                    - Math.Pow(Math.Pow(x, 2), 0.5);
                a[i, j] = value.ToString("F3");
            }
        }
    }
    // Метод для записи массива в файл.
    static bool Save(string fileName, string[,] a, int n, int m)
    {
        /* Было замечено, что при запуске программы из VS Code и из Visual
               Studio расположение текущей директории различается, поэтому
               приводим ее к общему виду для сохранения файла в одну папку с
               запускаемым файлом. */
        string currentPath = Directory.GetCurrentDirectory();
        if (currentPath.Contains("bin/Debug/net6.0"))
        {
            currentPath = currentPath.Remove(currentPath.Length - 16);
        }
        else
        {
            currentPath += "/";
        }
        try
        {
            using (var sw =
                File.CreateText($"{currentPath}{fileName}.txt"))
            {
                for (int i = 0; i < n; i++)
                {
                    string str = "";
                    for (int j = 0; j < m; j++)
                    {
                        str += $"{a[i, j]};";
                    }
                    sw.WriteLine(str);
                }
            }
            return true;
        }
        // Ловим ошибки
        catch (ArgumentException)
        {
            Print("Некорректное имя файла, попробуй еще раз: ", color: ConsoleColor.Red);
            return false;
        }
        catch (IOException)
        {
            Print("Файл не сохраняется, попробуй еще раз: ", color: ConsoleColor.Red);
            return false;
        }
        catch (Exception e)
        {
            PrintLine($"Произошла ошибка: {e.Message}", color: ConsoleColor.Red);
            Print("Попробуй еще раз: ");
            return false;
        }
    }

    static void Main()
    {
        Random rand = new Random();
        int n = rand.Next(1, 17);
        int m = rand.Next(1, 12);
        string[,] a;
        AssignValues(out a, n, m);
        Print("Введите название файла для сохранения без расширения: ");
        string fileName = Console.ReadLine();
        Console.WriteLine();
        while (!Save(fileName, a, n, m))
        {
            fileName = Console.ReadLine();
        }
        PrintLine($"Файл {fileName}.txt сохранен", color: ConsoleColor.DarkGreen);
        Console.WriteLine();

        while (true)
        {
            PrintLine("Нажми Q, чтобы выйти, ENTER - чтобы повторить");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                PrintLine("Перезапуск...................");
                Console.Clear();
                Main();
            }
            else if (key == ConsoleKey.Q)
            {
                PrintLine("\rВыход.......");
                Environment.Exit(0);
            }
            else
            {
                PrintLine("\rНе та кнопка!", color: ConsoleColor.Red);
            }
        }
    }
}