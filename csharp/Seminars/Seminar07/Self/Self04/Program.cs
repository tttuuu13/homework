class Program
{
    public static void RenderCanvas(char[,] canvas)
    {
        Console.Clear();
        for (int i = 0; i < canvas.GetLength(0); i++)
        {
            for (int j = 0; j < canvas.GetLength(1); j++)
            {
                Console.Write($"{canvas[i,j]} ");
            }
            Console.WriteLine();
        }
        Thread.Sleep(100);
    }
    public static void Python(int n)
    {
        // create blank canvas
        char[,] canvas = new char[n, 4*n-1];
        for (int r=0; r < n; r++)
        {
            for (int c=0; c < 4*n-1; c++)
            {
                canvas[r, c] = ' ';
            }
        }
        int r1=n-1;
        int c1=0;
        canvas[r1, c1] = '*';
        RenderCanvas(canvas);
        while (true)
        {
            while (!(r1==0))
            {
                r1-=1;
                canvas[r1, c1] = '*';
                RenderCanvas(canvas);
            }
            c1+=1;
            canvas[r1, c1] = '*';
            RenderCanvas(canvas);
            c1+=1;
            canvas[r1, c1] = '*';
            RenderCanvas(canvas);
            while (!(r1==n-1))
            {
                r1+=1;
                canvas[r1, c1] = '*';
                RenderCanvas(canvas);
            }
            if (r1==n-1&&c1==4*n-2)
            {
                return;
            }
            c1+=1;
            canvas[r1, c1] = '*';
            RenderCanvas(canvas);
            c1+=1;
            canvas[r1, c1] = '*';
            RenderCanvas(canvas);
        }
        
    }
    static void Main()
    {
        Python(7);
    }
}