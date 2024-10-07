using MenuScreens;

namespace HW4;
using ClassLibrary;

class Program
{
    static void Main()
    {
        do
        {
            var colleges = new Colleges();
            var menu = new Menu(ref colleges);
            menu.AskForFilePath();
            Console.Clear();
            menu.ShowData();
            Console.Clear();
            menu.OperationsMenu();
            Console.Clear();
            menu.SaveDataMenu();
            Console.WriteLine("Нажмите Enter чтобы запустить программу еще раз, любую другую клавишу - чтобы выйти.");
        } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
    }
}

