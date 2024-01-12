using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class Practice
    {
        HashSet<int> set;
        public Practice()
        {
            set = new HashSet<int>();
        }
        public void insert(int data)
        {
            set.Add(data);
        }
        public void remove(int data)
        {
            set.Remove(data);
        }
        public int getData()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, set.Count);
            return getElementAtIndex(set, index);

        }
        private int getElementAtIndex(HashSet<int> set, int index)
        {
            int curIndex = 0; 
            foreach (int item in set)
            {
                if(curIndex == index)
                {
                    return item;
                }
                curIndex++;
            }
            return -1; 
        }
        public void print() 
        {
            foreach(int item in set)
            {
                System.Console.Write(item + " ");
            }
        }

    }
}
