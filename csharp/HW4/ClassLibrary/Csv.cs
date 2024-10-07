using System.Text;

namespace ClassLibrary;

public class Csv
{
    private string[][] _data;
    // Тут хранятся заголовки.
    public string[] Headers { get; }
    public string[][] Data => _data;
    
    /// <summary>
    /// Конструктор класса, открывает файл и обрабатывает данные.
    /// </summary>
    /// <param name="filePath"></param>
    /// <exception cref="FormatException"></exception>
    public Csv(string filePath)
    {
        Headers = CsvFile.Read(filePath)[0].Split(";");
        var rows = CsvFile.Read(filePath)[1..];
        int len = rows.Length;
        if (len == 0)
        {
            // Неверный формат => формат эксепшн. вроде логично
            throw new FormatException("Файл пустой");
        }
        var r = new string[len][];
        for (int i = 0; i < len; i++)
        {
            if (rows[i][^1] != ';')
            {
                // Неверный формат => формат эксепшн. вроде логично
                throw new FormatException($"Нет знака разделителя на конце строки {i}");
            }
            r[i] = new string[] { };
            try
            {
                foreach (var item in 
                         rows[i].Replace(
                             "\"\";\"", "||").Replace("\";\"\"", "||").Replace(
                             "\";\"","||").Replace(";\"", "||").Replace(
                             "\";", "||").Split("||")[..^1])
                {
                    r[i] = r[i].Append(item != "" ? item.Replace("\"\"", "\"") : "нет данных").ToArray();
                }
            }
            catch
            {
                // Неверный формат => формат эксепшн. вроде логично
                throw new FormatException("Неверный формат файла");
            }
        }
        
        _data = r;
    }
}