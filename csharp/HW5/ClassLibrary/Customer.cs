using System.Text;

namespace ClassLibrary;

/// <summary>
/// Represents an object contained in an array from given JSON file.
/// </summary>
public class Customer
{
    public int customer_id { get; }
    public string name { get; }
    public string email { get; }
    public int age { get; }
    public string city { get; }
    public bool is_premium { get; }
    public string[] orders { get; }
    public Customer(object[] args)
    {
        try
        {
            customer_id = (int)args[0];
        }
        catch (InvalidCastException)
        {
            throw new ArgumentException($"Неверное значение для поля \"customer_id\": {args[0]}");
        }
        try
        {
            name = (string)args[1];
        }
        catch (InvalidCastException)
        {
            throw new ArgumentException($"Неверное значение для поля \"name\": {args[1]}");
        }
        try
        {
            email = (string)args[2];
        }
        catch (InvalidCastException)
        {
            throw new ArgumentException($"Неверное значение для поля \"email\": {args[2]}");
        }
        try
        {
            age = (int)args[3];
        }
        catch (InvalidCastException)
        {
            throw new ArgumentException($"Неверное значение для поля \"age\": {args[3]}");
        }
        try
        {
            city = (string)args[4];
        }
        catch (InvalidCastException)
        {
            throw new ArgumentException($"Неверное значение для поля \"city\": {args[4]}");
        }
        try
        {
            is_premium = (bool)args[5];
        }
        catch (InvalidCastException)
        {
            throw new ArgumentException($"Неверное значение для поля \"is_premium\": {args[5]}");
        }
        try
        {
            orders = (string[])args[6];
        }
        catch (InvalidCastException)
        {
            throw new ArgumentException($"Неверное значение для поля \"orders\": {args[6]}");
        }
    }

    /// <summary>
    /// Returns a string that represents Customer object as JSON.
    /// </summary>
    /// <returns>A string containing all of the object's fields and its values.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("  {\n");
        sb.Append($"    \"customer_id\": {customer_id},\n");
        sb.Append($"    \"name\": {name},\n");
        sb.Append($"    \"email\": {email},\n");
        sb.Append($"    \"age\": {age},\n");
        sb.Append($"    \"city\": {city},\n");
        sb.Append($"    \"is_premium\": {is_premium},\n");
        sb.Append($"    \"orders\": [\n      ");
        sb.Append(string.Join(",\n      ", from order in orders select $"\"{order}\""));
        sb.Append($"\n    ]\n");
        sb.Append("  }");
        return sb.ToString();
    }
}