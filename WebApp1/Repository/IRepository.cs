namespace WebApp1.Repository
{
    public interface IRepository<T>//Interface & generic Open
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();//connect data save all chage
    }
}
