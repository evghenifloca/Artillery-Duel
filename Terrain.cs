using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery_Duel
{
    class Terrain
    {
        public static int xCoord = 0;
        public static int yCoord = 50 ;

        public static int[] yCoordArray = new int[225];

        int lineType;

        public void TerrainReset()
        {
            xCoord = 0;
            yCoord = 50;
        }

        public void GenerateTerrain()
        {
            Random line = new Random();

            while (xCoord < Interface.xWindowSize - 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;

                lineType = line.Next(1, 6);
                if (yCoord >= 20 && yCoord <= Interface.yWindowSize - 6)
                {
                    if (xCoord < Interface.xWindowSize - 2)
                    {
                        switch (lineType)
                        {
                            case 1:
                                HorizontalLine();
                                break;
                            case 2:
                                DiagonalUpLine();
                                break;
                            case 3:
                                DiagonalDownLine();
                                break;
                            case 4:
                                SemiDiagonalUpLine();
                                break;
                            case 5:
                                SemiDiagonalDownLine();
                                break;
                        }
                    }
                }
                else if (yCoord <= 20)
                    yCoord = 20;
                else if (yCoord >= Interface.yWindowSize - 6)
                    yCoord = Interface.yWindowSize - 6;
            }
        }

        public void HorizontalLine() 
        {
            for (int i = 0; i < 4; i++)
            {
                if (xCoord < Interface.xWindowSize)
                {
                    Console.SetCursorPosition(xCoord++, yCoord);
                    Console.Write("█");
                }
                yCoordArray[xCoord] = yCoord;
            }
        }

        public void DiagonalUpLine()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(xCoord++, yCoord--);
                Console.Write("█");
                yCoordArray[xCoord] = yCoord;
            }
        } 

        public void DiagonalDownLine()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(xCoord++, yCoord++);
                Console.Write("█");
                yCoordArray[xCoord] = yCoord;
            }
        }

        public void SemiDiagonalUpLine()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(xCoord++, yCoord);
                Console.Write("█");

                if (i % 2 == 0)
                    yCoord--;

                yCoordArray[xCoord] = yCoord;
            }
        }

        public void SemiDiagonalDownLine()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(xCoord++, yCoord);
                Console.Write("█");

                if (i % 2 == 0)
                    yCoord++;

                yCoordArray[xCoord] = yCoord;
            }
        }
    }
}
