using AutoMapper;
using mag2.BLL.DTO;
using mag2.BLL.Interfaces;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;

namespace mag2.BLL.Services;

public class Vector_c_new_ActionService : IActionService<Vector_c_new_DTO>
{
    private IUnitOfWork db;
    public Vector_c_new_ActionService(IUnitOfWork db)
    {
        this.db = db;
    }
    public IEnumerable<Vector_c_new_DTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_c_new, Vector_c_new_DTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Vector_c_new>, List<Vector_c_new_DTO>>(db.Vector_c_new_Values.GetAll());
    }
    public Vector_c_new_DTO Get(int id)
    {
        var vector_c_new = db.Vector_c_new_Values.Get(id);
        return new Vector_c_new_DTO { Id = vector_c_new.Id, RealPart = vector_c_new.RealPart, ImaginaryPart = vector_c_new.ImaginaryPart };
    }
    public void Create(Vector_c_new_DTO item)
    {
        db.Vector_c_new_Values.Create(new Vector_c_new { Id = item.Id, RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart });
        db.Save();
    }
    public void CreateWithoutSave(Vector_c_new_DTO item)
    {
        db.Vector_c_new_Values.Create(new Vector_c_new { Id = item.Id, RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart });
    }
    public void Update(Vector_c_new_DTO item)
    {
        Vector_c_new? observVector_c_new = db.Vector_c_new_Values.GetAll().FirstOrDefault(x => x.Id == item.Id);
        if (observVector_c_new != null)
        {
            observVector_c_new.RealPart = item.RealPart;
            observVector_c_new.ImaginaryPart = item.ImaginaryPart;
            db.Vector_c_new_Values.Update(observVector_c_new);
            db.Save();
        }
    }
    public void Delete(int id)
    {
        db.Vector_c_new_Values.Delete(id);
        db.Save();
    }
    public void DeleteAll()
    {
        db.Vector_c_new_Values.DeleteAll();
    }
}
