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

    public void ChangeMenuTableStatusToFalse(int Id)
    {
        var context = new SignalRContext();
        var values = context.MenuTables.Find(Id);
        values.Status = false;
        context.SaveChanges();
    }

    public void ChangeMenuTableStatusToTrue(int Id)
    {
        var context = new SignalRContext();
        var values = context.MenuTables.Find(Id);
        values.Status = true;
        context.SaveChanges();
    }

    public int TotalMenuTableCount()
    {
        var context = new SignalRContext();
        return context.MenuTables.Count();
    }
}
