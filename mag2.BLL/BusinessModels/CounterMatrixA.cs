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
        for (int j = 0; j < N; j++)
        {
            for (int k = 0; k < N; k++) 
            {
                realPart = Math.Cos(2 * Math.PI * j * k / N);
                imagPart = Math.Sin(2 * Math.PI * j * k / N);
                matrixElements.Add(new Complex(realPart, imagPart));
            }
        }
        return matrixElements;
    }
}
