using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib_5
{
    public static class Lib5
    {
        public static void func(int[,] matrix, out int count3)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);
            HashSet<int> firstRow = new HashSet<int>();
            for (int j = 0; j < N; j++)
            {
                firstRow.Add(matrix[0, j]);
            }

            int count = 0;
            for (int i = 1; i < M; i++)
            {
                HashSet<int> currentRow = new HashSet<int>();
                for (int j = 0; j < N; j++)
                {
                    currentRow.Add(matrix[i, j]);
                }
                if (currentRow.SetEquals(firstRow))
                {
                    count++;
                }
            }
            count3 = count;
        }
    }
}

