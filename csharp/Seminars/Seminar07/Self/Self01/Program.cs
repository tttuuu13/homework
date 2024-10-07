class Program
{
    public static void Triangle(int n)
    {
        if (n <= 0) return;
        for (int i=1; i <= n; i++)
        {
            Console.WriteLine(new string('*', i));
        }
    }
}