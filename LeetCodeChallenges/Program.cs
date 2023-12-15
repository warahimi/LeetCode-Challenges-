using System;

namespace LeetCodeChallenges
{

    internal class Program
    {
        static void Main(string[] args)
        {

            // Sorting Dictionary Elements 
            Dictionary<int, int> d = new Dictionary<int, int>
            {
                {1, 5},
                {2, 3},
                {3, 1},
                {4, 4},
                {5, 2}
            };

            // Sort by values in ascending order
            var sortedAscending = d.OrderBy(pair => pair.Value);

            // Sort by values in descending order
            var sortedDescending = d.OrderByDescending(pair => pair.Value);

            Console.WriteLine("Ascending order:");
            foreach (var kvp in sortedAscending)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\nDescending order:");
            foreach (var kvp in sortedDescending)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            // Take the top 3 elements
            var top3Elements = sortedDescending.Take(3);

            Console.WriteLine("Top 3 elements in descending order:");
            foreach (var kvp in top3Elements)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
    }
}