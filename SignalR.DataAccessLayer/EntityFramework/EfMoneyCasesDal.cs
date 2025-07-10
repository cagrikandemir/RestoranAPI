using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfMoneyCasesDal : GenericRepository<MoneyCase>, IMoneyCasesDal
{
    public EfMoneyCasesDal(SignalRContext contex) : base(contex)
    {
    }

    public decimal GetTotalMoneyCases()
    {
        var context = new SignalRContext();
        return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
    }
}
