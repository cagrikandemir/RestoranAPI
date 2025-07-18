﻿using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract;

public interface INotificationDal : IGenericDal<Notification>
{
    int GetNotificationCountByStatusFalse();
    List<Notification> GetAllNotificationByFalse();
}
