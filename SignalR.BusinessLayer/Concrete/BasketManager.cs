using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class BasketManager : IBasketService
{
    private readonly IBasketDal _basketDal;

    public BasketManager(IBasketDal basketDal)
    {
        _basketDal = basketDal;
    }

    public void TAdd(Basket entity)
    {
        _basketDal.Add(entity);
    }

    public void TDelete(Basket entity)
    {
        _basketDal.Delete(entity);
    }

    public List<Basket> TGetAllList()
    {
        return _basketDal.GetAllList();
    }

    public List<Basket> TGetBasketByMenuTableNumber(int Id)
    {
        return _basketDal.GetBasketByMenuTableNumber(Id);
    }

    public Basket TGetById(int Id)
    {
        return _basketDal.GetById(Id);
    }

    public void TUpdate(Basket entity)
    {
        _basketDal.Update(entity);
    }
}
