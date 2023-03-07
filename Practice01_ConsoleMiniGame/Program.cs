using System;

namespace Practice01_ConsoleMiniGame
{
    class Program
    {
        public static bool b = true;
        public static int x = 4, y = 3;

        static void Main(string[] args)
        {
            #region Start scene
            // basic settings
            Console.CursorVisible = false;
            int width = 60, height = 30;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.SetCursorPosition(width / 2 - 10, height / 2 - 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Save the princess");
            Console.WriteLine(" ");
            Console.SetCursorPosition(width / 2 - 5, height / 2 - 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Start");
            Console.SetCursorPosition(width / 2 - 5, height / 2 - 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Quit");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // set scene id number
            int currentSceneID = 1;

            while (currentSceneID == 1)
            {
                char playerInput = Console.ReadKey(true).KeyChar;

                switch(playerInput)
                {
                    // up and down input to change color to make a choice
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
                    // enter the game
                    case 'P':
                    case 'p':
                        if (b)
                        {
                            currentSceneID = 2;
                        }
                        else if (!b)
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        break;
                }
            }
            #endregion

            #region Game scene
            // output square frame in game scene
            if(currentSceneID == 2)
            {
                Console.Clear();
                for (int i = 0; i < width; i = i+2)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                    Console.SetCursorPosition(i, height-1);
                    Console.Write("■");
                    Console.SetCursorPosition(i, height-5);
                    Console.Write("■");
                }
                for(int j = 0; j < height; j++)
                {
                    Console.SetCursorPosition(0, j);
                    Console.Write("■");
                    Console.SetCursorPosition(width-2, j);
                    Console.Write("■");
                }
            }
            // game
            while(currentSceneID == 2)
            {
                // player controller
                Console.SetCursorPosition(x, y);
                Console.Write("●");
                char playerInput = Console.ReadKey(true).KeyChar;
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
                switch (playerInput)
                {
                    case 'W':
                    case 'w':
                        if (y > 1 )
                            y--;
                        break;
                    case 'S':
                    case 's':
                        if(y < height -6)
                            y++;
                        break;
                    case 'A':
                    case 'a':
                        if(x > 3)
                            x -= 2;
                        break;
                    case 'D':
                    case 'd':
                        if(x < width-3)
                            x += 2;
                        break;
                    default:
                        break;
                }
            }
            #endregion
        }
    }
}
