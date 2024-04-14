using mag2.DAL.EF;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;


namespace mag2.DAL.Repositories;

public class Vector_c_Repository : IRepository<Vector_c>
{
    private TaskContext db;
    public Vector_c_Repository(TaskContext context)
    {
        this.db = context;
    }
    public IEnumerable<Vector_c> GetAll()
    {
        return db.Vector_c_Values;
    }
    public async Task<Vector_c> Get(int id)
    {
        Vector_c? tempVector_c = await db.Vector_c_Values.FindAsync(id);
        return tempVector_c!;
    }
    public async Task Create(Vector_c c)
    {
        await db.Vector_c_Values.AddAsync(c);
    }
    public void Update(Vector_c c)
    {
        db.Vector_c_Values.Update(c);
    }
    public void Delete(int id)
    {
        Vector_c c = db.Vector_c_Values.Find(id)!;
        if (c != null)
            db.Vector_c_Values.Remove(c);
    }
    public void DeleteAll()
    {
        IEnumerable<Vector_c> vector_c = db.Vector_c_Values;
        foreach (Vector_c vc in vector_c)
        {
            db.Vector_c_Values.Remove(vc);
        }
    }
}
