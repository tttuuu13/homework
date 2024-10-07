namespace ClassLibrary;

/// <summary>
/// Contains methods that provide the application with a UI.
/// </summary>
public class Menu
{
    private string[] options;
    public Menu(string[] options)
    {
        this.options = options;
    }

    /// <summary>
    /// Displays the menu in the console and collects user input.
    /// </summary>
    /// <returns>The index of the option that the user has selected.</returns>
    public int Open()
    {
        Console.WriteLine("Нажимайте кнопки для выбора");
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i+1}. {options[i]}");
        }
        var key = Console.ReadKey(true).Key.ToString();
        int r;
        while (!(int.TryParse(key[1..], out r) && 0 < r && r <= options.Length))
        {
            Console.WriteLine($"[X] Нажмите кноку из диапазона [1-{options.Length}].");
            key = Console.ReadKey(true).Key.ToString();
        }
        Console.Clear();
        return r;
    }

    /// <summary>
    /// Displays a message that asks user to press Enter.
    /// </summary>
    public void PressToContinue()
    {
        Console.WriteLine("Нажмите Enter, чтобы вернуться назад.");
        var key = Console.ReadKey(true).Key;
        while (key != ConsoleKey.Enter)
        {
            key = Console.ReadKey(true).Key;
        }
    }
}