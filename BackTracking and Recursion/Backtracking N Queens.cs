using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Backtracking_N_Queens
    {
        /*
         Backtracking says whatever changes we bring in the recursion call and when the call is done those changes should be restored too 
        queens are put row by row 
        when putting a queen in a cell there could be queens in above cells but there is no queen in the bellow cell 
        when putting a queen in a cell we just need to check its above (row, col--), right-up diagonal (row--, col++) and left-up diagonal
        (row--, col--), no need to check for down, left-down diagonal and right-down diagonal 

        if(row = length of the board or number rows in the board means all the queens are places and we found a solution 

        he N-Queens problem is a classic example of backtracking. In this problem, you are tasked with placing N queens on an N×N chessboard such that no two queens threaten each other. This means that no two queens can be in the same row, column, or diagonal.

         */

        public int NQueens(bool[,] board)
        {
            return NQueensHelper(board, 0);
        }
        private int NQueensHelper(bool[,] board, int row) // we do not have to pass the col , since queens are placed row by row
        {
            if(row == board.GetLength(0))
            {
                display(board);
                Console.WriteLine();
                return 1;
            }
            int count = 0; // local variable of the function , number of ways we can place a queen 
            // placing the queen and checking for evey row and col
            for(int col = 0;  col < board.GetLength(0); col++)
            {
                // place the queen if it is safe 
                if(isSafe(board, row, col))
                {
                    board[row,col] = true; // placed the queen here 
                    // this row is seen and placed now try to seen if we can place to the below rows 
                    count += NQueensHelper(board, row + 1);
                    // when out of the function call reset back the changes to normal 
                    board[row,col] = false;
                }
            }
            return count;
        }

        private bool isSafe(bool[,] board, int row, int col)
        {
            // chec the entire row , check vertical row 
            for(int r = 0; r < row; r++)
            {
                if (board[r, col] == true)
                    return false;
            }

            // check diagonal left 
            int maxLeft = Math.Min(row, col); // min of row and col, this would be maximum we can go left
            for(int i = 1; i <= maxLeft; i++)
            {
                if (board[row -i, col-i]) // moving diagonally up left both row and col are decreasing 
                {
                    return false;
                }
            }

            // check diagonal left 
            int maxRight = Math.Min(row, board.GetLength(0)-col-1); // maximum we can go right 
            for (int i = 1; i <= maxRight; i++)
            {
                if (board[row - i, col + i]) // moving diagonally up left both row and col are decreasing 
                {
                    return false;
                }
            }
            return true;
        }

        private void display(bool[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++) // Iterate over the first dimension
            {
                for (int j = 0; j < board.GetLength(1); j++) // Iterate over the second dimension
                {
                    if (board[i, j])
                        Console.Write("Q ");
                    else
                        Console.Write("X ");
                }
                Console.WriteLine();
            }
        }





        /* ------------------------------------------- */
        static int N = 4; // Change this value to increase the size of the chessboard

        // A utility function to check if a queen can be placed on board[row][col].
        // Note that this function is called when "col" queens are already placed
        // in columns from 0 to col -1. So we need to check only the left side for attacking queens.
        static bool IsSafe(int[,] board, int row, int col)
        {
            int i, j;

            // Check this row on the left side
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            // Check the upper diagonal on the left side
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            // Check the lower diagonal on the left side
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        // A recursive utility function to solve the N Queen problem
        static bool SolveNQUtil(int[,] board, int col)
        {
            // Base case: If all queens are placed, then return true
            if (col >= N)
                return true;

            // Consider this column and try placing this queen in all rows one by one
            for (int i = 0; i < N; i++)
            {
                // Check if the queen can be placed on board[i][col]
                if (IsSafe(board, i, col))
                {
                    // Place this queen in board[i][col]
                    board[i, col] = 1;

                    // Recur to place the rest of the queens
                    if (SolveNQUtil(board, col + 1))
                        return true;

                    // If placing queen in board[i][col] doesn't lead to a solution,
                    // then remove the queen from board[i][col]
                    board[i, col] = 0; // Backtrack
                }
            }

            // If the queen cannot be placed in any row in this column, then return false
            return false;
        }

        // This function solves the N Queen problem using Backtracking.
        static bool SolveNQ()
        {
            int[,] board = new int[N, N]; // Initialize the chessboard

            if (!SolveNQUtil(board, 0))
            {
                Console.WriteLine("Solution does not exist");
                return false;
            }

            // Print the solution
            PrintSolution(board);
            return true;
        }

        // A utility function to print the solution
        static void PrintSolution(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + board[i, j] + " ");
                Console.WriteLine();
            }
        }

    }
}
