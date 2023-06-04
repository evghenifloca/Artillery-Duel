using System.ComponentModel.Design;
using System.Numerics;

namespace Artillery_Duel
{
    class Program
    {
        public static bool session = true;
        public static bool game = true;
        public static bool menu = true;


        static void Main(string[] args)
        {
            Console.Title = "Artillery Duel";
            Interface @interface = new Interface();
            Terrain terrain = new Terrain();
            Cannon cannon = new Cannon();
            Shell shell = new Shell();

            while (menu == true)
            {
                Interface.InterfaceSet();
                Interface.Menu();
            }

            Console.Clear();

            while (game) 
            {
                Interface.InterfaceSet(1);
                terrain.TerrainReset();
                terrain.GenerateTerrain();

                cannon.CanonGenerate(1);
                cannon.CanonGenerate(2);

                shell.ParamsAdditionalUpdate(2);
                @interface.UpdateCannonParams(ref Shell.force, ref Shell.degree, 1);
                @interface.UpdateCannonParams(ref Shell.force, ref Shell.degree, 2);

                session = true;
                int gameSpeed = 120;

                while (session == true)
                {
                    shell.WindPower();
                    Interface.WindVector();
                    shell.CoordUpdate(1);
                    @interface.CanonInterface(ref Shell.force, ref Shell.degree, 1);
                    Shell.flying = true;
                    while (Shell.flying == true)
                    {
                        shell.Flying(1);
                        Thread.Sleep(gameSpeed);
                    }
                    Shell.CannonDestroyed(Shell.xCoord, Shell.yCoord, Cannon.xCannonCoord[1], Cannon.yCannonCoord[1], 1);

                    if (session == false)
                        break;

                    shell.WindPower();
                    Interface.WindVector();
                    shell.CoordUpdate(2);
                    @interface.CanonInterface(ref Shell.force, ref Shell.degree, 2);
                    Shell.flying = true;
                    while (Shell.flying == true)
                    {
                        shell.Flying(2);
                        Thread.Sleep(gameSpeed);
                    }
                    Shell.CannonDestroyed(Shell.xCoordSecond, Shell.yCoordSecond, Cannon.xCannonCoord[0], Cannon.yCannonCoord[0], 2);
                }

                Console.ReadKey();
                Console.Clear();
            }
            
        }
    }



}