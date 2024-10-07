using System.Text.Json;

namespace ClassLibrary;

/// <summary>
/// Represent JSON file.
/// </summary>
public class Json
{
    private string data;
    public Json(string? filePath)
    {
        data = Files.Read(filePath);
    }

    /// <summary>
    /// Parses JSON into array of objects.
    /// </summary>
    /// <returns></returns>
    public Hero[] Parse()
    {
        Hero[] heroes;
        try
        {
            heroes = JsonSerializer.Deserialize<Hero[]>(data) ?? throw new ArgumentException("Файл пуст.");
        }
        catch (Exception e)
        {
            throw new ArgumentException("Некорректный тип файла.");
        }
        return heroes;
    }
}