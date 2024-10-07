namespace HW2;
using static CsvTools.CsvProcessing;

internal class Program
{
    /// <summary>
    /// Проверяет, подходит ли размер окна для вывода данных в читаемом виде.
    /// </summary>
    /// <param name="resized"></param>
    static void CheckWindowSize()
    {
        if (Console.WindowHeight < 9 || Console.WindowWidth < 103)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                "Пожалуйста растяните окно до размеров равных хотя бы 103x9. Это нужно для корректного отображения данных");
            Console.ResetColor();
            while (Console.WindowHeight < 9 || Console.WindowWidth < 103) {}
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Спасибо!");
            Console.ResetColor();
        }
    }
    
    public static void Main()
    {
        CheckWindowSize();
        Console.Write("Введите полный путь до файла: ");
        var rows = Array.Empty<string>();
        do
        {
            fPath = Console.ReadLine();
            try
            {
                rows = Read();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.Write("Повторите попытку: ");
            }
        } while (rows == Array.Empty<string>());
        Console.WriteLine("Файл открыт!");
        Thread.Sleep(500);
        Console.Clear();
        var res = Array.Empty<string[]>();
        // Открываем главное меню.
        MenuScreens.MainMenu(rows, ref res);
    }
}