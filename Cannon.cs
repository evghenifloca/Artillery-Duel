using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery_Duel
{
    internal class Cannon
    {
        public static int xCoord, yCoord;
        public static int[] xCannonCoord = new int[2];
        public static int[] yCannonCoord = new int[2];

        public void CanonGenerate(int player)
        {
            Random generatePosition = new Random();

            if (player == 1)
            {
                xCoord = generatePosition.Next(4, Interface.xWindowSize / 4);
                yCoord = Terrain.yCoordArray[xCoord] - 1;
                xCannonCoord[0] = xCoord;
                yCannonCoord[0] = yCoord;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("████");
                Console.SetCursorPosition(xCoord, yCoord - 1);
                Console.Write("████");
            }
            else
            {
                xCoord = generatePosition.Next(Interface.xWindowSize - (Interface.xWindowSize / 4), Interface.xWindowSize - 4);
                yCoord = Terrain.yCoordArray[xCoord] - 1;
                xCannonCoord[1] = xCoord;
                yCannonCoord[1] = yCoord;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("████");
                Console.SetCursorPosition(xCoord, yCoord - 1);
                Console.Write("████");          
            }

        }

        public static void GeneratedDestroyedCannon(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(x, y - 2);
            Console.Write("DEAD");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(x, y);
            Console.Write("░░░░");
            Console.SetCursorPosition(x, y - 1);
            Console.Write("░░░░");
        }

    }
}