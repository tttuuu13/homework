using System.Text;
namespace HW3;

public class Library
{
    /// <summary>
    /// Получени пути для файла, необходимо так как относительные пути могут отличаться, в зависимости от того, каким образом запускается программа.
    /// </summary>
    /// <param name="fileName">Имя файла.</param>
    /// <returns>Полный путь до файла.</returns>
    private static string GetPath(string fileName)
    {
        string currentPath = Directory.GetCurrentDirectory();
        string sep = Path.DirectorySeparatorChar.ToString();
        if (currentPath.Contains($"bin{sep}Debug{sep}net6.0"))
        {
            currentPath += $"{sep}{fileName}";
        }
        else
        {
            currentPath += $"{sep}bin{sep}Debug{sep}net6.0{sep}{fileName}";
        }
        
        return currentPath;
    }
    
    /// <summary>
    /// Конвертирует строку в массив строк, разбивая по разделителю и подчищая элементы от лишних пробелов.
    /// </summary>
    /// <param name="data">Входные данные.</param>
    /// <returns>Массив строк.</returns>
    /// <exception cref="ArgumentNullException">Передан пустой набор данных, либо имеется несоответствие требуемому формату.</exception>
    private static string[] ToRows(string data)
    {
        var rows = data.Split(';');
        if (String.IsNullOrEmpty(data) || rows.Length < 2)
        {
            throw new ArgumentNullException(null, 
                "Файл пустой, либо не соответствует формату.");
        }

        var rowsProcessed = new string[] { };
        foreach (var row in rows)
        {
            rowsProcessed = rowsProcessed.Append(row.Trim()).ToArray();
        }
        return rowsProcessed[..^1];
    }
    
    /// <summary>
    /// Открывает файл и читает из него все данные.
    /// </summary>
    /// <param name="fileName">Имя файла</param>
    /// <returns>Данные из файла в виде одной строки.</returns>
    /// <exception cref="ArgumentNullException">Путь содержит запрещенные символы либо является строкой нулевой длины.</exception>
    /// <exception cref="PathTooLongException">Путь слишком длинный.</exception>
    /// <exception cref="DirectoryNotFoundException">Указан недопустимый путь.</exception>
    /// <exception cref="FileNotFoundException">Файл не найден.</exception>
    /// <exception cref="UnauthorizedAccessException">Путь ведет в каталог.</exception>
    /// <exception cref="Exception">Указан некорректный путь, либо файл не поддерживается.</exception>
    public static string Read(string fileName)
    {
        string data;
        try
        {
            data = File.ReadAllText(GetPath(fileName));
        }
        catch (ArgumentException)
        {
            throw new ArgumentNullException(null,
                "Путь содержит запрещенные символы либо является строкой нулевой длины.");
        }
        catch (PathTooLongException)
        {
            throw new PathTooLongException("Путь слишком длинный.");
        }
        catch (DirectoryNotFoundException)
        {
            throw new DirectoryNotFoundException("Указан недопустимый путь.");
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException("Файл не найден.");
        }
        catch (UnauthorizedAccessException)
        {
            throw new UnauthorizedAccessException("Путь ведет в каталог.");
        }
        catch (Exception)
        {
            throw new Exception("Указан некорректный путь, либо файл не поддерживается.");
        }

        return data;
    }

    /// <summary>
    /// Создает файл и засписывает в него данные. Если файл уже существует - данные перезаписываются.
    /// </summary>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="data">Данные для записи в файл.</param>
    /// <exception cref="ArgumentNullException">Путь содержит запрещенные символы либо является строкой нулевой длины.</exception>
    /// <exception cref="PathTooLongException">Путь слишком длинный.</exception>
    /// <exception cref="DirectoryNotFoundException">Указан недопустимый путь.</exception>
    /// <exception cref="FileNotFoundException">Файл не найден.</exception>
    /// <exception cref="UnauthorizedAccessException">Путь ведет в каталог.</exception>
    /// <exception cref="Exception">Указан некорректный путь, либо файл не поддерживается.</exception>
    public static void Write(string fileName, string data)
    {
        try
        {
            File.WriteAllText(GetPath(fileName), data);
        }
        catch (ArgumentException)
        {
            throw new ArgumentNullException(null,
                "Путь содержит запрещенные символы либо является строкой нулевой длины.");
        }
        catch (PathTooLongException)
        {
            throw new PathTooLongException("Путь слишком длинный.");
        }
        catch (DirectoryNotFoundException)
        {
            throw new DirectoryNotFoundException("Указан недопустимый путь.");
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException("Файл не найден.");
        }
        catch (UnauthorizedAccessException)
        {
            throw new UnauthorizedAccessException("Путь ведет в каталог.");
        }
        catch (Exception)
        {
            throw new Exception("Указан некорректный путь, либо файл не поддерживается.");
        }
    }
    
    
    
    public class MyDate
    {
        private DateTime[] _dates;
        private String[] _events;
        
        public DateTime[] Dates => _dates;
        public String[] Events => _events;

        /// <summary>
        /// Конвертирует строку в DateTime, задает максимально возможное значение далеко в будущее, если строка не соответствует формату.
        /// </summary>
        /// <param name="str">Строка.</param>
        /// <returns>Объект типа DateTime.</returns>
        private static DateTime ToDate(string? str)
        {
            if (DateTime.TryParseExact(str, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }

            return DateTime.MaxValue;
        }

        /// <summary>
        /// Проверяет строку на соответствие формату (не пустая, длина не более 70 символов, только латинские буквы и пробелы).
        /// </summary>
        /// <param name="str">Строка.</param>
        /// <returns>Ту же строку, при соответствии требованиям, N/A - если требования нарушены.</returns>
        private static string ToEvent(string? str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length <= 70)
            {
                foreach (var c in str)
                {
                    if (!(c >= 'A' && c <= 'z' || c == ' '))
                    {
                        return "N/A";
                    }
                }

                return str;
            }

            return "N/A";
        }
        
        public MyDate(string? str)
        {
            var rows = ToRows(str);
            _dates = new DateTime[rows.Length];
            _events = new String[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                var items = rows[i].Split(':');
                if (items.Length == 2)
                {
                    _dates[i] = ToDate(items[0]);
                    _events[i] = ToEvent(items[1]);
                }
                else
                {
                    _dates[i] = DateTime.MaxValue;
                    _events[i] = "N/A";
                }
            }
        }

        /// <summary>
        /// Сортировка данных по дате. Изменяет уже существующие данные в полях класса.
        /// </summary>
        public void SortByDate()
        {
            var rows = new string[_dates.Length][];
            for (int i = 0; i < _dates.Length; i++)
                rows[i] = new[] { _dates[i].ToString(), _events[i] };
            rows = rows.OrderBy(row => DateTime.Parse(row[0])).ToArray();
            for (int i = 0; i < _dates.Length; i++)
            {
                _dates[i] = DateTime.Parse(rows[i][0]);
                _events[i] = rows[i][1];
            }
        }

        /// <summary>
        /// Перезапись метода для преобразования в строку.
        /// </summary>
        /// <returns>Таблицу данных в виде одной строки.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _dates.Length; i++)
            {
                // Собираем строку из двух массивов, если дата равна максимально возможной, то записываем ее как N/A.
                sb.Append($"{(_dates[i].Date == DateTime.MaxValue.Date ? "    N/A    " : " " + _dates[i].ToString("yyyy-MM-dd"))}" +
                          $"  {_events[i]}\n");
            }
            return sb.ToString();
        }
    }
}