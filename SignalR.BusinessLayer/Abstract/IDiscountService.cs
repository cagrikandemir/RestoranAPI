using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract;

public interface IDiscountService : IGenericService<Discount>
{
    void TStatusChangeToActive(int id);
    void TStatusChangeToPassive(int id);
}
