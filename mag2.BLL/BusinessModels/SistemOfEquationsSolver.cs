using System.Numerics;

namespace mag2.BLL.BusinessModels;

static public class SistemOfEquationsSolver
{
    public static Complex[][] MatrixCreate(int rows, int cols)
    {
        // Создаем матрицу, полностью инициализированную
        // значениями 0.0. Проверка входных параметров опущена.
        Complex[][] result = new Complex[rows][];
        for (int i = 0; i < rows; ++i)
            result[i] = new Complex[cols]; // автоинициализация в 0.0
        return result;
    }
    private static Complex[] HelperSolve(Complex[][] luMatrix, Complex[] b)
    {
        // Решаем luMatrix * x = b
        int n = luMatrix.Length;
        Complex[] x = new Complex[n];
        b.CopyTo(x, 0);
        for (int i = 1; i < n; ++i)
        {
            Complex sum = x[i];
            for (int j = 0; j < i; ++j)
                sum -= luMatrix[i][j] * x[j];
            x[i] = sum;
        }
        x[n - 1] /= luMatrix[n - 1][n - 1];
        for (int i = n - 2; i >= 0; --i)
        {
            Complex sum = x[i];
            for (int j = i + 1; j < n; ++j)
                sum -= luMatrix[i][j] * x[j];
            x[i] = sum / luMatrix[i][i];
        }
        return x;
    }
    private static Complex[][] MatrixDuplicate(Complex[][] matrix)
    {
        // Предполагается, что матрица не нулевая
        Complex[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
        for (int i = 0; i < matrix.Length; ++i) // Копирование значений
            for (int j = 0; j < matrix[i].Length; ++j)
                result[i][j] = matrix[i][j];
        return result;
    }
    private static Complex[][] MatrixDecompose(Complex[][] matrix, out int[] perm, out int toggle)
    {
        // Разложение LUP Дулитла. Предполагается,
        // что матрица квадратная.
        int n = matrix.Length; // для удобства
        Complex[][] result = MatrixDuplicate(matrix);
        perm = new int[n];
        for (int i = 0; i < n; ++i) { perm[i] = i; }
        toggle = 1;
        for (int j = 0; j < n - 1; ++j) // каждый столбец
        {
            Complex colMax = Math.Abs(result[j][j].Magnitude); // Наибольшее значение в столбце j
            int pRow = j;
            for (int i = j + 1; i < n; ++i)
            {
                if (result[i][j].Magnitude > colMax.Magnitude)
                {
                    colMax = result[i][j];
                    pRow = i;
                }
            }
            if (pRow != j) // перестановка строк
            {
                Complex[] rowPtr = result[pRow];
                result[pRow] = result[j];
                result[j] = rowPtr;
                int tmp = perm[pRow]; // Меняем информацию о перестановке
                perm[pRow] = perm[j];
                perm[j] = tmp;
                toggle = -toggle; // переключатель перестановки строк
            }
            if (Math.Abs(result[j][j].Magnitude) < 1.0E-20)
                throw new Exception("Где то возник ноль!");
            for (int i = j + 1; i < n; ++i)
            {
                result[i][j] /= result[j][j];
                for (int k = j + 1; k < n; ++k)
                    result[i][k] -= result[i][j] * result[j][k];
            }
        } // основной цикл по столбцу j
        return result;
    }
    public static Complex[] SystemSolve(Complex[][] A, Complex[] b)
    {
        // Решаем Ax = b
        int n = A.Length;
        int[] perm;
        int toggle;
        Complex[][] luMatrix = MatrixDecompose(A, out perm, out toggle);
        if (luMatrix == null)
            throw new Exception("Где то возник ноль!");// или исключение
        Complex[] bp = new Complex[b.Length];
        for (int i = 0; i < n; ++i)
            bp[i] = b[perm[i]];
        Complex[] x = HelperSolve(luMatrix, bp);
        return x;
    }
}
