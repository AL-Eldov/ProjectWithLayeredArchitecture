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
    public Vector_f_new Get(int id)
    {
        return db.Vector_f_new_Values.Find(id)!;
    }
    public void Create(Vector_f_new f)
    {
        db.Vector_f_new_Values.Add(f);
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
