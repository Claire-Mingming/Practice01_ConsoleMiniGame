using System;

namespace Practice01_ConsoleMiniGame
{
    class Program
    {
        public static bool b = true;
        static void Main(string[] args)
        {
            // settings
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(60, 30);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            int cursorX = 20, cursorY = 5;
            Console.SetCursorPosition(cursorX,cursorY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Save the princess");
            Console.WriteLine(" ");
            Console.SetCursorPosition(25, 8);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Start");
            Console.SetCursorPosition(25, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Quit");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // up and down input to change color
            while (true)
            {
                char playerInput = Console.ReadKey(true).KeyChar;

                switch(playerInput)
                {
                    case 'W':
                    case 'w':
                        Console.SetCursorPosition(25, 8);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Start");
                        Console.SetCursorPosition(25, 10);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Quit");
                        b = true;
                        break;
                    case 'S':
                    case 's':
                        Console.SetCursorPosition(25, 8);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Start");
                        Console.SetCursorPosition(25, 10);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quit");
                        b = false;
                        break;
                    case 'P':
                    case 'p':
                        if(!b)
                            Environment.Exit(0);
                        break;
                }
            }

        }
    }
}
