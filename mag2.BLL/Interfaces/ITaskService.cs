using mag2.BLL.DTO;

namespace mag2.BLL.Interfaces;

public interface ITaskService
{
    IActionService<Vector_f_DTO> Vector_f_DTO_Values { get; }
    IActionService<Vector_c_DTO> Vector_c_DTO_Values { get; }
    IActionService<Matrix_A_DTO> Matrix_A_DTO_Values { get; }
    IActionService<Vector_c_new_DTO> Vector_c_new_DTO_Values { get; }
    IActionService<Vector_f_new_DTO> Vector_f_new_DTO_Values { get; }
    void Dispose();
    void DeleteAll();
    void Save();
}
