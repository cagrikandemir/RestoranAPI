using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void TAdd(About entity)
    {
        _aboutDal.Add(entity);
    }

    public void TDelete(About entity)
    {
        _aboutDal.Delete(entity);
    }

    public List<About> TGetAllList()
    {
        return _aboutDal.GetAllList();
    }

    public About TGetById(int Id)
    {
        return _aboutDal.GetById(Id);
    }

    public void TUpdate(About entity)
    {
        _aboutDal.Update(entity);
    }
}
