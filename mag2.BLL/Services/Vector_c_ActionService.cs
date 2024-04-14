using AutoMapper;
using mag2.BLL.DTO;
using mag2.BLL.Interfaces;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;

namespace mag2.BLL.Services;

public class Vector_c_ActionService : IActionService<Vector_c_DTO>
{
    private IUnitOfWork db;
    public Vector_c_ActionService(IUnitOfWork db)
    {
        this.db = db;
    }
    public IEnumerable<Vector_c_DTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_c, Vector_c_DTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Vector_c>, List<Vector_c_DTO>>(db.Vector_c_Values.GetAll());
    }
    public async Task<Vector_c_DTO> Get(int id)
    {
        var vector_c = await db.Vector_c_Values.Get(id);
        return new Vector_c_DTO { Id = vector_c.Id, RealPart = vector_c.RealPart, ImaginaryPart = vector_c.ImaginaryPart };
    }
    public async Task Create(Vector_c_DTO item)
    {
        await db.Vector_c_Values.Create(new Vector_c { Id = item.Id, RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart });
        await db.Save();
    }
    public async Task CreateWithoutSave(Vector_c_DTO item)
    {
        await db.Vector_c_Values.Create(new Vector_c { Id = item.Id, RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart });
    }
    public async Task Update(Vector_c_DTO item)
    {
        Vector_c? observVector_c = db.Vector_c_Values.GetAll().FirstOrDefault(x => x.Id == item.Id);
        if (observVector_c != null)
        {
            observVector_c.RealPart = item.RealPart;
            observVector_c.ImaginaryPart = item.ImaginaryPart;
            db.Vector_c_Values.Update(observVector_c);
            await db.Save();
        }
    }
    public async Task Delete(int id)
    {
        db.Vector_c_Values.Delete(id);
        await db.Save();
    }
    public void DeleteAll()
    {
        db.Vector_c_Values.DeleteAll();
    }
}
