using System;
class Program
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        double step = a/n;
        double currX = 0;
        double s = 0;
        do
        {
            s+=Math.Pow(currX, 2)*step;
            currX+=step;
        } while (currX+step<=a);
        Console.WriteLine(s);
    }
}