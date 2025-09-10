using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract;

public interface IDiscountDal : IGenericDal<Discount>
{
    void StatusChangeToActive(int id);
    void StatusChangeToPassive(int id);
}
