using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 used in snake and ladder game, when you want to go from point A to point B, and there are some obstacles on the way 

given a 3x3 matrix in howmany was can you reach the last cell starting from the first cell , from any cell you can only go 
right and down 

if we are in any cell in the last column we can only go down
and if we are in any cell in the last we can only go right to reach the last cell

for each recursive call we break down the matrix into smaller and smaller matrices 
RD + (     )
DR + (     )

 */
namespace BackTracking_and_Recursion
{
    internal class Backtracking_Maze_Problem
    {
        // Returns The number of way 
        // from top-left to mat[m-1][n-1]
        public int countPaths(int m, int n)
        {
            // Return 1 if it is the first
            // row or first column
            if (m == 1 || n == 1) // becaue there is only one way to get to any cell of the 1st col o 1st row
                return 1;

            // Recursively find the no of 
            // way to reach the last cell.
            return countPaths(m - 1, n) + // ask the number of ways from the above neighbor 
                countPaths(m, n - 1); // add that value to wahtever the left neighbor returns you 
        }
        public int countPaths_(int row, int col)
        {
            // base condition 
            if(row == 1 || col == 1)
                return 1;
            int left = countPaths_(row - 1, col);
            int above = countPaths_(row, col - 1);
            return left + above;
        }
        /*
         this is not the best solution 
        becase we wast a lot of time and memory by computing and asking the same thing again and again 
        a cell value is used recurively by many other cells that after it , 

        if somehow we could store the values of each cell and access it in O(1) we could save so many recursive calls 
         */

        // optimized version
        public int countPaths2(int m, int n)
        {
            List<List<int>> mat = new List<List<int>>();
            /*
             new int[n]: This creates a new array of int with n elements. By default, all elements in a new integer array in C# are initialized to 0.
new List<int>(...): This creates a new List<int>, which is a generic dynamic-size list of integers in C#.
The new List<int>(new int[n]) expression essentially creates a new list and initializes it with n zeroes.
             */
            for (int i = 0; i < m; i++)
            {
                mat.Add(new List<int>(new int[n]));//reating a new List<int> and initializing it with an array of int that has n elements.
            }

            // Initialize the first column to 1
            for (int i = 0; i < m; i++)
            {
                mat[i][0] = 1;
            }
            // Initialize the first row to 1
            for (int j = 0; j < n; j++)
            {
                mat[0][j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    mat[i][j] = mat[i - 1][j] + mat[i][j - 1];
                }
            }

            return mat[m - 1][n - 1];
        }

        public int countPaths3(int m, int n)
        {
            int[,] mat = new int[m, n];

            // Assuming the first row and first column are initialized to 1,
            // as the original code seems to rely on pre-initialized values.
            // This initialization is necessary because the default value for integers in C# is 0.
            for (int i = 0; i < m; i++)
            {
                mat[i, 0] = 1;
            }
            for (int j = 0; j < n; j++)
            {
                mat[0, j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    mat[i, j] = mat[i - 1, j] + mat[i, j - 1];
                }
            }

            return mat[m - 1, n - 1];
        }

        public class MatrixTraversal
        {
            public int CountWaysToTraverse(int m, int n)
            {
                // Create a 2D array to store the number of ways to reach each cell.
                int[,] dp = new int[m, n];

                // Initialize the first row and first column to 1 because there is only
                // one way to reach any cell in the first row or first column, which is either
                // from the left (for the first row) or from above (for the first column).
                for (int i = 0; i < m; i++)
                {
                    dp[i, 0] = 1;
                }
                for (int j = 0; j < n; j++)
                {
                    dp[0, j] = 1;
                }

                // Calculate the number of ways for all other cells
                for (int i = 1; i < m; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        // The number of ways to reach a cell is the sum of ways to reach
                        // the cell above it and the cell to the left of it.
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }

                // Return the number of ways to reach the bottom-right corner.
                return dp[m - 1, n - 1];
            }
        }



        /*print each pather while traversing the maz
         it is a permutation problem, just use the processed and unproccesed approach 
         */
        public void PrintPath(int row, int col, string path = "")
        {
            // base condition 
            if (row == 1 && col == 1)
            {
                Console.WriteLine(path);
                return;
            }
            if(row > 1 )
                PrintPath(row - 1, col, path + "D");
            if (col > 1)
                PrintPath(row, col - 1, path + "R");
            
        }

