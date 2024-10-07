namespace HW3;
using static Library;

class Program
{
    static void Main()
    {
        do
        {
            Console.Clear();
            Console.Write("Введите имя файла: ");
            string? fileName = Console.ReadLine();
            string data;
            MyDate md;
            do
            {
                try
                {
                    data = Read(fileName);
                    // Создаем массив объектов типа MyDate, как требуется из задания. Зачем он нужен?...
                    var uselessArray = new MyDate[] { };
                    md = new MyDate(data);
                    md.SortByDate();
                    break;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[X] Ошибка: {e.Message}");
                    Console.ResetColor();
                    Console.Write("\nПопробуйте еще раз: ");
                    fileName = Console.ReadLine();
                }
            } while (true);

            Console.Write("Файл успешно открыт и обработан. Введите имя для сохранения: ");
            fileName = Console.ReadLine();
            do
            {
                try
                {
                    Write(fileName, $"Исходные данные:\n{data}\n\nОбработанная таблциа:\n Дата\t     Событие\n{md}");
                    break;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[X] Ошибка: {e.Message}");
                    Console.ResetColor();
                    Console.Write("\nПопробуйте еще раз: ");
                    fileName = Console.ReadLine();
                }
            } while (true);

            Console.WriteLine("Файл сохранен! Нажмите Enter, чтобы обработать другой.");
        } while (Console.ReadKey(false).Key == ConsoleKey.Enter);
    }
}