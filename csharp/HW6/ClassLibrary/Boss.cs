using System.Text.Json;
using System.Text.Json.Serialization;
// ReSharper disable InconsistentNaming
namespace ClassLibrary;

public enum BossFields
{
    boss_id,
    boss_name,
    experience,
    current_location
}

/// <summary>
/// Represents a boss object from the JSON file.
/// </summary>
public class Boss
{
    public string boss_id { get; }
    public string boss_name { get; private set; }
    public int experience { get; private set; }
    public string current_location { get; private set; }
    
    [JsonConstructor]
    public Boss(string boss_id, string boss_name, int experience, string current_location)
    {
        this.boss_id = boss_id;
        this.boss_name = boss_name;
        this.experience = experience;
        this.current_location = current_location;
    }

    /// <summary>
    /// Method to update read-only fields.
    /// </summary>
    /// <param name="field">The field that needs to be updated.</param>
    /// <param name="value">New value.</param>
    /// <exception cref="ArgumentException">Field doesn't exist or cannot be changed.</exception>
    public void Update(BossFields field, object value)
    {
        switch (field)
        {
            case BossFields.boss_name: boss_name = (string)value;
                break;
            case BossFields.current_location: current_location = (string)value;
                break;
            case BossFields.experience: experience = (int)value;
                break;
            default: throw new ArgumentException("Поле не существует, либо не может быть изменено.");
        }
    }
    
    /// <summary>
    /// This is obvious.
    /// </summary>
    /// <returns>A string.</returns>
    public override string ToString()
    {
        return $"ID: {boss_id} Name: {boss_name} EXP: {experience} Location: {current_location}";
    }

    /// <summary>
    /// JSON representation of an object.
    /// </summary>
    /// <returns>JSON-like string.</returns>
    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}