        // This function returns a list of paths for traversing a maze
        public List<string> PrintPath2(int row, int col, string path = "")
        {
            // List to store all paths
            List<string> paths = new List<string>();

            // Base condition: If we're at the start, add the current path to the list
            if (row == 1 && col == 1) // assumption that the indexing of the grid starts at 1 rather than 0
            {
                paths.Add(path);
                return paths;
            }

            // If we can move up, move up and add 'D' for down to the path.
            // This is because we're essentially backtracking from the finish to the start.
            if (row > 1)
            {
                List<string> upPaths = PrintPath2(row - 1, col, "D" + path);
                paths.AddRange(upPaths); // Add the paths returned from moving up
            }

            // If we can move left, move left and add 'R' for right to the path.
            // Similarly, we're backtracking from the finish to the start.
            if (col > 1)
            {
                List<string> leftPaths = PrintPath2(row, col - 1, "R" + path);
                paths.AddRange(leftPaths); // Add the paths returned from moving left
            }

            return paths; // Return the list of paths
        }

        public List<string> PrintPath3(int row, int col, string path = "")
        {
            if(row == 1 && col == 1)
            {
                List<string> l = new List<string>();
                l.Add(path);
                return l;
            }
            List<string> paths = new List<string>();
            if (row > 1)
            {
                paths.AddRange(PrintPath3(row-1, col, "D" + path));
            }
            if (col > 1)
            {
                paths.AddRange(PrintPath3(row, col - 1, "R" + path));
            }
            return paths;
        }


        // say we can go right, down and diagonal 
        // in diaganal move we reduce both i and j or add to both i and j (i+1,j+1)
        // we just need to add one more recursion cll 
        // when backtracking 
        // when we are at the first row or first col we can not go diagonally up so (row > 1 && col > 1)
        // when backtracking and go up (row > 1)
        // and to go left (col > 1) 
        // 


        // This function counts the number of paths to traverse a maze from the top-left corner
        // to the bottom-right corner with the ability to move right, down, and diagonally down-right.
        public int CountPathsDiagonally(int m, int n)
        {
            // If either row or column is 1, there's only one path to the end
            // (either all the way right, all the way down, or diagonally if both are 1)
            if (m == 1 || n == 1)
            {
                return 1;
            }

            // If both row and column are greater than 1, the number of paths to the current cell
            // is the sum of paths from the cell above, the cell to the left, and the cell diagonally up-left
            int pathsFromAbove = CountPathsDiagonally(m - 1, n);     // Paths from the cell above
            int pathsFromLeft = CountPathsDiagonally(m, n - 1);       // Paths from the cell to the left
            int pathsDiagonally = CountPathsDiagonally(m - 1, n - 1); // Paths from the cell diagonally up-left

            // The total paths to the current cell is the sum of paths from the three possible previous cells
            return pathsFromAbove + pathsFromLeft + pathsDiagonally;
        }

        /*
         If you are at the first row or the first column (m == 1 || n == 1), there is only one path to the destination because you can only move in one direction without any other choices.
If you are not at the first row or column, you have to consider paths from three different directions: directly above, directly to the left, and diagonally up-left.
The function calls itself recursively to calculate the number of paths from these three positions.
The base case occurs when m or n reaches 1, where it returns 1 because there is only one way to continue to the end from that point, either straight down or straight to the right, or diagonally if both are at 1.
Keep in mind that this recursive function has an exponential time complexity because it recalculates the same subproblems many times. For larger values of m and n, you would want to use dynamic programming or memoization to avoid redundant calculations and improve performance.
         */

        // DP approach
        // This function uses dynamic programming to count the number of paths to traverse a maze
        // from the top-left corner to the bottom-right corner, with the ability to move right,
        // down, and diagonally down-right.
        public int CountPaths(int m, int n)
        {
            // Create a 2D array to store the results of subproblems
            int[,] dp = new int[m, n];

            // Fill the first row and first column with 1s because there is only one way to reach
            // any cell in the first row or column, which is either all the way from the left
            // or all the way from the top
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }

