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

    public int ProductCount()
    {
        var context = new SignalRContext();
        return context.Products.Count();
    }

    public int ProductCountByCategoryNameDrink()
    {
        var context = new SignalRContext();
        return context.Products.Where(x=>x.CategoryId==(context.Categories.Where(y=>y.CategoryName=="İçecek")
        .Select)(z=>z.CategoryId).FirstOrDefault()).Count();
    }

    public int ProductCountByCategoryNameHamburger()
    {
        var context = new SignalRContext();
        return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburger")
        .Select)(z => z.CategoryId).FirstOrDefault()).Count();
    }

    public decimal ProductPriceAvg()
    {
        var context = new SignalRContext();
        return context.Products.Average(x => x.Price);
    }

    public string ProductPriceByMax()
    {
        var context = new SignalRContext();
        return context.Products.Where(x => x.Price == context.Products.Max(y => y.Price))
            .Select(z => z.ProductName).FirstOrDefault();
    }
    public string ProductPriceByMin()
    {
        var context = new SignalRContext();
        return context.Products.Where(x=>x.Price==context.Products.Min(y=>y.Price))
            .Select(z=>z.ProductName).FirstOrDefault();
    }
}
