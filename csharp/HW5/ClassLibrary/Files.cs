using System.Text;

namespace ClassLibrary;
/// <summary>
/// Class that contains methods for reading files and writing data using standart console.
/// </summary>
public static class Files
{
    /// <summary>
    /// Reads file by provided path using console.
    /// </summary>
    /// <param name="filePath">Absolute or relative path to the file.</param>
    /// <returns>File contents as string.</returns>
    public static string Read(string? filePath)
    {
        try
        {
            var json = new StringBuilder();
            using (var reader = new StreamReader(filePath))
            {
                Console.SetIn(reader);
                string? line;
                while ((line = Console.ReadLine()) != null)
                {
                    json.Append(line);
                }
            }

            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            return json.ToString();
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException("Файл не найден.");
        }
        catch (DirectoryNotFoundException)
        {
            throw new DirectoryNotFoundException("Указан недопустимый путь.");
        }
        catch (IOException)
        {
            throw new IOException("Неккоректный путь.");
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Путь является пустой строкой.");
        }
        catch (Exception e)
        {
            throw new Exception("Проблема с открытием файла.");
        }
    }

    /// <summary>
    /// Writes the provided data to a file located at the specified path using console, overwrites the entire contents of the existing file. If the file does not exist, creates a new file.
    /// </summary>
    /// <param name="filePath">Absolute or relative path to the file.</param>
    /// <param name="data">A string that should be written in the file.</param>
    public static void Write(string? filePath, string data)
    {
        try
        {
            using (var writer = new StreamWriter(filePath))
            {
                Console.SetOut(writer);
                Console.Write(data);
            }
        }
        catch (DirectoryNotFoundException)
        {
            throw new DirectoryNotFoundException("Указан недопустимый путь.");
        }
        catch (IOException)
        {
            throw new IOException("Неккоректный путь.");
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Путь является пустой строкой.");
        }
        catch (Exception)
        {
            throw new Exception("Проблема с записью.");
        }
        finally
        {
            var standartOutput = new StreamWriter(Console.OpenStandardOutput());
            standartOutput.AutoFlush = true;
            Console.SetOut(standartOutput);
        }
    }
}