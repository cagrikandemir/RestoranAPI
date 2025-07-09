using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public List<Product> GetAllProductsWithCategory()
    {
        return _productDal.GetAllProductsWithCategory();
    }

    public void TAdd(Product entity)
    {
        _productDal.Add(entity);
    }

    public void TDelete(Product entity)
    {
        _productDal.Delete(entity);
    }

    public List<Product> TGetAllList()
    {
        return _productDal.GetAllList();
    }

    public Product TGetById(int Id)
    {
        return _productDal.GetById(Id);
    }

    public int TProductCount()
    {
        return _productDal.ProductCount();
    }

    public void TUpdate(Product entity)
    {
        _productDal.Update(entity);
    }
}
