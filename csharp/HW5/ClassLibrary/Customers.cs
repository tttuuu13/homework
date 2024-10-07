using System.Text;

namespace ClassLibrary;

/// <summary>
/// A class that represents an array of Customer type objects.
/// </summary>
public class Customers
{
    private Customer[] customers;

    public Customers()
    {
        this.customers = Array.Empty<Customer>();
    }
    public Customers(Customer[] customers)
    {
        this.customers = customers;
    }

    /// <summary>
    /// Filters an array of objects by key and value provided by user.
    /// </summary>
    /// <param name="fieldName">The name of the field to be filtered by.</param>
    /// <param name="value">The value of the field to be filtered by.</param>
    /// <exception cref="ArgumentException">Wrong value type.</exception>
    public void Filter(string? fieldName, string? value)
    {
        try
        {
            switch (fieldName)
            {
                case "customer_id":
                    customers = (from customer in customers where (customer.customer_id == int.Parse(value)) select customer).ToArray();
                    break;
                case "name":
                    customers = (from customer in customers where (customer.name == value) select customer).ToArray();
                    break;
                case "email":
                    customers = (from customer in customers where (customer.email == value) select customer).ToArray();
                    break;
                case "age":
                    customers = (from customer in customers where (customer.age == int.Parse(value)) select customer).ToArray();
                    break;
                case "city":
                    customers = (from customer in customers where (customer.city == value) select customer).ToArray();
                    break;
                case "is_premium":
                    customers = (from customer in customers where (customer.is_premium == bool.Parse(value)) select customer).ToArray();
                    break;
                case "orders":
                    customers = (from customer in customers where ($"[{string.Join(", ", customer.orders)}]" == value) select customer).ToArray();
                    break;
            }
        }
        catch (Exception e)
        {
            throw new ArgumentException("Неверный тип значения.");
        }
    }

    /// <summary>
    /// Sorts an array of objects by values of one given field.
    /// </summary>
    /// <param name="fieldName">The name of the field to be sorted by.</param>
    /// <exception cref="ArgumentException">For some reason, the sorting cannot be performed.</exception>
    public void Sort(string? fieldName)
    {
        try
        {
            switch (fieldName)
            {
                case "customer_id":
                    customers = (from customer in customers orderby customer.customer_id select customer).ToArray();
                    break;
                case "name":
                    customers = (from customer in customers orderby customer.name select customer).ToArray();
                    break;
                case "email":
                    customers = (from customer in customers orderby customer.email select customer).ToArray();
                    break;
                case "age":
                    customers = (from customer in customers orderby customer.age select customer).ToArray();
                    break;
                case "city":
                    customers = (from customer in customers orderby customer.city select customer).ToArray();
                    break;
                case "is_premium":
                    customers = (from customer in customers orderby customer.is_premium select customer).ToArray();
                    break;
                case "orders":
                    customers = (from customer in customers orderby customer.orders.Length select customer).ToArray();
                    break;
                
            }
        }
        catch (Exception e)
        {
            throw new ArgumentException("Произошла ошибка.");
        }
    }

    /// <summary>
    /// Return a string that represents an array of Customer type objects in JSON format.
    /// </summary>
    /// <returns>A string containing all representations of array objects in JSON format. Returns special message if array is empty.</returns>
    public override string ToString()
    {
        if (customers.Length == 0)
        {
            return "Нет данных.";
        }
        var sb = new StringBuilder();
        sb.Append("[\n");
        sb.Append(string.Join(",\n", from customer in customers select customer.ToString()));
        sb.Append("\n]");
        return sb.ToString();
    }
}