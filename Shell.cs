using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Artillery_Duel
{
    internal class Shell
    {
        const double gravity = 9.8;
        public static int force = 50;
        public static int wind;
        public static int windVector;
        public static int degree = 8;
        public static int xCoord = Cannon.xCannonCoord[0] + 2, yCoord = Cannon.yCannonCoord[0] - 2;
        public static int xCoordSecond = Cannon.xCannonCoord[1] + 2, yCoordSecond = Cannon.yCannonCoord[1] - 2;
        public static bool flying = true;
        public static bool flying2 = false;

        void FlyingProcess(ref int x, ref int y, int player)
        {
            if (x > 0 && x < 220)
            {
                flying = true;
                Console.ForegroundColor = ConsoleColor.Yellow;

                try
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }

                force -= Convert.ToInt32(gravity);
                y -= Convert.ToInt32(force / gravity);


                if (player == 1)
                    x += degree;
                else
                    x -= degree;

                if (windVector <= 0)
                    x -= wind;
                else
                    x += wind;

                try
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("0");
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (x < 0)
                        x = 0;
                    else if (x > 220)
                        x = 219;
                }


                if (y >= Terrain.yCoordArray[x] + Convert.ToInt32(force / gravity)
                || y <= Convert.ToInt32(force / gravity)
                || x <= degree
                || x >= 220 - degree)
                {
                    flying = false;
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }


        }

        public void WindPower()
        {
            Random random = new Random();
            windVector = random.Next(-5, 7);
            wind = random.Next(0, 4);
        }

        public bool Flying(int player)
        {
            if (player == 1)
            {
                FlyingProcess(ref xCoord, ref yCoord, 1);
            }

            else if (player == 2)
            {
                FlyingProcess(ref xCoordSecond, ref yCoordSecond, 2);
            }

            return flying;

        }

        public void CoordUpdate(int player)
        {
            if (player == 1)
            {
                force = Interface.powerPlayer1;
                degree = Interface.degreePlayer1;

            }
            else if (player == 2)
            {
                force = Interface.powerPlayer2;
                degree = Interface.degreePlayer2;
            }


            if (player == 1)
            {
                xCoord = Cannon.xCannonCoord[player - 1] + 2;
                yCoord = Cannon.yCannonCoord[player - 1] - 2;

            }
            else if (player == 2)
            {
                xCoordSecond = Cannon.xCannonCoord[player - 1] + 2;
                yCoordSecond = Cannon.yCannonCoord[player - 1] - 2;
            }
        }

        public void ParamsAdditionalUpdate(int player)
        {
            if (player == 1)
            {
                force = Interface.powerPlayer1;
                degree = Interface.degreePlayer1;

            }
            else if (player == 2)
            {
                force = Interface.powerPlayer2;
                degree = Interface.degreePlayer2;
            }
        }

        public static void CannonDestroyed(int xShell, int yShell, int xCannon, int yCannon, int player)
        {
            int x = Math.Abs(xShell - xCannon),
                y = Math.Abs(yShell - yCannon);

            if (x <= 6 && y <= 6)
            {
                Cannon.GeneratedDestroyedCannon(xCannon, yCannon);
                Program.session = false;

                if (player == 1)
                    Interface.player1Score++;
                else
                    Interface.player2Score++;
            }
        }
    }

        
    
}