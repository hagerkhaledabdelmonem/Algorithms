using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Problem
{
    public static class PresentBaskets
    {
        #region YOUR CODE IS HERE
        /// <summary>
        /// fill the 2 baskets with the most expensive collection of fruits.
        /// </summary>
        /// <param name="W1">weight of 1st basket</param>
        /// <param name="W2">weight of 2nd basket</param>
        /// <param name="items">Pair of weight (Key) & cost (Value) of each item</param>
        /// <returns>max total cost to fill two baskets</returns>


        static public double PreparePresentBaskets(int W1, int W2, KeyValuePair<int, int>[] items)
        {
            int length_item = items.Length;

            List<KeyValuePair<KeyValuePair<int, int>, double>> costperuint = new List<KeyValuePair<KeyValuePair<int, int>, double>>();

            int TotalWeight = W1 + W2;
            double maxtotalcost = 0;
            int k = 0;

            while (k < length_item)
            {
                if ((items[k].Key != 0) && (items[k].Value != 0))
                {
                    KeyValuePair<int, int> key_item = new KeyValuePair<int, int>(items[k].Key, items[k].Value);
                    costperuint.Add(new KeyValuePair<KeyValuePair<int, int>, double>(key_item, items[k].Value / Convert.ToDouble(items[k].Key)));
                }
                k++;
            }

            foreach (KeyValuePair<KeyValuePair<int, int>, double> v in costperuint.OrderByDescending(cpr => cpr.Value))
            {
                if (TotalWeight > 0)
                {
                    if (v.Key.Key <= TotalWeight)
                    {
                        TotalWeight -= v.Key.Key;
                        maxtotalcost += v.Key.Value;
                    }
                    else
                    {
                        maxtotalcost += v.Value * TotalWeight;
                        TotalWeight = 0;
                        break;
                    }
                }
            }

            return maxtotalcost;
        }

        #endregion
    }
}
