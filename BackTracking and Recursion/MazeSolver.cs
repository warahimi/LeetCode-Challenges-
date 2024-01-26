using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    public class MazeSolver
    {
        private int[,] maze;
        private bool[,] visited;
        private List<string> path;
        private int rows, cols;

        public MazeSolver(int[,] inputMaze)
        {
            this.maze = inputMaze;
            this.rows = inputMaze.GetLength(0);
            this.cols = inputMaze.GetLength(1);
            this.visited = new bool[rows, cols];
            this.path = new List<string>();
        }

        public bool Traverse(int row = 0, int col = 0)
        {
            // If out of bounds or on an obstacle or already visited, return false.
            if (row < 0 || col < 0 || row >= rows || col >= cols || maze[row, col] == 1 || visited[row, col])
            {
                return false;
            }

            // Mark the current cell as visited.
            visited[row, col] = true;
            path.Add($"({row},{col})");

            // If we've reached the bottom-right corner, return true.
            if (row == rows - 1 && col == cols - 1)
            {
                return true;
            }

            // Try to move right.
            if (Traverse(row, col + 1))
            {
                return true;
            }

            // Try to move down.
            if (Traverse(row + 1, col))
            {
                return true;
            }

            // Try to move diagonally down-right.
            if (Traverse(row + 1, col + 1))
            {
                return true;
            }

            // If none of the moves worked, backtrack: unmark the current cell and remove the path.
            visited[row, col] = false;
            path.RemoveAt(path.Count - 1);

            // Return false to explore alternative paths.
            return false;
        }

        public List<string> GetPath()
        {
            return path;
        }
    }
}

/*
 * int[,] maze = {
            { 0, 0, 0, 1 },
            { 1, 1, 0, 1 },
            { 0, 0, 0, 0 },
            { 0, 1, 1, 0 }
        };

        MazeSolver solver = new MazeSolver(maze);
        bool result = solver.Traverse();

        if (result)
        {
            List<string> path = solver.GetPath();
            Console.WriteLine("Path to traverse the maze:");
            foreach (var step in path)
            {
                Console.WriteLine(step);
            }
        }
        else
        {
            Console.WriteLine("No path found to traverse the maze.");
        }
 */
