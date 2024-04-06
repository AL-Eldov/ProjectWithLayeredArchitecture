using System.Numerics;

namespace mag2.BLL.BusinessModels;

static public class InverseDiscreteFourierTransform
{
    public static Complex[] SystemSolve(Complex[][] A, Complex[] f)
    {
        int N = A.Length;
        Complex[] result = new Complex[N];
        Complex tempSum = new Complex(0, 0);
        for (int k = 0; k < N; k++)
        {
            for (int j = 0; j < N; j++)
            {
                tempSum = tempSum + f[j] * (1 / A[j][k]);
            }
            result[k] = (1.0 / N) * tempSum;
            tempSum = new Complex(0, 0);
        }
        return result;
    }
}

/*
    public static Complex[] FastSystemSolve(Complex[][] A, Complex[] f)
    {
        int N = A.Length;
        Complex[] result = new Complex[N];
        Complex tempSum = new Complex(0, 0);



        return result;
    }
 */
