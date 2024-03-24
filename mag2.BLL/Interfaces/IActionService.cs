namespace mag2.BLL.Interfaces;

public interface IActionService<T> where T : class
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Create(T item);
    void CreateWithoutSave(T item);
    void Update(T item);
    void Delete(int id);
    void DeleteAll();
}
