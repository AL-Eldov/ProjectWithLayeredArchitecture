using System.Numerics;

namespace mag2.BLL.BusinessModels;

public class CounterMatrixA
{
    public int RowNumber { private set; get; }
    public int Lengh { private set; get; }
    public IEnumerable<Complex> MatrixA { private set; get; }
    public CounterMatrixA(int N)
    {
        this.RowNumber = N + 1;
        this.Lengh = (N + 1) * (N + 1);
        MatrixA = GetMatrixA(N);
    }
    private IEnumerable<Complex> GetMatrixA(int N)
    {
        List<Complex> matrixElements = new List<Complex>();
        double realPart = 0;
        double imagPart = 0;
        for (int j = 1; j < N + 1; j++)//j = 0
        {
            for (int k = 1; k < N + 1; k++) //k = 0
            {
                realPart = Math.Sin(2 * Math.PI * j * k / N);
                imagPart = Math.Cos(2 * Math.PI * j * k / N);
                matrixElements.Add(new Complex(realPart, imagPart));
            }
        }
        return matrixElements;
    }
}
