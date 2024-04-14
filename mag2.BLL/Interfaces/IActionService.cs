namespace mag2.BLL.Interfaces;

public interface IActionService<T> where T : class
{
    IEnumerable<T> GetAll();
    Task<T> Get(int id);
    Task Create(T item);
    Task CreateWithoutSave(T item);
    Task Update(T item);
    Task Delete(int id);
    void DeleteAll();
}
