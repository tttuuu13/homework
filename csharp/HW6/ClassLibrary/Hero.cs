using System.Text.Json;
using System.Text.Json.Serialization;
using static ClassLibrary.Styling;

// ReSharper disable InconsistentNaming
namespace ClassLibrary;

public enum HeroFields
{
    hero_id,
    hero_name,
    faction,
    level,
    bosses_slayed
}

/// <summary>
/// Represents Hero object from the JSON file.
/// </summary>
public class Hero
{
    public string hero_id { get; }
    public string hero_name { get; private set; }
    public string faction { get; private set; }
    public double level { get; private set; }
    public Boss[] bosses_slayed { get; }
    
    [JsonConstructor]
    public Hero(string hero_id, string hero_name, string faction, double level, Boss[] bosses_slayed)
    {
        this.hero_id = hero_id;
        this.hero_name = hero_name;
        this.faction = faction;
        this.level = level;
        this.bosses_slayed = bosses_slayed;
    }

    /// <summary>
    /// Updates some of fields.
    /// </summary>
    /// <param name="field">Field to update.</param>
    /// <param name="newValue">A new value.</param>
    public void Update(HeroFields field, object newValue)
    {
        switch (field)
        {
            case HeroFields.hero_name:
                hero_name = (string)newValue;
                break;
            case HeroFields.faction:
                faction = (string)newValue;
                break;
            case HeroFields.level:
                level = (double)newValue;
                break;
        }
        OnUpdated();
    }

    /// <summary>
    /// Raises an Updated event when called.
    /// </summary>
    protected virtual void OnUpdated()
    {
        UpdatedEventArgs args = new UpdatedEventArgs(DateTime.Now);
        Updated?.Invoke(this, args);
    }
    
    public event EventHandler<UpdatedEventArgs> Updated;

    /// <summary>
    /// Represents an object as a string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"ID: {hero_id} Name: {hero_name} LVL: {level} " +
               $"Faction: {faction} Bosses slayed: {bosses_slayed.Length}";
    }

    /// <summary>
    /// Represents an object as a JSON-like string.
    /// </summary>
    /// <returns></returns>
    public string ToJson() => JsonSerializer.Serialize(this);
}