using mag2.DAL.Entities;

namespace mag2.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Vector_f> Vector_f_Values { get; }
    IRepository<Vector_c> Vector_c_Values { get; }
    IRepository<Matrix_A> Matrix_A_Values { get; }
    IRepository<Vector_c_new> Vector_c_new_Values { get; }
    IRepository<Vector_f_new> Vector_f_new_Values { get; }
    Task Save();
    void DeleteDB();
}
