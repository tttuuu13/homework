namespace ClassLibrary;

/// <summary>
/// Styling.
/// </summary>
public static class Styling
{
    public static string Magenta(string str)
    {
        return $"\u001b[35;1m{str}\u001b[0m";
    }

    public static string Red(string str)
    {
        return $"\u001b[31;1m{str}\u001b[0m";
    }

    public static string Green(string str)
    {
        return $"\u001b[32m{str}\u001b[0m";
    }

    public static string Bold(string str)
    {
        return $"\u001b[1m{str}\u001b[0m";
    }
}