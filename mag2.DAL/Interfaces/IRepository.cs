namespace mag2.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    Task<T> Get(int id);
    Task Create(T item);
    void Update(T item);
    void Delete(int id);
    void DeleteAll();
}
