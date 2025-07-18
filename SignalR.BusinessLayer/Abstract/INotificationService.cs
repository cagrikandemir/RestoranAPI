﻿using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract;

public interface INotificationService :IGenericService<Notification>
{
    int TGetNotificationCountByStatusFalse();
    List<Notification> TGetAllNotificationByFalse();

}
