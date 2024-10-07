using System.Text;

namespace ClassLibrary;


public class Colleges
{
    public ClassLibrary.Сollege[] colleges;
    public string[] Headers { get; set; }

    public Colleges()
    {
        colleges = new ClassLibrary.Сollege[] { };
    }
    
    /// <summary>
    /// Добавляет объект типа колледж в список.
    /// </summary>
    /// <param name="college"></param>
    public void Add(ClassLibrary.Сollege college)
    {
        colleges = colleges.Append(college).ToArray();
    }

    /// <summary>
    /// Сортировка по району.
    /// </summary>
    /// <param name="reversed"></param>
    public void SortByRayon(bool reversed = false)
    {
        if (reversed)
        {
            Array.Sort(colleges, (a, b) => b.CompareTo(a));
            return;
        }
        Array.Sort(colleges);
    }

    /// <summary>
    /// Фильтр по одному из двух столбцов.
    /// </summary>
    /// <param name="key">Имя столбца.</param>
    /// <param name="value">Значение, по которому производится фильтрация.</param>
    public void Filter(string key, string? value)
    {
        var r = new ClassLibrary.Сollege[] {};
        foreach (var college in colleges)
        {
            if (key == "form_of_incorporation")
            {
                if (college.FormOfIncorporation == value)
                {
                    r = r.Append(college).ToArray();
                }
            }
            else if (key == "submission")
            {
                if (college.Submission == value)
                {
                    r = r.Append(college).ToArray();
                }
            }
        }

        colleges = r;
    }

    /// <summary>
    /// Вывод колледжей в виде строки.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="n"></param>
    /// <param name="sep"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public string ToString(SelectRowsToPrint start, int n, string sep = " ")
    {
        var sb = new StringBuilder();
        sb.Append($"{String.Join(sep, Headers)}\n");
        if (start == SelectRowsToPrint.Top)
        {
            for (int i = 0; i < n; i++)
            {
                sb.Append($"{colleges[i].ToString(sep)}\n");
            }
        }
        else if (start == SelectRowsToPrint.Bottom)
        {
            for (int i = colleges.Length - n; i < colleges.Length; i++)
            {
                sb.Append($"{colleges[i].ToString(sep)}\n");
            }
        }
        else
        {
            throw new ArgumentException("Некорректные параметры");
        }
        if (sb.ToString() == "")
        {
            return "Нет данных.";
        }
        return sb.ToString();
    }

    /// <summary>
    /// Вывод колледжей в виде строк, в формате, в котором данные записаны в файл.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"{String.Join(";", Headers)}\n");
        for (int i = 0; i < colleges.Length; i++)
        {
            sb.Append($"{colleges[i]}\n");
        }
        if (sb.ToString() == "")
        {
            return "Нет данных.";
        }
        return sb.ToString();
    }
    
    /// <summary>
    /// Перечисление возможных направлений для печати данных.
    /// </summary>
    public enum SelectRowsToPrint
    {
        Top,
        Bottom
    }
}