namespace Task02;
using static BeautifulTyping;

class Program
{
    // Метод для чтения файла
    static string[] ReadFile(string fileName)
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
        return File.ReadAllLines($"{currentPath}{fileName}");
    }
    
    // Метод для проверки файла и его содержимого
    static bool IsFileOk(string fileName)
    {
        string[] rows;
        try
        {
            rows = ReadFile(fileName);
        }
        catch (ArgumentException)
        {
            Print("Некорректное имя файла, попробуй еще раз: ",
                color: ConsoleColor.Red);
            return false;
        }
        catch (DirectoryNotFoundException)
        {
            Print("Файл не найден, попробуй еще раз: ",
                color: ConsoleColor.Red);
            return false;
        }
        catch (FileNotFoundException)
        {
            Print("Файл не найден, попробуй еще раз: ",
                color: ConsoleColor.Red);
            return false;
        }
        catch (IOException)
        {
            Print("Файл не открывается, попробуй еще раз: ",
                color: ConsoleColor.Red);
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            Print("Некорректное имя файла, попробуй еще раз: ",
                color: ConsoleColor.Red);
            return false;
        }
        catch (Exception e)
        {
            PrintLine($"Произошла ошибка: {e.Message}", color: ConsoleColor.Red);
            Print("Попробуй еще раз: ");
            return false;
        }
        if (rows.Length == 0)
        {
            Print("Файл пустой, попробуй другой: ", color: ConsoleColor.Red);
            return false;
        }
        foreach (var row in rows)
        {
            if (row[row.Length - 1] != ';')
            {
                Print("Не хватает разделителя после строки, попробуй другой файл: ",
                    color: ConsoleColor.Red);
                return false;
            }
            foreach (var item in row.Split(';').SkipLast(1).ToArray())
            {
                if (!double.TryParse(item, out double num))
                {
                    Print("В файле присутствуют элементы, которые невозможно " +
                         "конвертировать в число. Попробуй другой: ",
                         color: ConsoleColor.Red);
                    return false;
                }
            }
        }
        return true;
    }

    // Конвертация файла в массив
    static double[,] FileToArray(string fileName)
    {
        string[] rows = ReadFile(fileName);
        int rowsCount = rows.Length;
        // Находим максимальную длинну строки, вдруг массив непрямоугольный
        int maxLenght = 0;
        foreach (var row in rows)
        {
            maxLenght = Math.Max(maxLenght, row.Split(';').Count() - 1);
        }
        // Создаем двумерный массив B
        var b = new double[rowsCount, maxLenght];
        for (int i = 0; i < rowsCount; i++)
        {
            string[] items = rows[i].Split(';').SkipLast(1).ToArray();
            for (int j = 0; j < maxLenght; j++)
            {
                try
                {
                    b[i, j] = double.Parse(items[j]);
                }
                // Если строка короче остальных, достраиваем ее нулями
                catch (IndexOutOfRangeException)
                {
                    b[i, j] = 0;
                }
                catch
                {
                    PrintLine("Произошла ошибка во время обработки массива",
                        color: ConsoleColor.Red);
                    PrintLine("Перезапуск...................");
                    Console.Clear();
                    Main();
                }
            }
        }
        return b;
    }
    
    // Метод для сжатия массива
    static void Compress(ref double[,]? b)
    {
        int rowsCount = b.GetLength(0);
        int columnsCount = b.GetLength(1);
        // Если в изначальном массиве только один столбец, то итоговый будет равен Null
        if (columnsCount == 1)
        {
            b = null;
            return;
        }
        columnsCount /= 2;
        // Создаем новую структуру данных аналогичную B
        var bCompressed = new double[rowsCount, columnsCount];
        // Записываем нечетные столбцы B в новый массив
        for (int i = 0; i < rowsCount; i++)
        {
            var row = new double[] {};
            for (int j = 0; j < b.GetLength(1); j++)
            {
                if (j % 2 != 0)
                {
                    row = (row.Append(b[i, j])).ToArray();
                }
            }
            for (int k = 0; k < columnsCount; k++)
            {
                bCompressed[i, k] = row[k];
            }
        }
        // Обработка прошла успешно, связываем
        b = bCompressed;
    }
    // Метод для вывода массива на экран
    static void RenderArray(double[,] arr)
    {
        if (arr == null)
        {
            PrintLine("Ничего нет");
            return;
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Print($"{arr[i, j]:F3} ", 2);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        PrintLine("Привет!");
        Print("Введи имя файла вместе с расширением: ");
        string? fileName = Console.ReadLine();
        Console.WriteLine();
        // Проверка файла
        while (!IsFileOk(fileName))
        {
            fileName = Console.ReadLine();
        }
        // Файл подходит, читаем в массив
        var b = FileToArray(fileName);
        // Создаем копию массива B
        var bOld = new double[b.GetLength(0), b.GetLength(1)];
        Array.Copy(b, bOld, b.GetLength(0)*b.GetLength(1));
        try
        {
            Compress(ref b);
        }
        catch
        {
            PrintLine("Произошла ошибка во время обработки массива",
                color: ConsoleColor.Red);
            PrintLine("Перезапуск...................");
            Console.Clear();
            Main();
        }
        PrintLine("Данные успешно прочитаны", color: ConsoleColor.DarkGreen);
        Console.WriteLine();
        PrintLine("Исходный массив: ");
        Console.WriteLine();
        RenderArray(bOld);
        Console.WriteLine();
        PrintLine("Итоговый массив без четных столбцов: ");
        Console.WriteLine();
        RenderArray(b);
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
                PrintLine("\rВыход.............");
                Environment.Exit(0);
            }
            else
            {
                PrintLine("\rНе та кнопка!", color: ConsoleColor.Red);
            }
        }
    }
}