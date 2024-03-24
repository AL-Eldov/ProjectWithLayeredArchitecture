using mag2.BLL.DTO;
using mag2.BLL.Interfaces;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;

namespace mag2.BLL.Services;

public class TaskService : ITaskService
{
    IUnitOfWork db;
    private Vector_c_ActionService? vector_c_DTO_Values;
    private Vector_f_ActionService? vector_f_DTO_Values;
    private Matrix_A_ActionService? matrix_A_DTO_Values;
    private Vector_c_new_ActionService? vector_c_new_DTO_Values;
    private Vector_f_new_ActionService? vector_f_new_DTO_Values;
    public TaskService(IUnitOfWork uow)
    {
        db = uow;
    }
    public IActionService<Vector_c_DTO> Vector_c_DTO_Values
    {
        get
        {
            if (vector_c_DTO_Values == null)
                vector_c_DTO_Values = new Vector_c_ActionService(db);
            return vector_c_DTO_Values;
        }
    }
    public IActionService<Vector_f_DTO> Vector_f_DTO_Values
    {
        get
        {
            if (vector_f_DTO_Values == null)
                vector_f_DTO_Values = new Vector_f_ActionService(db);
            return vector_f_DTO_Values;
        }
    }
    public IActionService<Matrix_A_DTO> Matrix_A_DTO_Values
    {
        get
        {
            if (matrix_A_DTO_Values == null)
                matrix_A_DTO_Values = new Matrix_A_ActionService(db);
            return matrix_A_DTO_Values;
        }
    }
    public IActionService<Vector_c_new_DTO> Vector_c_new_DTO_Values
    {
        get
        {
            if (vector_c_new_DTO_Values == null)
                vector_c_new_DTO_Values = new Vector_c_new_ActionService(db);
            return vector_c_new_DTO_Values;
        }
    }
    public IActionService<Vector_f_new_DTO> Vector_f_new_DTO_Values
    {
        get
        {
            if (vector_f_new_DTO_Values == null)
                vector_f_new_DTO_Values = new Vector_f_new_ActionService(db);
            return vector_f_new_DTO_Values;
        }
    }
    public void DeleteAll()
    {
        /*List<Vector_c> vector_c = db.Vector_c_Values.GetAll().ToList();
        foreach (Vector_c c in vector_c)
        {
            db.Vector_c_Values.Delete(c.Id);
        }
        List<Vector_c_new> vector_c_new = db.Vector_c_new_Values.GetAll().ToList();
        foreach (Vector_c_new c in vector_c_new)
        {
            db.Vector_c_new_Values.Delete(c.Id);
        }
        List<Vector_f> vector_f = db.Vector_f_Values.GetAll().ToList();
        foreach (Vector_f f in vector_f)
        {
            db.Vector_f_Values.Delete(f.Id);
        }
        List<Vector_f_new> vector_f_new = db.Vector_f_new_Values.GetAll().ToList();
        foreach (Vector_f_new f in vector_f_new)
        {
            db.Vector_f_new_Values.Delete(f.Id);
        }
        List<Matrix_A> matrix_A = db.Matrix_A_Values.GetAll().ToList();
        foreach (Matrix_A A in matrix_A)
        {
            db.Matrix_A_Values.Delete(A.Id);
        }
        db.Save();*/
        db.DeleteDB();
    }
    public void Save()
    {
        db.Save();
    }
    public void Dispose()
    {
        db.Dispose();
    }
}
