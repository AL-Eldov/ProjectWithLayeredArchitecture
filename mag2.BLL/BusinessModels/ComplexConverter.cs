using mag2.BLL.DTO;
using System.Numerics;

namespace mag2.BLL.BusinessModels;

static public class ComplexConverter
{
    public static Complex[][] ConvertToMatrix(IEnumerable<Matrix_A_DTO> matrix_A_DTO, int N)
    {
        List<Matrix_A_DTO> matrix_A_DTOs = matrix_A_DTO.ToList();
        Complex[][] result = SistemOfEquationsSolver.MatrixCreate(N, N);
        for (int row = 0, i = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++, i++)
            {
                result[row][col] = new Complex(matrix_A_DTOs[i].RealPart, matrix_A_DTOs[i].ImaginaryPart);
            }
        }
        return result;
    }
    public static Complex[] ConvertToVector_f(IEnumerable<Vector_f_DTO> vector_f_DTO)
    {
        List<Vector_f_DTO> vector_f_DTOs = vector_f_DTO.ToList();
        Complex[] result = new Complex[vector_f_DTOs.Count()];
        for (int i = 0; i < vector_f_DTOs.Count(); i++)
        {
            result[i] = new Complex(vector_f_DTOs[i].RealPart, vector_f_DTOs[i].ImaginaryPart);
        }
        return result;
    }
    public static Complex[] ConvertToVector_c_new(IEnumerable<Vector_c_new_DTO> vector_c_new_DTO)
    {
        List<Vector_c_new_DTO> vector_c_new_DTOs = vector_c_new_DTO.ToList();
        Complex[] result = new Complex[vector_c_new_DTOs.Count()];
        for (int i = 0; i < vector_c_new_DTOs.Count(); i++)
        {
            result[i] = new Complex(vector_c_new_DTOs[i].RealPart, vector_c_new_DTOs[i].ImaginaryPart);
        }
        return result;
    }
}
