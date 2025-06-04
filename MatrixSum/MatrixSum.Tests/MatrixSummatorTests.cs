namespace MatrixSum.Tests;

public class MatrixSummatorTests
{
    [Fact]
    public void TestMatrixSum()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        int result = MatrixSummator.ForkJoinSum(matrix);

        Assert.Equal(45, result);
    }

    [Fact]
    public void TestEmptyMatrix()
    {
        int[,] matrix = new int[0, 0];
        int result = MatrixSummator.ForkJoinSum(matrix);
        Assert.Equal(0, result);
    }

    [Fact]
    public void TestSingleElement()
    {
        int[,] matrix = { { 42 } };
        int result = MatrixSummator.ForkJoinSum(matrix);
        Assert.Equal(42, result);
    }
}
