using Microsoft.VisualBasic;
using static ClassLibrary.Styling;

namespace ClassLibrary;

/// <summary>
/// Creates menus.
/// </summary>
public class Menu
{
    private string[] options;
    private string title;
    private int activeOption = 0;
    public Menu(string[] options, string title)
    {
        this.options = options;
        this.title = title;
    }

    /// <summary>
    /// Opens menu.
    /// </summary>
    /// <returns>Index of the chosen option.</returns>
    public int Open()
    {
        Console.Clear();
        while (true)
        {
            Render();
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow: activeOption = Math.Max(0, activeOption - 1);
                    break;
                case ConsoleKey.DownArrow: activeOption = Math.Min(options.Length-1, activeOption+1);
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    return activeOption;
            }
        }
    }

    /// <summary>
    /// Renders menu.
    /// </summary>
    public void Render()
    {
        Console.SetCursorPosition(0,0);
        Console.WriteLine(title);
        Console.WriteLine("Используйте стрелки для навигации, для выбора нажмите Enter.");
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine(i == activeOption ? Bold(Magenta(options[i])) : options[i]);
        }
    }
    
    /// <summary>
    /// Asks user to press Enter, doesn't proceed until Enter is pressed.
    /// </summary>
    public void PressToContinue()
    {
        Console.WriteLine(Magenta("Нажмите Enter, чтобы вернуться назад."));
        var key = Console.ReadKey(true).Key;
        while (key != ConsoleKey.Enter)
        {
            key = Console.ReadKey(true).Key;
        }
    }
}