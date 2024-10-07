 class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        Random rnd = new Random();
        for (int i=0; i<n; i++)
        {
            int item = rnd.Next(-2, 8);
            a[i] = item;
        }
        foreach (int val in a)
        {
            Console.WriteLine(val);
        }
    }
}