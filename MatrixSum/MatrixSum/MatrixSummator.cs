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

        Barrier barrier = new Barrier(rows, b =>
        {
            int sum = 0;
            for (int i = 0; i < rowSums.Length; i++)
                sum += rowSums[i];
            totalSum = sum;
        });

        for (int i = 0; i < rows; i++)
        {
            int row = i;
            new Thread(() =>
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sum += matrix[row, j];
                rowSums[row] = sum;
                barrier.SignalAndWait();
            }).Start();
        }

        // Чекаємо, поки всі потоки закінчать і totalSum оновиться
        while (totalSum == 0 && rows > 0)
            Thread.Sleep(1);

        return totalSum;
    }
}
