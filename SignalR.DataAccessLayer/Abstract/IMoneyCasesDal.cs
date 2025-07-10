using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract;

public interface IMoneyCasesDal : IGenericDal<MoneyCase>
{
    decimal GetTotalMoneyCases();
}
