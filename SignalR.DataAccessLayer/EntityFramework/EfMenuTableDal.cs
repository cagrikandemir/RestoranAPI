using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
{
    public EfMenuTableDal(SignalRContext contex) : base(contex)
    {
    }

    public int TotalMenuTableCount()
    {
        var context = new SignalRContext();
        return context.MenuTables.Count();
    }
}
