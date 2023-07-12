namespace AddresBook
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Add(T item);

        bool Update(T item);

        T Delete(T item);

        T Read(int id);
    }
}
