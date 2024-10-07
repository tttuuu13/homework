namespace ClassLibrary;

public static class Files
{
    /// <summary>
    /// Writes data to a file.
    /// </summary>
    /// <param name="filePath">A path to the file.</param>
    /// <param name="data">Data that should be written in the file.</param>
    public static void Write(string? filePath, string data)
    {
        try
        {
#pragma warning disable CS8604 // Possible null reference exception handled bellow.
            File.WriteAllText(filePath, data);
#pragma warning restore CS8604 // Possible null reference exception handled bellow.
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
    /// Reads data from a file.
    /// </summary>
    /// <param name="filePath">A path to the file.</param>
    /// <returns>Data written in a file as a string.</returns>
    public static string Read(string? filePath)
    {
        string data;
        try
        {
#pragma warning disable CS8604 // Possible null exeption handled bellow.
            data = File.ReadAllText(filePath);
#pragma warning restore CS8604 // Possible null exeption handled bellow.
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
}