class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        for (int i=0; i<n; i++)
        {
            int item = int.Parse(Console.ReadLine());
            a[i] = item;
        }
    }
}