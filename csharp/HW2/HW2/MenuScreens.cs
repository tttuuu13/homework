namespace HW2;
using static CsvTools.DataProcessing;
using static CsvTools.CsvProcessing;
using static CsvTools;
using static Program;

public static class MenuScreens
{
    /// <summary>
    /// Главное меню.
    /// </summary>
    /// <param name="rows">Массив строк для обработки.</param>
    /// <param name="res">Массив для записи обработанных строк. Передается по ссылке.</param>
    public static void MainMenu(string[] rows, ref string[][] res)
    {
        var menu = new Menu(new[]
        {
            "Произвести выборку по станции отправления", "Произвести выборку по станции прибытия",
            "Произвести выборку по станции отправления и назначения", "Отсортировать таблицу по времени отправления",
            "Отсортировать таблицу по времени прибытия", "Выбрать другой файл", "Выйти из программы"
        });
        var op = menu.RenderMenu();
        if (op == 0)
        {
            Console.Write("Введите станцию отправления: ");
            do
            {
                string stationStart = Console.ReadLine();
                try
                {
                    res = Filter(ToTable(rows), new[] { 1 }, new[] { stationStart });
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Попробуйте еще раз: ");
                }
            } while (true);
            Console.WriteLine("Готово!");
        }
        else if (op == 1)
        {
            Console.Write("Введите станцию прибытия: ");
            do
            {
                var stationEnd = Console.ReadLine();
                try
                {
                    res = Filter(ToTable(rows), new[] { 4 }, new[] { stationEnd });
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Попробуйте еще раз: ");
                }
            } while (true);
        }
        else if (op == 2)
        {
            Console.WriteLine("Введите станцию отправления и прибытия в формате станция1-станция2: ");
            do
            {
                try
                {
                    var input = Console.ReadLine();
                    if (input.Split('-').Length != 2) throw new ArgumentException("Неверный формат ввода.");
                    var stationStart = input.Split('-')[0];
                    var stationEnd = input.Split('-')[1];
                    res = Filter(ToTable(rows), new[] { 1, 4 },
                        new[] { stationStart, stationEnd });
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Попробуйте еще раз: ");
                }
            } while (true);
        }
        else if (op == 3)
        {
            try
            {
                res = SortByTime(rows[2..], "TimeStart");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Попробуйте другой файл");
                Main();
            }
        }
        else if (op == 4)
        {
            try
            {
                res = SortByTime(rows[2..], "TimeEnd");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Попробуйте другой файл");
                Main();
            }
        }
        else if (op == 5)
        {
            Console.Clear();
            Main();
            Environment.Exit(0);
        }
        else if (op == 6)
        {
            Environment.Exit(0);
        }
        TableMenu(ref res);
    }

    /// <summary>
    /// Меню действий с обработанными данными.
    /// </summary>
    /// <param name="res">Массив обработанных данных.</param>
    static void TableMenu(ref string[][] res)
    {
        // Вернуться на шаг назад.
        static void GoBack(ref string[][] res)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("Вернуться назад (нажмите enter)");
            Console.ResetColor();
            var key = Console.ReadKey(false).Key;
            while (key != ConsoleKey.Enter) key = Console.ReadKey(false).Key;
            Console.Clear();
            TableMenu(ref res);
        }

        var menu = new Menu(new[]
        {
            "Вывести таблицу на экран",
            "Записать данные в файл",
            "Вернутся назад"
        });
        var op = menu.RenderMenu();
        if (op == 0)
        {
            Console.WriteLine("\n\n\n\n\n\nВот готовая таблица:");
            Render(ToStrings(res));
            GoBack(ref res);
        }
        else if (op == 1)
        {
            Console.Clear();
            if (res.Length == 0)
            {
                Console.WriteLine("Файл пустой, записывать нечего, попробуйте открыть другой.");
                GoBack(ref res);
                return;
            }
            Console.Write("Введите имя файла: ");
            do
            {
                var fileName = CsvTools.FullPath(Console.ReadLine());
                try
                {
                    if (res.Length == 1)
                    {
                        Write(ToStrings(res)[0], fileName);
                        break;
                    }
                    else
                    {
                        fPath = fileName;
                        Write(ToStrings(res));
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.Write($"{e.Message} Попробуйте другое имя: ");
                }
            } while (true);
            Console.WriteLine("Файл сохранен!");
            GoBack(ref res);
        }
        else if (op == 2)
        {
            MainMenu(ToStrings(res), ref res);
        }
    }
}