using mag2.DAL.EF;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;


namespace mag2.DAL.Repositories;

public class Vector_f_Repository : IRepository<Vector_f>
{
    private TaskContext db;
    public Vector_f_Repository(TaskContext context)
    {
        this.db = context;
    }
    public IEnumerable<Vector_f> GetAll()
    {
        return db.Vector_f_Values;
    }
    public Vector_f Get(int id)
    {
        return db.Vector_f_Values.Find(id)!;
    }
    public void Create(Vector_f f)
    {
        db.Vector_f_Values.Add(f);
    }
    public void Update(Vector_f f)
    {
        db.Vector_f_Values.Update(f);
    }
    public void Delete(int id)
    {
        Vector_f f = db.Vector_f_Values.Find(id)!;
        if (f != null)
            db.Vector_f_Values.Remove(f);
    }
    public void DeleteAll()
    {
        IEnumerable<Vector_f> vector_f = db.Vector_f_Values;
        foreach (Vector_f vf in vector_f)
        {
            db.Vector_f_Values.Remove(vf);
        }
    }
}
