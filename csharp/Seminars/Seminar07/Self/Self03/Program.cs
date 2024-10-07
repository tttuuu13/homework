class Program
{
    public static void Ornament(int n, int m)
    {
        if (m <= 0) return;
        for (int i=1; i <= n; i++)
        {
            Triangle(i, n, m);
        }
    }
    public static void Triangle(int k, int n, int m)
    {
        if (n <= 0 || k <= 0) return;
        for (int i=1; i <= m; i++)
        {
            Console.Write(new string('*', k)+new string(' ', n-k));
        }
        Console.WriteLine();
    }
}