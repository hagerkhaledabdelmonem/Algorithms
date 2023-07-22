using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
  
    public static class ModuloSum
    {
        #region YOUR CODE IS HERE    

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// Fill this function to check whether there's a subsequence numbers in the given array that their sum is divisible by M
        /// </summary>
        /// <param name="items">array of integers</param>
        /// <param name="N">array size </param>
        /// <param name="M">value to check against it</param>
        /// <returns>true if there's subsequence with sum divisible by M... false otherwise</returns>


        static char[,] trace_dp;

        static List<int> list_of_remainder = new List<int>();

        static public bool SolveValue(int[] items, int N, int M)
        {

            bool[,] building_table = new bool[N + 1, M + 1];
            trace_dp = new char[N + 1, M + 1];

            if (N == 1)
            {
                if (items[0] % M == 0)
                {
                    building_table[N - 1, M] =true;
                    return true;
                }
                else
                {
                    building_table[N - 1, M]= false;
                    return false;
                }
            }
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    if (i == 0)
                    {
                        building_table[i, j]=false;
                    }
                    else if (j == 0)
                    {
                        building_table[i, j]=true;
                    }
                    else if (items[i - 1] <= j)

                    {
                        list_of_remainder.Add((j - items[i - 1] + M) % M);
                        bool val1 = false;
                        if (list_of_remainder.Contains((j - items[i - 1] + M) % M))
                        {
                            val1 = true;
                        }

                        if (val1 == true)
                        {
                            trace_dp[i, j] = 'C';                // C for cross 
                        }
                        else
                        {
                            trace_dp[i, j] = 'U';                // U for up 
                        }

                        bool val2 = building_table[i - 1, j];

                        building_table[i, j]=val1 || val2;
                    }
                    else
                    {
                        if (items[i - 1] % j == 0)
                        {
                            building_table[i, j]= true;

                            return building_table[i, j];
                        }
                        else
                        {
                            building_table[i, j] = building_table[i - 1, j];
                        }

                    }
                }
            }

            return building_table[N, M];

        }
        #endregion

        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>if exists, return the numbers themselves whose sum is divisible by ‘M’ else, return null</returns>

        static List<int> returned_list = new List<int>();

        static public int[] ConstructSolution(int[] items, int N, int M)
        {
          
            int[] recusive_arr;
            returned_list = new List<int>();

            if (N == 1)
            {
                if (items[0] % M != 0)
                {
                    return null;
                }
            }
            else
            {

                if (trace_dp[N, M] == 'U')                      // U for up 
                {
                    recusive_arr = ConstructSolution(items, N - 1, M);
                }
                else if (trace_dp[N, M] == 'C')                   // C for cross 
                {
                    returned_list.Add(items[N - 1]);
                    recusive_arr = ConstructSolution(items, N - 1, M - (items[N - 1] % M));
                }

                else if (items[N - 1] % M != 0)
                {
                    if (list_of_remainder.Contains(M - items[N - 1]))
                    {
                        returned_list.Add(items[N - 1]);
                        returned_list.Add(M - items[N - 1]);

                    }
                    else
                    {
                        recusive_arr = ConstructSolution(items, N - 1, M);
                    }
                }
                else if (items[N - 1] % M == 0)
                {
                    returned_list.Add(items[N - 1]);
                }
            }

            return returned_list.ToArray();

        }



        #endregion
        #endregion

    }
}
