using mag2.DAL.EF;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace mag2.DAL.Repositories;

public class EFUnitOfWork : IUnitOfWork
{
    private TaskContext db;
    private Vector_c_Repository? vector_c_Repository;
    private Vector_f_Repository? vector_f_Repository;
    private Matrix_A_Repository? matrix_A_Repository;
    private Vector_c_new_Repository? vector_c_new_Repository;
    private Vector_f_new_Repository? vector_f_new_Repository;
    public EFUnitOfWork(DbContextOptions<TaskContext> options)
    {
        db = new TaskContext(options);
    }
    public IRepository<Vector_c> Vector_c_Values
    {
        get
        {
            if (vector_c_Repository == null)
                vector_c_Repository = new Vector_c_Repository(db);
            return vector_c_Repository;
        }
    }
    public IRepository<Vector_f> Vector_f_Values
    {
        get
        {
            if (vector_f_Repository == null)
                vector_f_Repository = new Vector_f_Repository(db);
            return vector_f_Repository;
        }
    }
    public IRepository<Matrix_A> Matrix_A_Values
    {
        get
        {
            if (matrix_A_Repository == null)
                matrix_A_Repository = new Matrix_A_Repository(db);
            return matrix_A_Repository;
        }
    }
    public IRepository<Vector_c_new> Vector_c_new_Values
    {
        get
        {
            if (vector_c_new_Repository == null)
                vector_c_new_Repository = new Vector_c_new_Repository(db);
            return vector_c_new_Repository;
        }
    }
    public IRepository<Vector_f_new> Vector_f_new_Values
    {
        get
        {
            if (vector_f_new_Repository == null)
                vector_f_new_Repository = new Vector_f_new_Repository(db);
            return vector_f_new_Repository;
        }
    }
    public async Task Save()
    {
        await db.SaveChangesAsync();
    }
    private bool disposed = false;
    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }
            this.disposed = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public void DeleteDB()
    {
        db.DeleteDB();
    }
}
