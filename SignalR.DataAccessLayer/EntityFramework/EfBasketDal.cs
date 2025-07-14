using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfBasketDal : GenericRepository<Basket>, IBasketDal
{
    public EfBasketDal(SignalRContext contex) : base(contex)
    {
    }

    public List<Basket> GetBasketByMenuTableNumber(int Id)
    {
        var context = new SignalRContext();
        var value = context.Baskets.Where(x => x.MenuTableId == Id).Include(y=>y.Product)
            .ToList();
        return value;
    }
}
