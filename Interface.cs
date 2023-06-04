using System;

namespace Artillery_Duel
{
    class Interface
    {
        public static int xWindowSize = 220, yWindowSize = 60;

        public static int degreePlayer1 = Shell.degree, powerPlayer1 = Shell.force;
        public static int degreePlayer2 = Shell.degree, powerPlayer2 = Shell.force;
        public static int player1Score = 0, player2Score = 0;

        public static void InterfaceSet()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(xWindowSize, yWindowSize);
        }

        public static void InterfaceSet(int score)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(xWindowSize, yWindowSize);
            Score();
        }

        public static void Score()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(107, 1);
            Console.Write("        ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(107, 1);
            Console.Write($"{player1Score} : {player2Score}");
        }

        public static void WindVector()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(105, 3);
            Console.Write($"                ");

            if (Shell.windVector <= 0)
            {
                switch (Shell.wind)
                {
                    case 0:
                        Console.SetCursorPosition(106, 3);
                        Console.Write($"NO WIND");
                        break;
                    case 1:
                        Console.SetCursorPosition(106, 3);
                        Console.Write($"WIND <");
                        break;
                    case 2:
                        Console.SetCursorPosition(106, 3);
                        Console.Write($"WIND <<");
                        break;
                    case 3:
                        Console.SetCursorPosition(105, 3);
                        Console.Write($"WIND <<<");
                        break;
                }
            }
            else
            {
                switch (Shell.wind)
                {
                    case 0:
                        Console.SetCursorPosition(106, 3);
                        Console.Write($"NO WIND");
                        break;
                    case 1:
                        Console.SetCursorPosition(106, 3);
                        Console.Write($"WIND >");
                        break;
                    case 2:
                        Console.SetCursorPosition(106, 3);
                        Console.Write($"WIND >>");
                        break;
                    case 3:
                        Console.SetCursorPosition(105, 3);
                        Console.Write($"WIND >>>");
                        break;
                }
            }

        }

        public static void Menu()
        {
            int y = 25;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(104, y - 3);
            Console.Write("ART DUEL");
            

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(99, y);
            Console.Write("Cannon(Gun) Degree");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(99, y + 1);
            Console.Write("UP and DOWN arrows");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(103, y + 3);
            Console.Write("Shot Power");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(97, y + 4);
            Console.Write("RIGHT and LEFT arrows");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(106, y + 6);
            Console.Write("Fire");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(104, y + 7);
            Console.Write("SPACEBAR");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(93, y + 25);
            Console.Write("Press any key to start the Game...");


            Console.ReadKey();
            Program.menu = false;
        }

            public void CanonInterface(ref int power, ref int degree, int player)
        {
            UpdateCannonParams(ref power, ref degree, player); 
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey();
                
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (degree < 15) degree++;
                        UpdateCannonParams(ref power, ref degree, player);
                        break;
                    case ConsoleKey.UpArrow:
                        if (degree > 1) degree--;
                        UpdateCannonParams(ref power, ref degree, player);
                        break;
                    case ConsoleKey.RightArrow:
                        if (power < 99) power++;
                        UpdateCannonParams(ref power, ref degree, player);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (power > 0) power--;
                        UpdateCannonParams(ref power, ref degree, player);
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Spacebar);

            SaveCannonParams(ref power, ref degree, player);
        }

        public void SaveCannonParams(ref int power, ref int degree, int player)
        {
            if (player == 1)
            {
                powerPlayer1 = power;
                degreePlayer1 = degree;
            }
            else if (player == 2)
            {
                powerPlayer2 = power;
                degreePlayer2 = degree;
            }
        }

        public void UpdateCannonParams(ref int power, ref int degree, int player)
        {
            if (player == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(2, 1);
                Console.Write($"                       ");
                Console.SetCursorPosition(2, 1);
                Console.Write($"SHOT POWER   {Shell.force}");
                Console.SetCursorPosition(2, 2);
                Console.Write($"                     ");
                Console.SetCursorPosition(2, 2);
                Console.Write($"CANON DEGREE {(15 - Shell.degree) * 6}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(197, 1);
                Console.Write($"    ");
                Console.ForegroundColor= ConsoleColor.White;
                Console.SetCursorPosition(19, 1);
                Console.Write($"<---");
            }
            else if (player == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(201, 1);
                Console.Write($"                  ");
                Console.SetCursorPosition(206, 1);
                Console.Write("SHOT POWER");
                Console.SetCursorPosition(203, 1);
                Console.Write(Shell.force);
                Console.SetCursorPosition(200, 2);
                Console.Write($"                     ");
                Console.SetCursorPosition(203, 2);
                Console.Write((15 - Shell.degree) * 6);
                Console.SetCursorPosition(206, 2);
                Console.Write("CANON DEGREE");


                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(19, 1);
                Console.Write($"    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(197, 1);
                Console.Write($"--->");
            }
            
        }
    }
}
