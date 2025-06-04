using System;
using System.Threading;

public static class MatrixSummator
{
    public static int ForkJoinSum(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        if (rows == 0) return 0;

        int[] rowSums = new int[rows];
        int totalSum = 0;

        var countdown = new CountdownEvent(rows);

        for (int i = 0; i < rows; i++)
        {
            int row = i;
            new Thread(() =>
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sum += matrix[row, j];

                rowSums[row] = sum;

                countdown.Signal();
            }).Start();
        }

        countdown.Wait();

        for (int i = 0; i < rowSums.Length; i++)
            totalSum += rowSums[i];

        return totalSum;
    }
}
