using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
{
    public EfNotificationDal(SignalRContext contex) : base(contex)
    {
    }

    public List<Notification> GetAllNotificationByFalse()
    {
        var context = new SignalRContext();
        return context.Notifications.Where(x=>x.Status == false).ToList();
    }

    public int GetNotificationCountByStatusFalse()
    {
        var context = new SignalRContext();
        return context.Notifications.Where(x=>x.Status == false).Count();
    }
}
