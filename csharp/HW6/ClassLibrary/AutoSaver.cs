namespace ClassLibrary;

/// <summary>
/// AutoSaver class
/// </summary>
public class AutoSaver
{
    private DateTime lastTimeChanged;
    private string tempName;
    private Hero[] data;
    
    public AutoSaver(Hero[] heroes, string tempName)
    {
        foreach (var hero in heroes)
        {
            hero.Updated += AutoSave;
        }

        data = heroes;
        this.tempName = tempName;
        lastTimeChanged = DateTime.Now;
    }

    /// <summary>
    /// Saves the data in its current state to the temporary file if the last change is not older than 15 seconds.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="args">Arguments passed.</param>
    public void AutoSave(object? sender, UpdatedEventArgs args)
    {
        if (args.TimeChanged - lastTimeChanged <= TimeSpan.FromSeconds(15)
            && args.TimeChanged - lastTimeChanged > TimeSpan.FromMilliseconds(100))
        {
            Files.Write(tempName, data.ToJson());
            Console.WriteLine(Styling.Green($"[изменения сохранены в {tempName}]"));
        }

        lastTimeChanged = args.TimeChanged;
    }
}