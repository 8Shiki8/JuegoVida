using System;
using System.Linq;
using System.Threading;

namespace Juego6
{
    class Program
    {
        static void Main(string[] args)
        {

            //REGLA CELULAS VIVAS
            //2 o 3 vecinos = viven
            //<2 o >3 vecinos = mueren

            //REGLA CELULAS MUERTAS
            //3 vecinos = se crea vida


            Console.CursorVisible = false;
            
            Rejilla rejilla = new Rejilla();

            
         
           

            Console.WriteLine("Presiona una tecla para empezar");
            Console.ReadKey();
           


            while (true)
            {

                   

                foreach (var item in rejilla.rejilla)
                {
                    Console.WriteLine(item);
                }
                rejilla.rejilla = NuevoFrame(rejilla.rejilla);
                Thread.Sleep(100);
                
                

            }


            Console.ReadKey();

        }

        static string[] NuevoFrame(string[]rejilla)
        {

            

            string[] rejillaBlanca = { "██████████████████████████████████████████████████",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "███                                            ███",
                                       "██████████████████████████████████████████████████"};
            

            for (int i = 1; i < 18; i++)
            {
                for (int i2 = 3; i2 < 47; i2++)
                {
                    
                    rejillaBlanca[i]= rejillaBlanca[i].Remove(i2, 1).Insert(i2, VidaMuerte(i2, i, rejilla).ToString());
                }
            }
            return rejillaBlanca;

        }
        static char VidaMuerte(int x, int y, string[] rejilla)
        {
            string caracteres =" ";
            // X minimo=3  Y minimo=1; X maximo = 46 Y maximo=17
            
            if (x == 3 && y == 1)
            {
                caracteres = rejilla[17][46].ToString() + rejilla[17][3] + rejilla[17][4] +
                                rejilla[1][46] + rejilla[1][4] +
                                rejilla[2][46] + rejilla[2][3] + rejilla[2][4];
            }
            if (x == 46 && y == 1)
            {
                caracteres = rejilla[17][3].ToString() + rejilla[17][45] + rejilla[17][46] +
                               rejilla[1][45] + rejilla[1][3] +
                               rejilla[2][45] + rejilla[2][46] + rejilla[2][3];
            }
            if (x == 3 && y == 17)
            {
                caracteres = rejilla[16][46].ToString() + rejilla[16][3] + rejilla[16][4] +
                               rejilla[17][46] + rejilla[17][4] +
                               rejilla[1][46] + rejilla[1][3] + rejilla[1][4];
            }
            if (x == 46 && y == 17)
            {
                caracteres = rejilla[16][45].ToString() + rejilla[16][46] + rejilla[16][3] +
                               rejilla[17][45] + rejilla[17][3] +
                               rejilla[1][3] + rejilla[1][45] + rejilla[1][46];
            }



            if (x == 3 && y != 1 && y != 17)
            {
                caracteres = rejilla[y - 1][46].ToString() + rejilla[y - 1][x] + rejilla[y - 1][x + 1] +
                              rejilla[y][46] + rejilla[y][x + 1] +
                              rejilla[y + 1][46] + rejilla[y + 1][x] + rejilla[y + 1][x + 1];
            }
            if (x == 46 && y != 1 && y != 17)
            {
                caracteres = rejilla[y - 1][x - 1].ToString() + rejilla[y - 1][x] + rejilla[y - 1][3] +
                             rejilla[y][x - 1] + rejilla[y][3] +
                             rejilla[y + 1][x - 1] + rejilla[y + 1][x] + rejilla[y + 1][3];
            }
            if (y == 1 && x != 3 && x != 46)
            {
                caracteres = rejilla[17][x - 1].ToString() + rejilla[17][x] + rejilla[17][x + 1] +
                             rejilla[y][x - 1] + rejilla[y][x + 1] +
                             rejilla[y + 1][x - 1] + rejilla[y + 1][x] + rejilla[y + 1][x + 1];
            }
            if (y == 17 && x != 3 && x != 46)
            {
                caracteres = rejilla[y - 1][x - 1].ToString() + rejilla[y - 1][x] + rejilla[y - 1][x + 1] +
                             rejilla[y][x - 1] + rejilla[y][x + 1] +
                             rejilla[1][x - 1] + rejilla[1][x] + rejilla[1][x + 1];
            }

            if (caracteres.Count(f=>f=='☻')==0)
            {

                for (int i = y - 1; i < (y-1)+3; i++)
                {
                    for (int i2 = x - 1; i2 <(x-1)+ 3; i2++)
                    {
                       
                        if (i == y && i2 == x)
                        {
                            continue;
                        }
                        if (rejilla[i][i2] == '☻')
                        {
                            caracteres += '☻'.ToString();
                        }
                    }
                }
            }
            
            if (rejilla[y][x] == ' ')
            {
                if (caracteres.Count(f => f == '☻') == 3)
                {
                    return '☻';                    
                }
            }


            if (rejilla[y][x] == '☻')
            {
                if (caracteres.Count(f => f == '☻') == 2 || caracteres.Count(f => f == '☻') == 3)
                {
                    return '☻';
                }
                else
                    return ' ';
            }


            return ' ';
        }
    }
}