            // Fill in the rest of the dp array
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    // The number of ways to reach the current cell is the sum of the ways to reach
                    // the cell directly above, the cell to the left, and the cell diagonally up-left
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1] + dp[i - 1, j - 1];
                }
            }

            // The bottom-right corner will have the total number of ways to traverse the maze
            return dp[m - 1, n - 1];
        }

        // print the paths
        public List<string> PrintPathDiagonally(int row, int col, string path = "")
        {
            if (row == 1 && col == 1)
            {
                List<string> l = new List<string>();
                l.Add(path);
                return l;
            }
            List<string> paths = new List<string>();
            if (row > 1)
            {
                paths.AddRange(PrintPathDiagonally(row - 1, col, "D" + path));
            }
            if (col > 1)
            {
                paths.AddRange(PrintPathDiagonally(row, col - 1, "R" + path));
            }
            if (row > 1 && col > 1)
            {
                paths.AddRange(PrintPathDiagonally(row - 1, col, "d" + path));
            }
            return paths;
        }

        // Maze with obstacles 
        /*
         when evern we land on a new cell check if that is prohibited or no 
        when landed on a prohibited cell stop recursion for that cell and retrun from blocked cell because we can not go anywhere 
        from blocked or prohibited cell. 
         */


        /*
         int[,] grid = {
            { 0, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 0 }
        };
        MazeTraversal solver = new MazeTraversal();
        int numberOfWays = solver.CountWays(grid);
        Console.WriteLine($"Number of ways to traverse the maze: {numberOfWays}");
         */
        // Function to count the number of ways to traverse to the last cell in a grid with obstacles.

        /*
         In this function:

The grid is passed as a 2D array, with 0 for open cells and 1 for obstacles.
A dynamic programming table dp is used to store the number of ways to reach each cell.
The first row and first column are initialized such that traversal stops at the first obstacle encountered.
For each cell in the grid, the number of ways to reach it is calculated as the sum of the number of ways to reach the cell above and the cell to the left. If a cell is blocked (contains an obstacle), it is skipped, and the number of ways to reach that cell remains zero.
The function returns the value at the bottom-right corner of the dp table, which is the total number of ways to reach that cell.
This approach efficiently handles the presence of obstacles and calculates the number of possible paths to the last cell of the grid, considering the obstacles
         */
        public int CountWays(int[,] grid)
        {
            int m = grid.GetLength(0); // Number of rows
            int n = grid.GetLength(1); // Number of columns

            // Check if the starting or ending cell is blocked
            if (grid[0, 0] == 1 || grid[m - 1, n - 1] == 1)
            {
                return 0;
            }

            int[,] dp = new int[m, n]; // Dynamic programming table

            // Initialize the first row and column
            for (int i = 0; i < m; i++)
            {
                if (grid[i, 0] == 0) dp[i, 0] = 1;
                else break; // Stop if an obstacle is encountered
            }

            for (int j = 0; j < n; j++)
            {
                if (grid[0, j] == 0) dp[0, j] = 1;
                else break; // Stop if an obstacle is encountered
            }

            // Fill in the rest of the dp table
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (grid[i, j] == 0) // If the cell is not blocked
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1]; // Sum of ways from above and left cells
                    }
                    // If the cell is blocked, dp[i, j] remains 0
                }
            }

            // Return the number of ways to reach the bottom-right cell
            return dp[m - 1, n - 1];
        }

        // Recursive 
        /*
         A recursive approach to count the number of ways to traverse a grid with obstacles involves exploring each possible 
        path and accumulating the count of valid paths. This method will check each cell to determine if it's a viable path
        (not an obstacle) and then recursively explore right and down moves from that cell. The base cases will handle reaching
        the bottom-right corner or encountering an obstacle.
         */
        // Function to count the number of ways to traverse to the last cell in a grid with obstacles.
        // 'maze' is a 2D array where 0 represents a path and 1 represents an obstacle.

        public int CountWaysRec(int[,] maze)
        {
            return CountWaysHelper(maze, 0, 0);
        }
        public int CountWaysHelper(int[,] maze, int row, int col)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            // Base case: if it's an obstacle or out of bounds, return 0.
            if (row >= rows || col >= cols || maze[row, col] == 1)
            {
                return 0;
            }

            // Base case: if it's the bottom-right corner, return 1.
            if (row == rows - 1 && col == cols - 1)
            {
                return 1;
            }

            // Recursive calls: move right and down.
            return CountWaysHelper(maze, row + 1, col) + CountWaysHelper(maze, row, col + 1);
        }

        // print path with obstacles 
        public void PrintPathRestrictions(bool[,] maze)
        {
            PrintPathRestrictionHelper(maze, "", 0, 0);
        }
        private void PrintPathRestrictionHelper(bool[,] maze, string processed, int row, int column)
        {
            if (row == maze.GetLength(0) - 1 && column == maze.GetLength(1) - 1)
            {
                Console.WriteLine(processed);
                return;
            }
            if (maze[row, column] == false) // if block cell return
                return;

            if (row < maze.GetLength(0) - 1) // if going down
            {
                PrintPathRestrictionHelper(maze, processed + 'D', row + 1, column);
            }
            if (column < maze.GetLength(1) - 1) // if going right 
            {
                PrintPathRestrictionHelper(maze, processed + 'R', row, column + 1);
            }
        }


        /*
         Now what if we can traver in all 4 directions left rith up and down 
         */

        public void PrintPathRestrictionsAllDirection(bool[,] maze)
        {
            PrintPathRestrictionAllDirectionHelper(maze, "", 0, 0);
        }

        /*
         * once traversed a path never go back to that path again otherwise it will lead to infinite loop.
         * so once we visited a cell we mark it as false so that we should not go back to that cell again 
         */
        private void PrintPathRestrictionAllDirectionHelper(bool[,] maze, string processed, int row, int column)
        {
            if (row == maze.GetLength(0) - 1 && column == maze.GetLength(1) - 1)
            {
                Console.WriteLine(processed);
                return;
            }
            if (maze[row, column] == false) // if block cell return
                return;


            // I have this cell in my path
            maze[row, column] = false;
            if (row < maze.GetLength(0) - 1) // if going down
            {
                PrintPathRestrictionAllDirectionHelper(maze, processed + 'D', row + 1, column);
            }
            if (column < maze.GetLength(1) - 1) // if going right 
            {
                PrintPathRestrictionAllDirectionHelper(maze, processed + 'R', row, column + 1);
            }
            // if we are at a cell and want to go up col-1 and row remains the same 
            if (row > 0) // if going up 
            {
                PrintPathRestrictionAllDirectionHelper(maze, processed + 'U', row-1, column );
            }
            // if we are at a cell and want to go left col and row-1  
            if (column > 0) // left
            {
                PrintPathRestrictionAllDirectionHelper(maze, processed + 'L', row, column - 1);
            }

            // here all the function are executed and before returning and removing from stack reverse the change we 
            // broght to the cell 
            maze[row,column] = true;
        }

        // Function to count the number of paths in a maze
        public int CountPathsAllDirections2(bool[,] maze, int row, int column)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            // Creating a visited array to keep track of visited cells
            bool[,] visited = new bool[rows, cols];

            // Starting the path count from the top-left corner of the maze
            return CountPathsHelperAllDirections2(maze, visited, 0, 0);
        }

        private int CountPathsHelperAllDirections2(bool[,] maze, bool[,] visited, int row, int col)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            // Check if the current position is out of bounds or an obstacle or already visited
            if (row < 0 || col < 0 || row >= rows || col >= cols || maze[row, col] == false || visited[row, col])
            {
                return 0;
            }

            // If the destination (bottom-right corner) is reached, return 1
            if (row == rows - 1 && col == cols - 1)
            {
                return 1;
            }

            // Mark the current cell as visited
            visited[row, col] = true;

            // Explore all four directions
            int pathCount = CountPathsHelperAllDirections2(maze, visited, row + 1, col) // Down
                        + CountPathsHelperAllDirections2(maze, visited, row - 1, col) // Up
                        + CountPathsHelperAllDirections2(maze, visited, row, col + 1) // Right
                        + CountPathsHelperAllDirections2(maze, visited, row, col - 1); // Left

            // Backtrack: unmark the current cell before returning
            visited[row, col] = false;

            return pathCount;
        }

        // Function to count the number of ways to traverse the maze
        public static int CountWays(bool[,] maze, int row, int col)
        {
            int rowCount = maze.GetLength(0);
            int colCount = maze.GetLength(1);

            // Base case: if out of bounds or at a blocked cell, return 0
            if (row < 0 || col < 0 || row >= rowCount || col >= colCount || maze[row, col] == false)
            {
                return 0;
            }

            // Destination reached (bottom-right cell)
            if (row == rowCount - 1 && col == colCount - 1)
            {
                return 1;
            }

            // Mark the cell as visited
            maze[row, col] = false;

            // Explore all four directions
            int count = CountWays(maze, row + 1, col) +  // Down
                        CountWays(maze, row, col + 1) +  // Right
                        CountWays(maze, row - 1, col) +  // Up
                        CountWays(maze, row, col - 1);   // Left

            // Backtrack and unmark the visited cell
            maze[row, col] = true;

            return count;
        }

        // Utility function to initialize and start the maze traversal
        public int StartTraversal(bool[,] maze)
        {
            return CountWays(maze, 0, 0);
        }

        // Function to count the number of ways to traverse the maze
        public static int CountWays(int[,] maze, int row, int col, bool[,] visited)
        {
            int rowCount = maze.GetLength(0);
            int colCount = maze.GetLength(1);

            // Base case: if out of bounds, at a blocked cell, or cell already visited, return 0
            if (row < 0 || col < 0 || row >= rowCount || col >= colCount || maze[row, col] == 0 || visited[row, col])
            {
                return 0;
            }

            // Destination reached (bottom-right cell)
            if (row == rowCount - 1 && col == colCount - 1)
            {
                return 1;
            }

            // Mark the cell as visited
            visited[row, col] = true;

            // Explore all four directions
            int count = CountWays(maze, row + 1, col, visited) +  // Down
                        CountWays(maze, row, col + 1, visited) +  // Right
                        CountWays(maze, row - 1, col, visited) +  // Up
                        CountWays(maze, row, col - 1, visited);   // Left

            // Backtrack and unmark the visited cell
            visited[row, col] = false;

            return count;
        }

        // Utility function to initialize and start the maze traversal
        public int StartTraversal(int[,] maze)
        {
            bool[,] visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            return CountWays(maze, 0, 0, visited);
        }
    }
}
