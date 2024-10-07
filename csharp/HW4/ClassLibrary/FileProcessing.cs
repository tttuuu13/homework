namespace ClassLibrary;

public static class CsvFile
{
    /// <summary>
    /// Открывает и читает файл.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="UnauthorizedAccessException"></exception>
    /// <exception cref="Exception"></exception>
    public static string[] Read(string? filePath)
    {
        string[] data;
        try
        {
            data = File.ReadAllLines(filePath);
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
    /// Запись данных в новый файл, если файл уже существует - ошибка.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="data"></param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="UnauthorizedAccessException"></exception>
    /// <exception cref="Exception"></exception>
    public static void SaveNew(string filePath, string data)
    {
        if (File.Exists(filePath))
        {
            throw new ArgumentException("Файл уже существует.");
        }
        try
        {
            File.WriteAllText(filePath, data);
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

    /// <summary>
    /// Перезапись существующего файла, если файл не существует - ошибка.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="data"></param>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="UnauthorizedAccessException"></exception>
    /// <exception cref="Exception"></exception>
    public static void SaveReplace(string filePath, string data)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден.");
            }

            File.WriteAllText(filePath, data);
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
        catch (UnauthorizedAccessException)
        {
            throw new UnauthorizedAccessException("Путь ведет в каталог.");
        }
        catch (Exception)
        {
            throw new Exception("Указан некорректный путь, либо файл не поддерживается.");
        }
    }

    /// <summary>
    /// Дозапись данных в файл. ОСТОРОЖНО: данные дозаписываются вместе с заголовками,
    /// а значит файл измененный такой дозаписью не всегда получится открыть в программе.
    /// В этом вроде нет ничего страшного, т.к. задание требовало безошибочное открытие СОЗДАННЫХ программой файлов, но не измененных.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="data"></param>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="UnauthorizedAccessException"></exception>
    /// <exception cref="Exception"></exception>
    public static void SaveAppend(string filePath, string data)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден.");
            }

            File.AppendAllText(filePath, $"\n{data}");
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
        catch (UnauthorizedAccessException)
        {
            throw new UnauthorizedAccessException("Путь ведет в каталог.");
        }
        catch (Exception)
        {
            throw new Exception("Указан некорректный путь, либо файл не поддерживается.");
        }
    }
}