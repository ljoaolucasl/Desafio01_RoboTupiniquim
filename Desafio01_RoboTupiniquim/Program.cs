using System.Data;
using System.Xml.XPath;

namespace Desafio01_RoboTupiniquim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string robo1 = "■";

            int x = (Console.WindowWidth / 2 - 5);
            int y = (Console.WindowHeight / 2 - 1);
            int xp = 1; int yp = 2;

            //__________________________________________

            string robo2 = "▲";

            int x2 = (Console.WindowWidth / 2 - 3);
            int y2 = (Console.WindowHeight / 2 - 2);
            int xp2 = 3; int yp2 = 3;

            //__________________________________________

            string direcao = "Direção - N";

            int contador = 0;

            bool passa = false;

            bool robo = false;

            //__________________________________________

            Console.CursorVisible = false;

            CriaArea();

            CriaRobo(x, y, robo1);

            CriaRobo(x2, y2, robo2);

            DescricoesTela();

            while (true)
            {
                if (!robo)                                                            //Robo 1
                {
                    while (true)
                    {
                        MostraDirecao(direcao);

                        MostraPosicao(xp, yp, robo1);

                        ConsoleKeyInfo teclaPressionada = Console.ReadKey(true);

                        MudaDirecao(ref direcao, ref contador, teclaPressionada);

                        Console.SetCursorPosition(x, y);
                        Console.Write(" ");

                        Mover(ref x, ref y, ref xp, ref yp, direcao, teclaPressionada, passa);

                        LimiteArea(ref x, ref y, ref xp, ref yp);

                        if (x == x2 && y == y2)
                        {
                            passa = true;
                            Mover(ref x, ref y, ref xp, ref yp, direcao, teclaPressionada, passa);
                            passa = false;
                        }

                        CriaRobo(x, y, robo1);

                        if (teclaPressionada.Key == ConsoleKey.Y)
                        {
                            robo = true;
                            break;
                        }
                    }
                }
                else                                                                  //Robo 2
                {
                    while (true)
                    {
                        MostraDirecao(direcao);

                        MostraPosicao(xp2, yp2, robo2);

                        ConsoleKeyInfo teclaPressionada = Console.ReadKey(true);

                        MudaDirecao(ref direcao, ref contador, teclaPressionada);

                        Console.SetCursorPosition(x2, y2);
                        Console.Write(" ");

                        Mover(ref x2, ref y2, ref xp2, ref yp2, direcao, teclaPressionada, passa);

                        LimiteArea(ref x2, ref y2, ref xp2, ref yp2);

                        if (x2 == x && y2 == y)
                        {
                            passa = true;
                            Mover(ref x2, ref y2, ref xp2, ref yp2, direcao, teclaPressionada, passa);
                            passa = false;
                        }

                        CriaRobo(x2, y2, robo2);

                        if (teclaPressionada.Key == ConsoleKey.O)
                        {
                            robo = false;
                            break;
                        }
                    }
                }
            }
        }

        private static void DescricoesTela()
        {
            Console.SetCursorPosition(50, 2);
            Console.Write("Robô Tupiniquim");

            Console.SetCursorPosition(28, 22);
            Console.Write("(Q/E) Muda Direção - (M) Se move - (O) ■ Robo 1 - (Y) ▲ Robo 2");

            Console.SetCursorPosition(113, 24);
            Console.Write("N");
            Console.SetCursorPosition(109, 26);
            Console.Write("O");
            Console.SetCursorPosition(117, 26);
            Console.Write("L");
            Console.SetCursorPosition(113, 28);
            Console.Write("S");
            Console.SetCursorPosition(113, 26);
            Console.Write("+");
        }

        private static void MudaDirecao(ref string direcao, ref int contador, ConsoleKeyInfo tecla)
        {

            if (tecla.Key == ConsoleKey.E)
            {
                contador++;
                if (contador > 4)
                {
                    contador = 1;
                }
                switch (contador)
                {
                    case 1: direcao = "Direção - L"; break;
                    case 2: direcao = "Direção - S"; break;
                    case 3: direcao = "Direção - O"; break;
                    case 4: direcao = "Direção - N"; break;
                }
            }

            if (tecla.Key == ConsoleKey.Q)
            {
                contador--;
                if (contador < 1)
                {
                    contador = 4;
                }
                switch (contador)
                {
                    case 1: direcao = "Direção - L"; break;
                    case 2: direcao = "Direção - S"; break;
                    case 3: direcao = "Direção - O"; break;
                    case 4: direcao = "Direção - N"; break;
                }
            }
        }

        private static void Mover(ref int x, ref int y, ref int xp, ref int yp, string direcao, ConsoleKeyInfo tecla, bool passa)
        {
            if (tecla.Key == ConsoleKey.M && !passa)
            {
                switch (direcao)
                {
                    case "Direção - L": x++; xp++; break;
                    case "Direção - S": y++; yp--; break;
                    case "Direção - O": x--; xp--; break;
                    case "Direção - N": y--; yp++; break;
                }
            }
            else if (passa)
            {
                switch (direcao)
                {
                    case "Direção - L": x--; xp--; break;
                    case "Direção - S": y--; yp++; break;
                    case "Direção - O": x++; xp++; break;
                    case "Direção - N": y++; yp--; break;
                }
            }
        }

        private static void MostraPosicao(int xp, int yp, string robo)
        {
            Console.SetCursorPosition(52, 8);
            string posicao = $"{robo} - {xp}, {yp}";
            Console.Write(posicao);
        }

        private static void CriaArea()
        {
            int xArea = (Console.WindowWidth / 2);
            int yArea = (Console.WindowHeight / 2);

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(xArea - 6, yArea - i + 1);
                Console.Write("▓");

                Console.SetCursorPosition(xArea, yArea - i);
                Console.Write("▓");

                Console.SetCursorPosition(xArea - i - 1, yArea - 5);
                Console.Write("▓");

                Console.SetCursorPosition(xArea - i, yArea + 1);
                Console.Write("▓");
            }
        }

        private static void MostraDirecao(string direcao)
        {
            Console.SetCursorPosition(52, 18);
            Console.Write(direcao);
        }

        private static void LimiteArea(ref int x, ref int y, ref int xp, ref int yp)
        {
            switch (x)
            {
                case 54: x++; xp++; break; //55
                case 60: x--; xp--; break; //59
            }

            switch (y)
            {
                case 10: y++; yp--; break; //11
                case 16: y--; yp++; break; //15
            }
        }

        private static void CriaRobo(int x, int y, string robo)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(robo);
        }
    }
}