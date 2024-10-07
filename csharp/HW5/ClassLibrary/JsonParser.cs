using System.Text;

namespace ClassLibrary;

/// <summary>
/// Class that contains methods to parse JSON type files.
/// </summary>
public static class JsonParser
{
    private enum State
    {
        Main,
        Objects,
        Object,
        Value,
        Array
    }

    /// <summary>
    /// Convert string to either int or bool, or leaves it as is.
    /// </summary>
    /// <param name="s">String to convert.</param>
    /// <returns>An object.</returns>
    private static object ParseString(string? s)
    {
        if (int.TryParse(s, out int n))
        {
            return n;
        }
        if (bool.TryParse(s, out bool b))
        {
            return b;
        }

        return s;
    }

    /// <summary>
    /// Removes unnecessary quotes and commas.
    /// </summary>
    /// <param name="s">String to clean up.</param>
    /// <returns>Cleaned up string.</returns>
    private static string CleanUp(string s) => s.Replace("\"", "").Replace(",", "").Trim();
    
    /// <summary>
    /// Parses the JSON contents into array of Customer type objects.
    /// </summary>
    /// <param name="json">String in JSON format.</param>
    /// <returns>Array of Customer type objects.</returns>
    public static Customer[] Parse(string json)
    {
        var customers = Array.Empty<Customer>();
        json = json.Replace("\n", "");
        var state = State.Main;
        var values = Array.Empty<object>();
        var s = new StringBuilder();
        foreach (var c in json)
        {
            switch(state)
            {
                case State.Main when c == '[':
                    state = State.Objects;
                    break;
                case State.Objects when c == ']':
                    state = State.Main;
                    break;
                case State.Objects when c == '{':
                    state = State.Object;
                    break;
                case State.Object when c == '}':
                    customers = customers.Append(new Customer(values)).ToArray();
                    values = Array.Empty<object>();
                    state = State.Objects;
                    break;
                case State.Object when c ==':':
                    state = State.Value;
                    break;
                case State.Value when c == ',':
                    state = State.Object;
                    values = values.Append(ParseString(CleanUp(s.ToString()))).ToArray();
                    s = new StringBuilder();
                    break;
                case State.Value when c == '[':
                    state = State.Array;
                    break;
                case State.Value:
                    s.Append(c);
                    break;
                case State.Array when c == ']':
                    values = values.Append(s.ToString().Split(',').Select(x => CleanUp(x)).ToArray()).ToArray();
                    s = new StringBuilder();
                    state = State.Object;
                    break;
                case State.Array:
                    s.Append(c);
                    break;
            }
        }
        return customers;
    }
}