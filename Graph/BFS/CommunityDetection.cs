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
         
            int communities = 0;

            HashSet<string> vertices = new HashSet<string>();

            foreach(var u in edges)
            {
                vertices.Add(u.Key);
                vertices.Add(u.Value);

            }

            Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>(vertices.Count);
            Dictionary<string, int> color = new Dictionary<string, int>(vertices.Count);

            foreach(var u in vertices)
            {
                adj[u] = new List<string>();
                color[u] = 0;
            }

            foreach(var u in edges)
            {
                string key = u.Key;
                string value = u.Value;
                adj[key].Add(value);
                adj[value].Add(key);
            }

            foreach(var v in vertices)
            {
                if (color[v] == 0)
                {
                    communities++;
                    color[v] = 1;
                    BFS_Visit(v, adj, ref color);
                }
            }

            return communities;
        }

        public static void BFS_Visit(string start, Dictionary<string,List<string>>adj,ref Dictionary<string,int>color)
        {
            // white 0 , gray 1 , black 2

            Queue<string> Q = new Queue<string>();            
            Q.Enqueue(start);
            while (Q.Count != 0)
            {
                string U = Q.Dequeue();
                foreach(var neb in adj[U])
                {
                    if (color[neb] == 0)
                    {
                        color[neb] = 1;
                        Q.Enqueue(neb);
                    }
                }
                color[U] = 2;
            }
        }
        #endregion
    }
}

