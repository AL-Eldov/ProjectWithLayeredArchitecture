using AutoMapper;
using mag2.BLL.DTO;
using mag2.BLL.Interfaces;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;

namespace mag2.BLL.Services;

public class Vector_f_new_ActionService : IActionService<Vector_f_new_DTO>
{
    private IUnitOfWork db;
    public Vector_f_new_ActionService(IUnitOfWork db)
    {
        this.db = db;
    }
    public IEnumerable<Vector_f_new_DTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_f_new, Vector_f_new_DTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Vector_f_new>, List<Vector_f_new_DTO>>(db.Vector_f_new_Values.GetAll());
    }
    public Vector_f_new_DTO Get(int id)
    {
        var vector_f_new = db.Vector_f_new_Values.Get(id);
        return new Vector_f_new_DTO { Id = vector_f_new.Id, RealPart = vector_f_new.RealPart, ImaginaryPart = vector_f_new.ImaginaryPart };
    }
    public void Create(Vector_f_new_DTO item)
    {
        db.Vector_f_new_Values.Create(new Vector_f_new { RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart });
        db.Save();
    }
    public void CreateWithoutSave(Vector_f_new_DTO item)
    {
        db.Vector_f_new_Values.Create(new Vector_f_new { RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart });
    }
    public void Update(Vector_f_new_DTO item)
    {
        Vector_f_new? observVector_f_new = db.Vector_f_new_Values.GetAll().FirstOrDefault(x => x.Id == item.Id);
        if (observVector_f_new != null)
        {
            observVector_f_new.RealPart = item.RealPart;
            observVector_f_new.ImaginaryPart = item.ImaginaryPart;
            db.Vector_f_new_Values.Update(observVector_f_new);
            db.Save();
        }
    }
    public void Delete(int id)
    {
        db.Vector_f_new_Values.Delete(id);
        db.Save();
    }
    public void DeleteAll()
    {
        db.Vector_f_new_Values.DeleteAll();
    }
}
