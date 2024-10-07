using System.Text;
using ClassLibrary;

class Program
{
    static void Main()
    {
        while (true)
        {
            var fileMenu = new Menu(new[] { "Прочитать из консоли.", "Прочитать из файла." });
            var customers = new Customers();
            switch (fileMenu.Open())
            {
                case 1:
                    do
                    {
                        var json = new StringBuilder();
                        string? line;
                        Console.WriteLine("Введите данные (для завершения ввода нажмите CTRL-D):");
                        while ((line = Console.ReadLine()) != null)
                        {
                            json.Append(line);
                        }

                        try
                        {
                            customers = new Customers(JsonParser.Parse(json.ToString()));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"[X] Ошибка! {e.Message}");
                            Console.WriteLine("Повторите ввод:");
                        }
                    } while (true);

                    break;
                case 2:
                    Console.Write("Введите путь до файла: ");
                    string? filePath = Console.ReadLine();
                    do
                    {
                        try
                        {
                            customers = new Customers(JsonParser.Parse(Files.Read(filePath)));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"[X] Ошибка! {e.Message}");
                            Console.Write("Попробуйте еще раз: ");
                            filePath = Console.ReadLine();
                        }
                    } while (true);

                    break;
            }
            Console.Clear();
            Console.WriteLine("Данные прочитаны! Выберите, что хотите сделать:");
            var mainMenu = new Menu(new[]
            {
                "Отфильтровать по одному из полей.", "Отсортировать по одному из полей.", "Вывести данные в консоль.",
                "Записать данные в файл.", "Ввести другие данные", "Выйти."
            });
            var fields = new[] { "customer_id", "name", "email", "age", "city", "is_premium", "orders" };
            bool stop = false;
            while (!stop)
            {
                switch (mainMenu.Open())
                {
                    case 1:
                        Console.Write("Введите название поля: ");
                        string? fieldName = Console.ReadLine();
                        while (!(fields.Contains(fieldName)))
                        {
                            Console.Write("Такого поля нет, попробуйте еще раз: ");
                            fieldName = Console.ReadLine();
                        }

                        Console.Write("Введите желаемое значение для поля: ");
                        string? value = Console.ReadLine();
                        while (true)
                        {
                            try
                            {
                                customers.Filter(fieldName, value);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.Write($"[X] {e.Message} Попробуйте другое: ");
                                value = Console.ReadLine();
                            }
                        }
                        Console.WriteLine("Готово! Возврат в меню...");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                    case 2: 
                        Console.Write("Введите название поля: ");
                        fieldName = Console.ReadLine();
                        while (!(fields.Contains(fieldName)))
                        {
                            Console.Write("Такого поля нет, попробуйте еще раз: ");
                            fieldName = Console.ReadLine();
                        }
                        
                        try
                        {
                            customers.Sort(fieldName);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"[X] {e.Message}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\n\n\nВот данные:");
                        Console.WriteLine(customers);
                        mainMenu.PressToContinue();
                        break;
                    case 4: 
                        Console.Write("Введите путь до файла: ");
                        string? filePath = Console.ReadLine();
                        while (true)
                        {
                            try
                            {
                                Files.Write(filePath, customers.ToString());
                                Console.WriteLine("Успешно! Возврат в меню...");
                                Thread.Sleep(500);
                                Console.Clear();
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"[X] {e.Message} Попробуйте еще раз: ");
                                filePath = Console.ReadLine();
                            }
                        }
                        break;
                    case 5:
                        stop = true;
                        break;
                    case 6:
                        Console.WriteLine("Завершение работы...");
                        Thread.Sleep(500);
                        Environment.Exit(0);
                        break;
                }
                Console.Clear();
            }
        }
    }
}