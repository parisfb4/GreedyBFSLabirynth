using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GreedyBFSLabirynth
{
    class Menu
    {
        Laberinto lab = new Laberinto();
        int[,] tablero = new int[200, 200];
        public void mostrarMenu()
        {
            int opc = 0;
            //prueba

            do
            {
                
                lab.Readlabyrinth(); //Lectura del archivo .txt para agregarlo a nuestra matriz
                Console.WriteLine(" \tLaberinto - Algoritmos de búsqueda\n" +
                    "1) Primero el mejor\n" +
                    "4) Salir");
                opc = Convert.ToInt16(Console.ReadLine());
                Stopwatch timerMeasure = new Stopwatch();

                switch (opc)
                {
                    case 1:
                        timerMeasure.Start();
                        Amplitud();
                        Console.WriteLine($"Tiempo: " + timerMeasure.Elapsed.Minutes + ":" + timerMeasure.Elapsed.Seconds + " segundos");
                        break;
                    case 4:
                        Console.WriteLine("Adios");
                        break;
                    default:
                        break;
                }


            } while (opc != 4);
        }
        public void Amplitud()
        {
            //Puzzle Inicial



            Node root = new Node(lab.getMatrix(), lab.getRows(), lab.getCols(), lab.getColsFinal(), lab.getRowsFinal());   //Envia el puzzle inicial a la clase
            UninformedSearch ui = new UninformedSearch();

            List<Node> solution = ui.BreadthFirstSearch(root);
            if (solution.Count > 0)
            {
                Console.WriteLine("Solución encontrada");
                for (int i = 0; i < solution.Count; i++)
                {
                    solution[i].PrintPuzzle();
                }
            }
            else
            {
                Console.WriteLine("No hay solución para este problema");
            }
        }

        public int[] generarPuzzleAleatorio()
        {
            int space = 9;
            Random rnd = new Random();
            //int[] number = { 0, 1, 2, 3, 4, 5, 6, 7, 8};
            List<int> numbersChosen = new List<int>();
            int[] tablero = new int[space];

            int posible;
            for (int i = 0; i < space; ++i)
            {

                posible = rnd.Next(9);
                while (numbersChosen.Contains(posible))
                {


                    posible = rnd.Next(9);
                }
                tablero[i] = posible;
                numbersChosen.Add(posible);
            }


            return tablero;
        }
    }
}
