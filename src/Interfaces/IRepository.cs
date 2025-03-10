namespace DIO.Media.src.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> List();
        Task<T?> FindById(int id);
        Task Insert(T entity);
        Task Delete(int id);
        Task Update(int id, T entity);
    }
}