using System;
using System.Collections.Generic;
using System.Text;

namespace GreedyBFSLabirynth
{
    class Laberinto
    {
        int ROWS; // Número de filas del laberinto dadas por el txt
        int COLS; // Número de columnas del laberinto dadas por el txt
        int[,] Matrix = new int[200, 200]; // Tablero límite del txt es 200 por 200
        public Laberinto()
        {

        }
        public int getRows()
        {
            return ROWS;
        }
        public int getCols()
        {
            return COLS;
        }
        public int[,] getMatrix()
        {
            return Matrix;
        }
        //Lee el archivo txt y le asigna valores a la matriz tablero
        public void Readlabyrinth()
        {
            Console.WriteLine("Nombre del archivo generador de laberinto: ");
            string name = Console.ReadLine();

            string line;
            int counterRows = 0;

            try
            {                
                System.IO.StreamReader file = new System.IO.StreamReader(name);
                while (!file.EndOfStream)
                {
                    line = file.ReadLine();
                    for (int k = 0; k < line.Length; k++) //Por cada caracter de la línea leída
                    {
                        if (line[k] != '\n')
                        {
                            string a = line[k].ToString();
                            Matrix[counterRows, k] = Int32.Parse(a);
                        }

                    }

                    COLS = line.Length;
                    counterRows++;
                }
                file.Close();

                ROWS = counterRows;
                PrintLabyrinth(Matrix);


            }
            catch //Vuelve a intentar leer
            {
                Console.WriteLine("Error al intertar leer el archivo. Intente nuevamente" +
                    "El Archivo .txt debe estar en la misma dirección que el ejecutable");
                Readlabyrinth();
            }
        }
        public void PrintLabyrinth(int[,] matrix)
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine(" ");
            }

        }
    }
}
