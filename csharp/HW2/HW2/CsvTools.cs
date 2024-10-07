namespace HW2;


internal class CsvTools
{
    // Оглавления, которые должны быть у файла подходящего формата.
    private static readonly string[] Headers =
    {
        @"""ID"";""StationStart"";""Line"";""TimeStart"";""StationEnd"";""TimeEnd"";""global_id"";",
        @"""Локальный идентификатор"";""Станция отправления"";""Направление Аэроэкспресс"";""Время отправления со станции"";" +
        @"""Конечная станция направления Аэроэкспресс"";""Время прибытия на конечную станцию направления Аэроэкспресс"";""global_id"";"
    };

    /// <summary>
    /// Возвращает абсолютный путь для сохранения по нему файла. Позволяет убедиться, что файл сохранен в нужном месте.
    /// </summary>
    /// <param name="fileName">Имя файла.</param>
    /// <returns>Абсолютный путь, по которому может быть сохранен файл.</returns>
    public static string FullPath(string fileName)
    {
        string currentPath = Directory.GetCurrentDirectory();
        if (currentPath.Contains("bin/Debug/net6.0"))
        {
            currentPath += $"/{fileName}";
        }
        else
        {
            currentPath += $"bin/Debug/net6.0/{fileName}";
        }
        return currentPath;
    }
    
    /// <summary>
    /// Создает файл.
    /// </summary>
    /// <param name="filePath">Путь по которому должен быть создан файл.</param>
    /// <exception cref="ArgumentNullException">Некорректный путь.</exception>
    private static void CreateFile(string filePath)
    {
        try
        {
            var file = File.Create(filePath);
            file.Close();
        }
        catch (ArgumentException)
        {
            throw new ArgumentNullException(null,
                "Путь содержит запрещенные символы либо является строкой нулевой длины.");
        }
        catch (PathTooLongException)
        {
            throw new ArgumentNullException(null,
                "Название слишком длинное");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ArgumentNullException(null,
                "Путь ведет в каталог.");
        }
        catch (Exception)
        {
            throw new ArgumentNullException(null,
                "Указан некорректный путь.");
        }
    }

    /// <summary>
    /// Проверка формата файла.
    /// </summary>
    /// <param name="rows">Массив строк CSV файла.</param>
    /// <exception cref="ArgumentException">Нет разделителя на конце строки.</exception>
    /// <exception cref="ArgumentNullException">Файл пустой.</exception>
    /// <exception cref="ArgumentNullException">Заголовок не соответствует формату.</exception>
    private static void CheckCsv(string[] rows)
    {
        if (rows.Length >= 1)
        {
            for (var i = 0; i < rows.Length; i++)
                if (!rows[i].EndsWith(';'))
                    throw new ArgumentNullException(null,
                        $"Нет разделителя на конце строки {i}");
            for (int i = 0; i < 2; i++)
            {
                if (rows[i] != Headers[i])
                {
                    throw new ArgumentNullException(null,
                        "Заголовок не соответсвует формату.");
                }
            }
        }
        else
        {
            throw new ArgumentNullException(null,
                "Файл пустой");
        }
    }

    /// <summary>
    /// Конвертация массива строк, в массив массивов.
    /// </summary>
    /// <param name="rows">Массив строк.</param>
    /// <returns>Массив массивов.</returns>
    public static string[][] ToTable(string[] rows)
    {
        var res = new string[rows.Length][];
        for (var i = 0; i < rows.Length; i++)
        {
            var items = Array.Empty<string>();
            foreach (var item in rows[i].Split(';')[..^1])
            {
                items = items.Append(item.Replace("\"", string.Empty)).ToArray();
            }
            res[i] = items;
        }
        return res;
    }

    /// <summary>
    /// Конвертация массива массивов в массив строк.
    /// </summary>
    /// <param name="table">Массив массивов.</param>
    /// <param name="sep">Разделитель.</param>
    /// <returns>Массив строк.</returns>
    public static string[] ToStrings(string[][] table, string sep = ";")
    {
        var res = new string[table.Length];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = String.Join(sep, table[i]) + sep;
        }
        return res;
    }

    /// <summary>
    /// Вывод массива строк на экран в красивом виде.
    /// </summary>
    /// <param name="rows">Массив строк.</param>
    public static void Render(string[] rows)
    {
        if (rows.Length == 0 || rows == null)
        {
            Console.WriteLine("Данных нет.");
            return;
        }
        string[] withHeaders = new string[1 + rows.Length];
        withHeaders[0] = Headers[0];
        for (int i = 1; i < withHeaders.Length; i++)
        {
            withHeaders[i] = rows[i - 1];
        }
        var table = ToTable(withHeaders);
        var maxWidths = new int[table[0].Length];
        for (int c = 0; c < maxWidths.Length; c++)
        {
            foreach (var row in table)
            {
                maxWidths[c] = Math.Max(maxWidths[c], row[c].Length);
            }
        }

        foreach (var row in table)
        {
            for (int i = 0; i < row.Length; i++)
            {
                Console.Write($"{row[i]}{new string(' ', maxWidths[i] - row[i].Length + 3)}");
            }
            Console.WriteLine();
        }

    }

    public static class CsvProcessing
    {
        public static string? fPath { get; set; }

        /// <summary>
        /// Читает файл по пути из поля fPath.
        /// </summary>
        /// <returns>Массив строк.</returns>
        public static string[] Read()
        {
            string[] rows;
            try
            {
                rows = File.ReadAllLines(fPath);
            }
            catch (ArgumentException)
            {
                throw new ArgumentNullException(null,
                    "Путь содержит запрещенные символы либо является строкой нулевой длины.");
            }
            catch (PathTooLongException)
            {
                throw new ArgumentNullException(null,
                    "Путь слишком длинный.");
            }
            catch (DirectoryNotFoundException)
            {
                throw new ArgumentNullException(null,
                    "Указан недопустимый путь.");
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentNullException(null,
                    "Файл не найден.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new ArgumentNullException(null,
                    "Путь ведет в каталог.");
            }
            catch (Exception)
            {
                throw new ArgumentNullException(null,
                    "Указан некорректный путь, либо файл не поддерживается.");
            }

            CheckCsv(rows);
            return rows;
        }

        /// <summary>
        /// Дозапись одной строки в конец файла.
        /// </summary>
        /// <param name="str">Строка.</param>
        /// <param name="nPath">Путь к файлу.</param>
        public static void Write(string str, string nPath)
        {
            if (!File.Exists(nPath)) CreateFile(nPath);
            var rows = Read().Append(str).ToArray();
            string[] withHeaders = new string[2 + rows.Length];
            Array.Copy(Headers, withHeaders, 2);
            Array.Copy(rows, 0, withHeaders, 2, rows.Length);
            File.WriteAllLines(nPath, withHeaders);
        }

        /// <summary>
        /// Запись массива строк в файл. Если файл уже существует - все данные перезаписываются.
        /// </summary>
        /// <param name="rows">Массив строк.</param>
        public static void Write(string[] rows)
        {
            if (!File.Exists(fPath)) CreateFile(fPath);
            string[] withHeaders = new string[2 + rows.Length];
            Array.Copy(Headers, withHeaders, 2);
            Array.Copy(rows, 0, withHeaders, 2, rows.Length);
            File.WriteAllLines(fPath, withHeaders);
        }
    }

    public static class DataProcessing
    {
        /// <summary>
        /// Фильтр строк по ключевым словам.
        /// </summary>
        /// <param name="rows">Массив строк.</param>
        /// <param name="columns">Индексы столбцов, по которым должна производиться выборка.</param>
        /// <param name="keywords">Ключевые слова по которым будет производиться выборка.</param>
        /// <returns>Отфильтрованный массив строк.</returns>
        public static string[][] Filter(string[][] rows, int[] columns, string[] keywords)
        {
            if (columns.Length != keywords.Length)
                throw new ArgumentException(paramName: null,
                    message: "Количество столбцов не соответствует количеству ключевых слов");
            if (columns.Length == 0 || columns == null || keywords == null)
                throw new ArgumentException(paramName: null,
                    message: "Передан пустой список");
            var rowsFiltered = Array.Empty<string[]>();
            foreach (var row in rows)
            {
                var flag = true;
                for (var i = 0; i < columns.Length; i++)
                    if (row[columns[i]] != keywords[i])
                        flag = false;
                if (flag) rowsFiltered = rowsFiltered.Append(row).ToArray();
            }
            return rowsFiltered;
        }

        /// <summary>
        /// Сортировка массива строк по возрастанию по столбцу, содержащему время.
        /// </summary>
        /// <param name="rows">Массив строк.</param>
        /// <param name="key">Столбец, по которому надо отсортировать массив. Допустимые значения: TimeStart, TimeEnd.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Ключевое слово некорректно.</exception>
        /// <exception cref="FormatException">Некорректные значения в столбце времени.</exception>
        public static string[][] SortByTime(string[] rows, string key)
        {
            var rowsSorted = ToTable(rows);
            var column = key switch
            {
                "TimeStart" => 3,
                "TimeEnd" => 5,
                _ => -1
            };
            if (column == -1)
                throw new ArgumentException(paramName: null,
                    message: "Передано некорректное ключевое слово");

            var res = new string[][] { };
            try
            {
                res = rowsSorted.OrderBy(row => DateTime.Parse(row[column])).ToArray();
            }
            catch (FormatException)
            {
                throw new FormatException("Некорректные значения в столбце времени.");
            }
            return res;
        }
    }
}