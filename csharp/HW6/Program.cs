namespace HW6;
using ClassLibrary;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Введите путь до файла: ");
            string? filePath = Console.ReadLine();
            Json json;
            Hero[] heroes;
            while (true)
            {
                try
                {
                    json = new Json(filePath);
                    heroes = json.Parse();
                    Console.WriteLine(Styling.Green("Файл открыт!"));
                    Thread.Sleep(1000);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write($"{Styling.Red($"[X]{e.Message}")} Попробуйте еще раз: ");
                    filePath = Console.ReadLine();
                }
            }

            string tempName = $"{Path.GetFileNameWithoutExtension(filePath)}_tmp.json";
            AutoSaver autoSaver = new AutoSaver(heroes, tempName);
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Menu mainMenu = new Menu(new[]
                {
                    "Отсортировать по одному из полей.",
                    "Выбрать объект для редактирования.",
                    "Вывести данные в консоль.",
                    "Выбрать другой файл",
                    "Выйти"
                }, "Главное меню");
                switch (mainMenu.Open())
                {
                    case 0:
                        MenuScreens.SortingMenu(ref heroes);
                        Console.WriteLine(Styling.Green("Готово!"));
                        break;
                    case 1:
                        MenuScreens.EditingMenu(ref heroes);
                        Console.WriteLine(Styling.Green("Готово!"));
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(Styling.Magenta("Ваши данные:"));
                        heroes.Render();
                        break;
                    case 3:
                        exit = true;
                        break;
                    case 4:
                        Console.WriteLine("Завершение работы...");
                        Thread.Sleep(500);
                        Environment.Exit(0);
                        break;
                }

                if (!exit) mainMenu.PressToContinue();
            }
        }
    }
}