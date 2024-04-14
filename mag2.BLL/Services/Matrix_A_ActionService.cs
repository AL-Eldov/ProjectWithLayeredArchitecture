using AutoMapper;
using mag2.BLL.DTO;
using mag2.BLL.Interfaces;
using mag2.DAL.Entities;
using mag2.DAL.Interfaces;


namespace mag2.BLL.Services;

internal class Matrix_A_ActionService : IActionService<Matrix_A_DTO>
{
    private IUnitOfWork db;
    public Matrix_A_ActionService(IUnitOfWork db)
    {
        this.db = db;
    }
    public IEnumerable<Matrix_A_DTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Matrix_A, Matrix_A_DTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Matrix_A>, List<Matrix_A_DTO>>(db.Matrix_A_Values.GetAll());
    }
    public async Task<Matrix_A_DTO> Get(int id)
    {
        var matrix_A = await db.Matrix_A_Values.Get(id);
        return new Matrix_A_DTO { Id = matrix_A.Id, RealPart = matrix_A.RealPart, ImaginaryPart = matrix_A.ImaginaryPart, Column = matrix_A.Column, Row = matrix_A.Row };
    }
    public async Task Create(Matrix_A_DTO item)
    {
        await db.Matrix_A_Values.Create(new Matrix_A { RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart, Column = item.Column, Row = item.Row });
        await db.Save();
    }
    public async Task CreateWithoutSave(Matrix_A_DTO item)
    {
        await db.Matrix_A_Values.Create(new Matrix_A { RealPart = item.RealPart, ImaginaryPart = item.ImaginaryPart, Column = item.Column, Row = item.Row });
    }
    public async Task Update(Matrix_A_DTO item)
    {
        Matrix_A? observMatrix_A = await db.Matrix_A_Values.Get(item.Id);// GetAll().FirstOrDefault(x => x.Id == item.Id);
        if (observMatrix_A != null)
        {
            observMatrix_A.RealPart = item.RealPart;
            observMatrix_A.ImaginaryPart = item.ImaginaryPart;
            db.Matrix_A_Values.Update(observMatrix_A);
            await db.Save();
        }
    }
    public async Task Delete(int id)
    {
        db.Matrix_A_Values.Delete(id);
        await db.Save();
    }
    public void DeleteAll()
    {
        db.Matrix_A_Values.DeleteAll();
    }
}
