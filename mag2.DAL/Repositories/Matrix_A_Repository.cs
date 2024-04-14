using mag2.DAL.EF;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;

namespace mag2.DAL.Repositories;

public class Matrix_A_Repository : IRepository<Matrix_A>
{
    private TaskContext db;
    public Matrix_A_Repository(TaskContext context)
    {
        this.db = context;
    }
    public IEnumerable<Matrix_A> GetAll()
    {
        return db.Marix_A_Values;
    }
    public async Task<Matrix_A> Get(int id)
    {
        Matrix_A? tempMatrix_A = await db.Marix_A_Values.FindAsync(id);
        return tempMatrix_A!;
    }
    public async Task Create(Matrix_A matrix)
    {
        await db.Marix_A_Values.AddAsync(matrix);
    }
    public void Update(Matrix_A matrix)
    {
        db.Marix_A_Values.Update(matrix);
    }
    public void Delete(int id)
    {
        Matrix_A matrix = db.Marix_A_Values.Find(id)!;
        if (matrix != null)
            db.Marix_A_Values.Remove(matrix);
    }
    public void DeleteAll()
    {
        IEnumerable<Matrix_A> matrix_A = db.Marix_A_Values;
        foreach (Matrix_A ma in matrix_A)
        {
            db.Marix_A_Values.Remove(ma);
        }
    }
}
