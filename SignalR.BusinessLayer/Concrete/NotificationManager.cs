using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationdal;

    public NotificationManager(INotificationDal notificationdal)
    {
        _notificationdal = notificationdal;
    }

    public void TAdd(Notification entity)
    {
        _notificationdal.Add(entity);
    }

    public void TDelete(Notification entity)
    {
        _notificationdal.Delete(entity);
    }

    public List<Notification> TGetAllList()
    {
        return _notificationdal.GetAllList();
    }

    public List<Notification> TGetAllNotificationByFalse()
    {
        return _notificationdal.GetAllNotificationByFalse();
    }

    public Notification TGetById(int Id)
    {
        return _notificationdal.GetById(Id);
    }

    public int TGetNotificationCountByStatusFalse()
    {
        return _notificationdal.GetNotificationCountByStatusFalse();
    }

    public void TNotificationStatusChangeToFalse(int id)
    {
        _notificationdal.NotificationStatusChangeToFalse(id);
    }

    public void TNotificationStatusChangeToTrue(int id)
    {
        _notificationdal.NotificationStatusChangeToTrue(id);
    }

    public void TUpdate(Notification entity)
    {
         _notificationdal.Update(entity);
    }
}
