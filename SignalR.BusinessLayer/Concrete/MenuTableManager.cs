using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class MenuTableManager : IMenuTableService
{
    private readonly IMenuTableDal _menuTableDal;

    public MenuTableManager(IMenuTableDal menuTableDal)
    {
        _menuTableDal = menuTableDal;
    }

    public void TAdd(MenuTable entity)
    {
        _menuTableDal.Add(entity);
    }

    public void TChangeMenuTableStatusToFalse(int Id)
    {
        _menuTableDal.ChangeMenuTableStatusToFalse(Id);
    }

    public void TChangeMenuTableStatusToTrue(int Id)
    {
        _menuTableDal.ChangeMenuTableStatusToTrue(Id);
    }

    public void TDelete(MenuTable entity)
    {
        _menuTableDal.Delete(entity);
    }

    public List<MenuTable> TGetAllList()
    {
        return _menuTableDal.GetAllList();
    }

    public MenuTable TGetById(int Id)
    {
        return _menuTableDal.GetById(Id);
    }

    public int TTotalMenuTableCount()
    {
        return _menuTableDal.TotalMenuTableCount();
    }

    public void TUpdate(MenuTable entity)
    {
        _menuTableDal.Update(entity);
    }
}
