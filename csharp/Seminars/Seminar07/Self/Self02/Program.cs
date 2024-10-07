class Program
{
    public static void Ornament(int n, int m)
    {
        if (m <= 0) return;
        for (int i=1; i <= m; i++)
        {
            Triangle(n);
        }
    }
    public static void Triangle(int n)
    {
        if (n <= 0) return;
        for (int i=1; i <= n; i++)
        {
            Console.WriteLine(new string('*', i));
        }
    }
}