class Program
{
    static void Main()
    {
        string? str = Console.ReadLine();
        if (str.IndexOf('(') > str.IndexOf(')'))
        {
            Console.WriteLine("Закрывающаяся скобка раньше");
            return;
        }

        int c = 0;
        foreach (var chr in str)
        {
            if (chr == '(')
            {
                c += 1;
            }
            else if (chr == ')')
            {
                c -= 1;
            }
        }

        if (c == 0)
        {
            Console.WriteLine("OK");
        }
        else
        {
            Console.WriteLine("Not OK");
        }
    }
}