// Методы для красивого вывода в консоль, типа печатается
namespace Task02
{
    public static class BeautifulTyping
    {
        public static void PrintLine(string line, int delay = 35,
            ConsoleColor color = ConsoleColor.Gray)
        {
            if (color != ConsoleColor.Gray)
            {
                Console.ForegroundColor = color;
            }
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
            Console.Write('\n');
        }

        public static void Print(string line, int delay = 35,
            ConsoleColor color = ConsoleColor.Gray)
        {
            if (color != ConsoleColor.Gray)
            {
                Console.ForegroundColor = color;
            }
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
        }
    }
}