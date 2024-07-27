namespace LibraryTask.Interfaces
{
    public interface GenericInterface <T>
    {
        Task<List<T>> GetAll();
        Task<T> GetByID (int id);
        Task<T> Add(T item);
        Task<T> Update(T item, int id);
        Task<T> Delete(int id);
    }
}
