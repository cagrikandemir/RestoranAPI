using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
{
    public EfDiscountDal(SignalRContext contex) : base(contex)
    {
    }

    public List<Discount> GetListDiscountByTrue()
    {
        using var context = new SignalRContext();
        var values = context.Discounts.Where(x => x.Status == true
        ).ToList();
        return values;
    }

    public void StatusChangeToActive(int id)
    {
        using var context = new SignalRContext();
        var values = context.Discounts.Find(id);
        values.Status = true;
        context.SaveChanges();
    }

    public void StatusChangeToPassive(int id)
    {
        using var context = new SignalRContext();
        var values = context.Discounts.Find(id);
        values.Status = false;
        context.SaveChanges();
    }
}
