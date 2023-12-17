using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _122_Best_Time_to_Buy_and_Sell_Stock_II
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++) // starting from 2nd element
            {
                if (prices[i] > prices[i - 1]) // if the curent price is bigger than its previouse we have a profit sell and get the profit.
                {
                    profit += prices[i] - prices[i - 1];
                }
            }
            return profit;
        }
    }
}
