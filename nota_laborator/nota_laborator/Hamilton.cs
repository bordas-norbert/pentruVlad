using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nota_laborator
{
    internal class Hamilton
    {
        static int n;
        static int[] path;
        static int[] path2;
        static int [,]mat;
        public List<int> getPath { get {return path2.ToList(); }}
        public Hamilton(Graf graf) 
        {
            n = graf.N;
            mat = graf.M;
            path2 = hamCycle(mat);
        }
        
        bool isSafe(int v, int[,] mat, int[] path, int pos)
        {

            if (mat[path[pos - 1], v] == 0)
                return false;

            for (int i = 0; i < pos; i++)
                if (path[i] == v)
                    return false;

            return true;
        }

        bool hamCycleUtil(int[,] mat, int[] path, int pos)
        {
            if (pos == n)
            {
                if (mat[path[pos - 1], path[0]] == 1)
                    return true;
                else
                    return false;
            }

            for (int v = 1; v < n; v++)
            {

                if (isSafe(v, mat, path, pos))
                {
                    path[pos] = v;

                    if (hamCycleUtil(mat, path, pos + 1) == true)
                        return true;

                    path[pos] = -1;
                }
            }


            return false;
        }

        public int[] hamCycle(int[,] mat)
        {
            path = new int[n];
            for (int i = 0; i < n; i++)
                path[i] = -1;

            path[0] = 0;
            if (hamCycleUtil(mat, path, 1) == false)
            {
                
                return new int[0];
            }
            return path;
            
        }

    }
}
