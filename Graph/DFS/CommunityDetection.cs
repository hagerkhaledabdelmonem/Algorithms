using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class CommunityDetection
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given an UNDIRECTED Graph with relations between different subjects, count the number of different communities 
        /// </summary>
        /// <param name="edges">array of relation-edges in the graph</param>
        /// <returns>number of different communities in the Graph</returns>
        public static int CountCommunities(KeyValuePair<string, string>[] edges)
        {
            //REMOVE THIS LINE BEFORE START CODING

            int communities = 0;
            HashSet<string> vertics = new HashSet<string>();

            foreach (KeyValuePair<string, string> u in edges)
            {
                
                    vertics.Add(u.Key);
                    vertics.Add(u.Value);

            }
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>(vertics.Count);
            Dictionary<string, int> color = new Dictionary<string, int>(vertics.Count);


           foreach(var u in vertics) 
           {
                dic[u] = new List<string>();
                color[u] = 0;

           }
            for (int i = 0; i < edges.Length; i++)
            {
                string key = edges[i].Key;
                string value = edges[i].Value;
                dic[key].Add(value);
                dic[value].Add(key);
            }
            
            foreach (var u in vertics)
            {

                if (color[u] == 0)
                {
                    communities++;
                    color[u] = 1;
                    dfs_visit(u, dic, ref color);
                }
            }

            return communities;
        }

        public static void dfs_visit(string v, Dictionary<string, List<string>> dic, ref Dictionary<string, int> color)
        {
            color[v] = 1;    
            
            // white 0 , gray 1 , black 2

            List<string> edge = new List<string>();
            edge = dic[v];
            for (int i = 0; i < edge.Count; i++)
            {
                if (color[edge[i]] == 0)
                {
                    dfs_visit(edge[i], dic, ref color);
                }
            }
            color[v] = 2;

        }

        #endregion
    }
}
