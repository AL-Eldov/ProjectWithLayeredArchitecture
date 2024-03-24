using AutoMapper;
using mag2.BLL.DTO;
using mag2.BLL.Interfaces;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;

namespace mag2.BLL.Services;

public class Vector_f_ActionService : IActionService<Vector_f_DTO>
{
    private IUnitOfWork db;
    public Vector_f_ActionService(IUnitOfWork db)
    {
        this.db = db;
    }
    public IEnumerable<Vector_f_DTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_f, Vector_f_DTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Vector_f>, List<Vector_f_DTO>>(db.Vector_f_Values.GetAll());
    }
    public Vector_f_DTO Get(int id)
    {
        var vector_f = db.Vector_f_Values.Get(id);
        return new Vector_f_DTO { Id = vector_f.Id, RealPart = vector_f.RealPart, ImaginaryPart = vector_f.ImaginaryPart };
    }
    public void Create(Vector_f_DTO item)
    {
        db.Vector_f_Values.Create(new Vector_f {  RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart });
        db.Save();
    }
    public void CreateWithoutSave(Vector_f_DTO item)
    {
        db.Vector_f_Values.Create(new Vector_f { RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart });
    }
    public void Update(Vector_f_DTO item)
    {
        Vector_f? observVector_f = db.Vector_f_Values.GetAll().FirstOrDefault(x => x.Id == item.Id);
        if (observVector_f != null) 
        {
            observVector_f.RealPart = item.RealPart;
            observVector_f.ImaginaryPart = item.ImaginaryPart;
            db.Vector_f_Values.Update(observVector_f);
            db.Save();
        }
    }
    public void Delete(int id)
    {
        db.Vector_f_Values.Delete(id);
        db.Save();
    }
    public void DeleteAll()
    {
        db.Vector_f_Values.DeleteAll();
    }
}
