using mag2.DAL.EF;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mag2.DAL.Repositories;

public class Vector_c_new_Repository : IRepository<Vector_c_new>
{
    private TaskContext db;
    public Vector_c_new_Repository(TaskContext context)
    {
        this.db = context;
    }
    public IEnumerable<Vector_c_new> GetAll()
    {
        return db.Vector_c_new_Values;
    }
    public Vector_c_new Get(int id)
    {
        return db.Vector_c_new_Values.Find(id)!;
    }
    public void Create(Vector_c_new c)
    {
        db.Vector_c_new_Values.Add(c);
    }
    public void Update(Vector_c_new c)
    {
        db.Vector_c_new_Values.Update(c);
    }
    public void Delete(int id)
    {
        Vector_c_new c = db.Vector_c_new_Values.Find(id)!;
        if (c != null)
            db.Vector_c_new_Values.Remove(c);
    }
    public void DeleteAll()
    {
        IEnumerable<Vector_c_new> vector_c = db.Vector_c_new_Values;
        foreach(Vector_c_new vc in vector_c)
        {
            db.Vector_c_new_Values.Remove(vc);
        }
    }
}