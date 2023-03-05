using System;

namespace Practice01_ConsoleMiniGame
{
    class Program
    {
        public static bool b = true;
        static void Main(string[] args)
        {
            #region Start scene
            // settings
            Console.CursorVisible = false;
            int width = 60, height = 30;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
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

            // set scene id number
            int currentSceneID = 1;

            // up and down input to change color
            while (currentSceneID == 1)
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
                        if(b)
                            currentSceneID = 2;
                        if (!b)
                            Environment.Exit(0);
                        break;
                }
            }
            #endregion

            #region Switch next scene

            while (true)
            {
                switch (currentSceneID)
                {
                    case 1: // start scene
                        break;
                    case 2: // game scene
                        Console.Clear();
                        break;
                    case 3: //end scene
                        Console.Clear();
                        break;
                }
            }
            #endregion

            #region Game scene
            while(currentSceneID == 2)
            {

            }
            #endregion
        }
    }
}
