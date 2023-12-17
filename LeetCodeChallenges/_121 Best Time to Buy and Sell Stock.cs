using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _121_Best_Time_to_Buy_and_Sell_Stock
    {
        public int MaxProfit(int[] prices)
        {
            // Brute Force Solution 
            int profit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    if (prices[j] - prices[i] > profit)
                    {
                        profit = prices[j] - prices[i];
                    }
                }
            }
            return profit;
        }

        //Optimal
        public int MaxProfit2(int[] prices)
        {
            int maxProfit = 0;
            int buy = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < buy)
                {
                    // Update the buying price if the current price is lower
                    buy = prices[i];
                }
                else
                {
                    // Calculate profit and update maxProfit if this profit is higher
                    int curProfit = prices[i] - buy;
                    if (curProfit > maxProfit)
                    {
                        maxProfit = curProfit;
                    }
                }
            }
            return maxProfit;
        }

        public int MaxProfit3(int[] prices)
        {
            int buy = prices[0];
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < buy)
                {
                    buy = prices[i];
                }
                else
                {
                    if (prices[i] - buy > profit)
                    {
                        profit = prices[i] - buy;
                    }
                }
            }
            return profit;
        }
    }
}
