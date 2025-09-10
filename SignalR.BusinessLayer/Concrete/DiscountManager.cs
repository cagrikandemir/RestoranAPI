using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class DiscountManager : IDiscountService
{
    private readonly IDiscountDal _discountDal;

    public DiscountManager(IDiscountDal discountDal)
    {
        _discountDal = discountDal;
    }

    public void TAdd(Discount entity)
    {
        _discountDal.Add(entity);
    }

    public void TDelete(Discount entity)
    {
        _discountDal.Delete(entity);
    }

    public List<Discount> TGetAllList()
    {
        return _discountDal.GetAllList();
    }

    public Discount TGetById(int Id)
    {
        return _discountDal.GetById(Id);
    }

    public void TStatusChangeToActive(int id)
    {
        _discountDal.StatusChangeToActive(id);
    }

    public void TStatusChangeToPassive(int id)
    {
        _discountDal.StatusChangeToPassive(id);
    }

    public void TUpdate(Discount entity)
    {
        _discountDal.Update(entity);
    }
}
