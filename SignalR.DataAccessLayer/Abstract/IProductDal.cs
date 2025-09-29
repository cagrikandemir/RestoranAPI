    using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract;

public interface IProductDal : IGenericDal<Product>
{
     List<Product> GetAllProductsWithCategory();
     int ProductCount();
    int ProductCountByCategoryNameDrink();
    int ProductCountByCategoryNameHamburger();
    decimal ProductPriceAvg();
    string ProductPriceByMax();
    string ProductPriceByMin();
    decimal ProductAvgPriceByHamburger();

    List<Product> GetLast9Products();
}
