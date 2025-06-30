using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    public EfProductDal(SignalRContext contex) : base(contex)
    {
    }

    public List<Product> GetAllProductsWithCategory()
    {
        var context = new SignalRContext();
        var values=context.Products.Include(x=>x.Category).ToList();
        return values;
    }
}
