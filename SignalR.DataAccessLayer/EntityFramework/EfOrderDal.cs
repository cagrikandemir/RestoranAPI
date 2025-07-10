using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfOrderDal : GenericRepository<Order>, IOrderDal
{
    public EfOrderDal(SignalRContext contex) : base(contex)
    {
    }

    public int ActiveOrderCount()
    {
        var context = new SignalRContext();
        return context.Orders.Where(x=>x.Description=="Müşteri Masada").Count();
    }

    public decimal LastOrderPrice()
    {
         var context = new SignalRContext();
        return context.Orders.OrderByDescending(x => x.OrderId).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
    }

    public int TotalOrderCount()
    {
        var context = new SignalRContext();
        return context.Orders.Count();
    }
}
