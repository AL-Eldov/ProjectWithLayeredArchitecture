using mag2.DAL.EF;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;

namespace mag2.DAL.Repositories;

public class Vector_f_new_Repository : IRepository<Vector_f_new>
{
    private TaskContext db;
    public Vector_f_new_Repository(TaskContext context)
    {
        this.db = context;
    }
    public IEnumerable<Vector_f_new> GetAll()
    {
        return db.Vector_f_new_Values;
    }
    public async Task<Vector_f_new> Get(int id)
    {
        Vector_f_new? tempVector_f_new = await db.Vector_f_new_Values.FindAsync(id);
        return tempVector_f_new!;
    }
    public async Task Create(Vector_f_new f)
    {
        await db.Vector_f_new_Values.AddAsync(f);
    }
    public void Update(Vector_f_new f)
    {
        db.Vector_f_new_Values.Update(f);
    }
    public void Delete(int id)
    {
        Vector_f_new f = db.Vector_f_new_Values.Find(id)!;
        if (f != null)
            db.Vector_f_new_Values.Remove(f);
    }
    public void DeleteAll()
    {
        IEnumerable<Vector_f_new> vector_f = db.Vector_f_new_Values;
        foreach (Vector_f_new vf in vector_f)
        {
            db.Vector_f_new_Values.Remove(vf);
        }
    }
}
