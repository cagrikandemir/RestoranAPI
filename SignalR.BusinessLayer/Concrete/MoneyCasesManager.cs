using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class MoneyCasesManager : IMoneyCasesService
{
    private readonly IMoneyCasesDal _moneyCasesDal;

    public MoneyCasesManager(IMoneyCasesDal moneyCasesDal)
    {
        _moneyCasesDal = moneyCasesDal;
    }

    public void TAdd(MoneyCase entity)
    {
        _moneyCasesDal.Add(entity);
    }

    public void TDelete(MoneyCase entity)
    {
        _moneyCasesDal.Delete(entity);
    }

    public List<MoneyCase> TGetAllList()
    {
        return _moneyCasesDal.GetAllList();
    }

    public MoneyCase TGetById(int Id)
    {
        return _moneyCasesDal.GetById(Id);
    }

    public decimal TGetTotalMoneyCases()
    {
        return _moneyCasesDal.GetTotalMoneyCases();
    }

    public void TUpdate(MoneyCase entity)
    {
        _moneyCasesDal.Update(entity);
    }
}
