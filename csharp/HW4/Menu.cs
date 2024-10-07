namespace MenuScreens;
using ClassLibrary;


/// <summary>
/// Класс меню, тут экраны меню реализованы в виде методов.
/// </summary>
class Menu
{
    private Colleges _colleges;
    
    public Menu(ref Colleges colleges)
    {
        _colleges = colleges;
    }
    /// <summary>
    /// Экран на котором от пользователя запрашивается путь до файла, который потом открывается.
    /// </summary>
    public void AskForFilePath()
    {
        do
        {
            Console.Write("Введите путь до файла: ");
            string? filePath = Console.ReadLine();
            Csv csv;
            try
            {
                csv = new Csv(filePath);
                _colleges.Headers = csv.Headers;
                foreach (var info in csv.Data)
                {
                    _colleges.Add(new ClassLibrary.Сollege(info));
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[X] Произошла ошибка: {e.Message} Попробуйте еще раз.");
            }
        } while (true);
    }

    /// <summary>
    /// На этом экране пользователю показываются данные, прочитанные из файла.
    /// </summary>
    public void ShowData()
    {
        ConsoleKey key;
        Console.WriteLine("Сделайте выбор, нажав соответствующие цифры на клавиатуре:");
        Console.WriteLine("1. Показать первые n строк.");
        Console.WriteLine("2. Показать последние n строк.");
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.D1 && key != ConsoleKey.D2);

        Colleges.SelectRowsToPrint start = Colleges.SelectRowsToPrint.Top;
        switch (key)
        {
            case ConsoleKey.D1: start = Colleges.SelectRowsToPrint.Top;
                break;
            case ConsoleKey.D2: start = Colleges.SelectRowsToPrint.Bottom;
                break;
        }
        
        do
        {
            Console.Clear();
            Console.Write($"Введите число - количество строк {(start == Colleges.SelectRowsToPrint.Top ? "сверху" : "снизу")} которые будут выведены на экран: ");
            if (!int.TryParse(Console.ReadLine(), out var n) || n < 0)
            {
                Console.WriteLine("Введите неотрицательное целое число");
                Thread.Sleep(1000);
                continue;
            }

            if (n > _colleges.colleges.Length)
            {
                Console.WriteLine("Число больше количества строк в файле. Введите другое.");
                Thread.Sleep(1000);
                continue;
            }

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nВот {(start == Colleges.SelectRowsToPrint.Top ? "первые" : "последние")} {n} строк файла:");
                Console.ResetColor();
                Console.WriteLine(_colleges.ToString(start, n));
            }
            catch (Exception e)
            {
                Console.WriteLine($"[X] Произошла ошибка: {e.Message}");
                continue;
            }
            break;
        } while (true);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Нажмите Enter, чтобы выйти из режима просмотра.");
        Console.ResetColor();
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.Enter);
    }

    /// <summary>
    /// На этом экране пользователь может выбрать: какую операцию произвести над данными.
    /// </summary>
    public void OperationsMenu()
    {
        ConsoleKey key;
        Console.WriteLine("Выберите, что вы хотите сделать с файлом:");
        Console.WriteLine("1. Отсортировать по району в алфавитном порядке.");
        Console.WriteLine("2. Отсортировать по району в обратном алфавитном порядке.");
        Console.WriteLine("3. Отфильтровать по значению form_of_incorporation.");
        Console.WriteLine("4. Отфильтровать по значению submission.");
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 && key != ConsoleKey.D4);

        if (key == ConsoleKey.D1)
        {
            _colleges.SortByRayon();
        }
        else if (key == ConsoleKey.D2)
        {
            _colleges.SortByRayon(true);
        }
        else
        {
            Console.Write("Введите значение для применения фильтра: ");
            string? value = Console.ReadLine();
            _colleges.Filter((key == ConsoleKey.D3 ? "form_of_incorporation" : "submission"), value);
        }
        Console.WriteLine("Данные успешно обработаны!");
        ShowData();
    }

    /// <summary>
    /// На этом экране пользователь выбирает как и куда сохранить обработанные данные.
    /// </summary>
    public void SaveDataMenu()
    {
        ConsoleKey key;
        Console.WriteLine("Выберите, как сохранить файл:");
        Console.WriteLine("1. Создать новый файл.");
        Console.WriteLine("2. Заменить существующий.");
        Console.WriteLine("3. Добавить к содержимому существующего файла.");
        
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3);

        do
        {
            Console.Write("Введите путь для сохранения файла: ");
            string? filePath = Console.ReadLine();
            try
            {
                if (key == ConsoleKey.D1)
                {
                    ClassLibrary.CsvFile.SaveNew(filePath, _colleges.ToString());
                }
                else if (key == ConsoleKey.D2)
                {
                    ClassLibrary.CsvFile.SaveReplace(filePath, _colleges.ToString());
                }
                else
                {
                    ClassLibrary.CsvFile.SaveAppend(filePath, _colleges.ToString());
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[X] Произошла ошибка: {e.Message}");
            }
        } while (true);
        Console.WriteLine("Файл успешно сохранен!");
    }
}