using System;

namespace Practice01_ConsoleMiniGame
{
    class Program
    {
        public static bool b = true;
        public static int x = 6, y = 6;
        public static bool attack = false;
        public static float timer = 600;

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

            #region game scene frame
            // output square frame in game scene
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < width; i = i + 2)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, height - 1);
                Console.Write("■");
                Console.SetCursorPosition(i, height - 6);
                Console.Write("■");
            }
            for (int j = 0; j < height; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write("■");
                Console.SetCursorPosition(width - 2, j);
                Console.Write("■");
            }
            #endregion

            // game
            #region boss property
            int bossX = 30, bossY = 16;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(bossX, bossY);
            Console.Write("■");
            int bossHP = 100;
            int bossArmor = 12;
            #endregion

            Random r = new Random();

            while (currentSceneID == 2)
            {
                #region player
                // player controller
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y);
                Console.Write("●");
                char playerInput = Console.ReadKey(true).KeyChar;
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
                switch (playerInput)
                {
                    case 'W':
                    case 'w':
                        if (y > 1)
                            y--;
                        if (x == bossX && y == bossY)
                        {
                            attack = true;
                            y++;
                        }
                        else
                            attack = false;
                        break;
                    case 'S':
                    case 's':
                        if(y < height -7)
                            y++;
                        if (x == bossX && y == bossY)
                        {
                            attack = true;
                            y--;
                        }
                        else
                            attack = false;
                        break;
                    case 'A':
                    case 'a':
                        if(x > 3)
                            x -= 2;
                        if (x == bossX && y == bossY)
                        {
                            attack = true;
                            x += 2;
                        }
                        else
                            attack = false;
                        break;
                    case 'D':
                    case 'd':
                        if(x < width-3)
                            x += 2;
                        if (x == bossX && y == bossY)
                        {
                            attack = true;
                            x -= 2;
                        }
                        else
                            attack = false;
                        break;
                    default:
                        attack = false;
                        break;
                }
                #endregion

                #region attack process
                if (attack)
                {
                    AttackBoss(bossX, bossY); // change boss color when attack successfully
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(bossX, bossY);
                    Console.Write("■");
                    int attackValue = r.Next(1, 20); // random attack value
                    if (attackValue > bossArmor && bossHP >attackValue) //break boss armor
                    {
                        bossHP -= attackValue;
                        Console.SetCursorPosition(2, height - 4);
                        Console.WriteLine("You attacked boss successful!        ");
                        Console.SetCursorPosition(2, height - 3);
                        Console.WriteLine("Attack: {0} Boss HP: {1}", attackValue, bossHP);
                    }
                    else if (attackValue <= bossArmor) //didn't break boss armor
                    {
                        Console.SetCursorPosition(2, height - 4);
                        Console.WriteLine("Boss blocked your attack! Try again!");
                        Console.SetCursorPosition(2, height - 3);
                        Console.WriteLine("                            ");
                    }
                    else if(attackValue > bossArmor && bossHP <= attackValue) // boss died
                    {
                        Console.SetCursorPosition(2, height - 4);
                        Console.WriteLine("You win! Princess is safe now!       ");
                        Console.SetCursorPosition(2, height - 3);
                        Console.WriteLine("                            ");
                        char input = Console.ReadKey(true).KeyChar;
                        currentSceneID = 3;
                    }
                }
                #endregion
            }

            // final scene
            while (currentSceneID == 3)
            {
                Console.Clear();
                Console.WriteLine("Congratulations!");
                Console.WriteLine("You win!");
                currentSceneID = 0;
            }
        }

        public static void AttackBoss(int x, int y)
        {
            for(int i = 0; i < timer; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(x, y);
                Console.Write("■");
            }
        }
    }
}
