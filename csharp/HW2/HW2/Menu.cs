namespace HW2;


public class Menu
{
    public string[] items;

    private int selectedIndex;

    public Menu(string[] itemsList)
    {
        items = itemsList;
    }
    
    /// <summary>
    /// Уменьшить индекс выбранного элемента на 1.
    /// </summary>
    private void MoveUp()
    {
        selectedIndex = Math.Max(0, selectedIndex - 1);
    }

    /// <summary>
    /// Увеличить индекс выбранного элемента на 1.
    /// </summary>
    private void MoveDown()
    {
        selectedIndex = Math.Min(items.Length - 1, selectedIndex + 1);
    }

    /// <summary>
    /// Отображает меню.
    /// </summary>
    /// <returns>Индекс выбранного элемента</returns>
    public int RenderMenu()
    {
        Console.Clear();
        Console.WriteLine("Для навигации используйте стрелки на клавиатуре, для выбора нажмите Enter:");
        var done = false;
        do
        {
            for (var i = 0; i < items.Length; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                if (selectedIndex == i)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.Write(items[i]);
                Console.ResetColor();
            }

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.Enter:
                    done = true;
                    break;
            }
        } while (!done);
        return selectedIndex;
    }
}