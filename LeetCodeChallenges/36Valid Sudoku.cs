using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _36Valid_Sudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            HashSet<String> seen = new HashSet<String>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        continue;
                    }
                    if (!seen.Add("Seen " + board[i][j] + " at row " + i) ||
                    !seen.Add("Seen " + board[i][j] + " at colum " + j) ||
                    !seen.Add("Seen " + board[i][j] + " at box" + i / 3 + " " + j / 3))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsValidSudoku2(char[][] board)
        {
            // Initialize dictionaries to store the numbers seen in each row, column, and block.
            var rows = new Dictionary<int, HashSet<int>>();
            var columns = new Dictionary<int, HashSet<int>>();
            var boxes = new Dictionary<int, HashSet<int>>();

            // Iterate over each cell in the 9x9 board.
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char num = board[i][j];

                    // Skip empty cells.
                    if (num == '.')
                    {
                        continue;
                    }

                    int n = (int)(num - '0'); // Convert char to int.
                    int boxIndex = (i / 3) * 3 + j / 3; // Calculate box index.

                    // Add to the rows dictionary.
                    if (!rows.ContainsKey(i))
                    {
                        rows[i] = new HashSet<int>();
                    }

                    // Add to the columns dictionary.
                    if (!columns.ContainsKey(j))
                    {
                        columns[j] = new HashSet<int>();
                    }

                    // Add to the boxes dictionary.
                    if (!boxes.ContainsKey(boxIndex))
                    {
                        boxes[boxIndex] = new HashSet<int>();
                    }

                    // Check for duplicate in the current row, column, or box.
                    if (rows[i].Contains(n) || columns[j].Contains(n) || boxes[boxIndex].Contains(n))
                    {
                        return false; // If there is a duplicate, the board is not valid.
                    }

                    // Insert the number into the appropriate sets if not already present.
                    rows[i].Add(n);
                    columns[j].Add(n);
                    boxes[boxIndex].Add(n);
                }
            }

            // If no duplicates are found in rows, columns, and boxes, the board is valid.
            return true;
        }
    }
}
