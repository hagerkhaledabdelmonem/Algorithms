using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class MatrixMultiplication
    {
        #region YOUR CODE IS HERE

        //Your Code is Here:
        //==================
        /// <summary>
        /// Multiply 2 square matrices in an efficient way [Strassen's Method]
        /// </summary>
        /// <param name="M1">First square matrix</param>
        /// <param name="M2">Second square matrix</param>
        /// <param name="N">Dimension (power of 2)</param>
        /// <returns>Resulting square matrix</returns>

        static public int[,] MatrixMultiply(int[,] M1, int[,] M2, int N)
        {
          
            int[,] result = new int[N, N];

            if (N > 64)
            {

                int mid = N / 2;

                // Quarters of M1
                int[,] M1_Q1A = new int[mid, mid];
                int[,] M1_Q2B = new int[mid, mid];
                int[,] M1_Q3C = new int[mid, mid];
                int[,] M1_Q4D = new int[mid, mid];

                // Quarters of M2
                int[,] M2_Q1E = new int[mid, mid];
                int[,] M2_Q2F = new int[mid, mid];
                int[,] M2_Q3G = new int[mid, mid];
                int[,] M2_Q4H = new int[mid, mid];


                for (int i = 0; i < mid; i++)

                {
                    for (int j = 0; j < mid; j++)

                    {
                        // Filling Quarters of M1
                        M1_Q1A[i, j] = M1[i, j];
                        M1_Q2B[i, j] = M1[i, j + mid];
                        M1_Q3C[i, j] = M1[i + mid, j];
                        M1_Q4D[i, j] = M1[i + mid, j + mid];


                        // Filling Quarters of M2
                        M2_Q1E[i, j] = M2[i, j];
                        M2_Q2F[i, j] = M2[i, j + mid];
                        M2_Q3G[i, j] = M2[i + mid, j];
                        M2_Q4H[i, j] = M2[i + mid, j + mid];

                    }
                }


                int[,] P1 = new int[mid, mid];
                int[,] P2 = new int[mid, mid];
                int[,] P3 = new int[mid, mid];
                int[,] P4 = new int[mid, mid];
                int[,] P5 = new int[mid, mid];
                int[,] P6 = new int[mid, mid];
                int[,] P7 = new int[mid, mid];


                Parallel.Invoke(
                () =>
                {
                    P1 = MatrixMultiply(M1_Q1A, MatrixOperation(M2_Q2F, M2_Q4H, mid, 0), mid);
                    P7 = MatrixMultiply(MatrixOperation(M1_Q1A, M1_Q3C, mid, 0), MatrixOperation(M2_Q1E, M2_Q2F, mid, 1), mid);
                },
                () =>
                {
                    P3 = MatrixMultiply(MatrixOperation(M1_Q3C, M1_Q4D, mid, 1), M2_Q1E, mid);
                    P6 = MatrixMultiply(MatrixOperation(M1_Q2B, M1_Q4D, mid, 0), MatrixOperation(M2_Q3G, M2_Q4H, mid, 1), mid);
                },

                () =>
                {
                    P4 = MatrixMultiply(M1_Q4D, MatrixOperation(M2_Q3G, M2_Q1E, mid, 0), mid);
                    P5 = MatrixMultiply(MatrixOperation(M1_Q1A, M1_Q4D, mid, 1), MatrixOperation(M2_Q1E, M2_Q4H, mid, 1), mid);
                },
                () =>
                {
                    P2 = MatrixMultiply(MatrixOperation(M1_Q1A, M1_Q2B, mid, 1), M2_Q4H, mid);
                });

                int[,] R = MatrixOperation(MatrixOperation(MatrixOperation(P5, P4, mid, 1), P2, mid, 0), P6, mid, 1);
                int[,] S = MatrixOperation(P1, P2, mid, 1);
                int[,] T = MatrixOperation(P3, P4, mid, 1);
                int[,] U = MatrixOperation(MatrixOperation(MatrixOperation(P5, P1, mid, 1), P3, mid, 0), P7, mid, 0);

                for (int i = 0; i < mid; i++)
                {
                    for (int j = 0; j < mid; j++)
                    {
                        // Filling Quarters of Result
                        result[i, j] += R[i, j];
                        result[i, j + mid] += S[i, j];
                        result[i + mid, j] += T[i, j];
                        result[i + mid, j + mid] += U[i, j];

                    }
                }
            }
            else
            {
                int i, j, k;
                for (i = 0; i < N; i++)
                {
                    for (k = 0; k < N; k++)
                    {
                        for (j = 0; j < N; j++)

                        {
                            result[i, j] += M1[i, k] * M2[k, j];
                        }
                    }
                }
            }

            return result;

        }


        static public int[,] MatrixOperation(int[,] M1, int[,] M2, int N, int opertion)
        {

            int[,] result = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (opertion == 0)
                        result[i, j] = M1[i, j] - M2[i, j];
                    else
                        result[i, j] = M1[i, j] + M2[i, j];

                }
            }

            return result;
        }


        #endregion
    }
}
