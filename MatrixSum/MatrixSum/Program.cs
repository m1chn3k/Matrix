using System;

public partial class Program
{
    static void Main()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},
            {10, 11, 12}
        };

        int sum = MatrixSummator.ForkJoinSum(matrix);
        Console.WriteLine($"Total sum of matrix elements is {sum}");
    }
}
