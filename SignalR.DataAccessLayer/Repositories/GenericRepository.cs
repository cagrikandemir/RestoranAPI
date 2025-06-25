using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.DataAccessLayer.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly SignalRContext _contex;

    public GenericRepository(SignalRContext contex)
    {
        _contex = contex;
    }

    public void Add(T entity)
    {
        _contex.Add(entity);
        _contex.SaveChanges();
    }

    public void Delete(T entity)
    {
        _contex.Remove(entity);
        _contex.SaveChanges();
    }

    public List<T> GetAllList()
    {
       return _contex.Set<T>().ToList();
    }

    public T GetById(int Id)
    {
       return _contex.Set<T>().Find(Id);
    }

    public void Update(T entity)
    {
        _contex.Update(entity);
        _contex.SaveChanges();
    }
}
