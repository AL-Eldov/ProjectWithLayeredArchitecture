using System.Numerics;

namespace mag2.BLL.BusinessModels;

public class MatrixAction
{
    static public Complex[] MatrixsProduct(Complex[][] matrixA, Complex[] matrixB)
    {
        //здесь надо бы написать проверку на формы матриц, но мне лень
        Complex[] result = new Complex[matrixB.Length];
        Complex tempVal = new Complex(0, 0);
        for (int i = 0; i < matrixA[0].Length; i++)
        {
            for (int j = 0; j < matrixA[0].Length; j++)
            {
                tempVal += matrixA[i][j] * matrixB[j];
            }
            result[i] = tempVal;
            tempVal = 0;
        }
        return result;
    }

}
