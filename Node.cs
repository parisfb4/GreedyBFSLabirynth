using System;
using System.Collections.Generic;
using System.Text;

namespace GreedyBFSLabirynth
{
    class Node
    {
        #region Variables y Metodos
        private List<Node> children = new List<Node>();         //Lista para los nodos hijos que resultan al realizar un movimiento
        private Node parent;                                    //Nodo padre
        private int[,] puzzle = new int[200, 200];                      //Arreglo del puzzle, o estructura actual
        private int x = 0;                                      //Indicador de posicion del 0
        private int cols, rows;                                    //Posiciones del puzzle que es 3 x 3

        //Posición (x,y) del agente en la matriz de números
        private int posRow;
        private int posCol;

        public int[,] Puzzle { get => puzzle; set => puzzle = value; }
        public int X { get => x; set => x = value; }
        internal List<Node> Children { get => children; set => children = value; }
        internal Node Parent { get => parent; set => parent = value; }
        public int Cols { get => cols; set => cols = value; }
        #endregion

        #region Constructor
        public Node(int[,] value, int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            SetPuzzle(value); //Establecer el puzzle actual
            asignPosition();
        }
        void asignPosition()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (puzzle[i, j] == 2)
                    {
                        posRow = i;
                        posCol = j;
                        return;
                    }
                }
            }
        }
        #endregion

        //Obtener hijos
        public List<Node> GetChildren()
        {
            return children;
        }

        //Funcion para copear el puzzle inicial a la clase para ser alamacenado
        public void SetPuzzle(int[,] value)
        {

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    puzzle[i, j] = value[i, j];
                }

            }
        }

        //Obtiene los posibles hijos
        public void ExpandNode()
        {
            asignPosition(); //Asigna la posición en donde está el cursor (2)
            MoveToRigth(Puzzle, this.posRow, this.posCol);
            MoveToLEft(Puzzle, this.posRow, this.posCol);
            MoveToUp(Puzzle, this.posRow, this.posCol);
            MoveToDown(Puzzle, this.posRow, this.posCol);
        }

        //Funcion para verificar que la meta no ha llegado al final o si
        public bool GoalTest()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (puzzle[i, j] == 2) return false;
                }

            }
            return true;

        }

        //Funcion para copiar el puzzle cuando se realzia un movimiento y poder evaluar los hijos en ese estado. 
        public void CopyPuzzle(int[,] PrimerPuzzle, int[,] SecondPuzzle)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PrimerPuzzle[i, j] = SecondPuzzle[i, j];
                }

            }
        }

        //Funcion para imprimir el puzzle 
        public void PrintPuzzle()
        {
            Console.WriteLine();
            int m = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(puzzle[i, j] + " ");
                    m++;
                }
                Console.WriteLine();
            }
        }

        public bool IsSamePuzzle(int[,] p)
        {
            bool samePuzzle = true;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (puzzle[i, j] != p[i, j])
                    {
                        samePuzzle = false;
                    }
                }

            }
            return samePuzzle;

        }
        #region Movimientos Derecha, Izquierda, Abajo y Arriba
        //Mover a la derecha y obtener hijos posibles
        public void MoveToRigth(int[,] value, int row, int col) //Recibe el puzle actual y la posición del cursor
        {
            if (col + 1 <= cols -1)
            {
                int[,] puzzle_auxiliar = new int[200, 200];
                CopyPuzzle(puzzle_auxiliar, value);
                if (puzzle[row, col + 1] == 0)
                {
                    puzzle_auxiliar[row, col] = 0;
                    puzzle_auxiliar[row, col + 1] = 2;
                }
                else if (puzzle[row, col + 1] == 3)
                {
                    puzzle_auxiliar[row, col] = 0;
                    puzzle_auxiliar[row, col + 1] = 3;
                }
                else return;

                Node child = new Node(puzzle_auxiliar, rows, cols);
                children.Add(child);
                child.parent = this;

            }

        }

        //Mover a la Izquierda y obtener hijos posibles
        public void MoveToLEft(int[,] value, int row, int col)  //Recibe el puzle actual y la posición del cursor
        {
            if (col - 1 >= 0)
            {
                int[,] puzzle_auxiliar = new int[200, 200];
                CopyPuzzle(puzzle_auxiliar, value);
                if (puzzle[row, col - 1] == 0)
                {
                    puzzle_auxiliar[row, col] = 0;
                    puzzle_auxiliar[row, col - 1] = 2;
                }
                else if (puzzle[row, col - 1] == 3)
                {
                    puzzle_auxiliar[row, col] = 0;
                    puzzle_auxiliar[row, col - 1] = 3;
                }
                else return;
                Node child = new Node(puzzle_auxiliar, rows, cols);
                children.Add(child);
                child.parent = this;

            }
        }

        //Mover Arriba y obtener hijos posibles
        public void MoveToUp(int[,] value, int row, int col)  //Recibe el puzle actual y la posición del cursor
        {
            if (row - 1 >= 0)
            {
                int[,] puzzle_auxiliar = new int[200, 200];
                CopyPuzzle(puzzle_auxiliar, value);
                if (puzzle[row - 1, col] == 0)
                {
                    puzzle_auxiliar[row, col] = 0;
                    puzzle_auxiliar[row - 1, col] = 2;
                }
                else if (puzzle[row - 1, col] == 3)
                {
                    puzzle_auxiliar[row, col] = 0;
                    puzzle_auxiliar[row - 1, col] = 3;
                }
                else return;
                Node child = new Node(puzzle_auxiliar, rows, cols);
                children.Add(child);
                child.parent = this;

            }
        }

        //Mover Abajo y obtener hijos posibles
        public void MoveToDown(int[,] value, int row, int col)  //Recibe el puzle actual y la posición del cursor
        {
            if (row + 1 <= rows -1 )
            {
                int[,] puzzle_auxiliar = new int[200, 200];
                CopyPuzzle(puzzle_auxiliar, value);
                if (puzzle[row + 1, col] == 0)
                {
                    puzzle_auxiliar[row, col] = 0;
                    puzzle_auxiliar[row + 1, col] = 2;
                }
                else if (puzzle[row + 1, col] == 3)
                {
                    puzzle_auxiliar[row, col] = 0;
                    puzzle_auxiliar[row + 1, col] = 3;
                }
                else return;
                Node child = new Node(puzzle_auxiliar, rows, cols);
                children.Add(child);
                child.parent = this;

            }
        }
        #endregion
    }
}
