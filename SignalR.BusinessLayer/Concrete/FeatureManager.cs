using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class FeatureManager : IFeatureService
{
    private readonly IFeatureDal _featuredal;

    public FeatureManager(IFeatureDal featuredal)
    {
        _featuredal = featuredal;
    }

    public void TAdd(Feature entity)
    {
        _featuredal.Add(entity);
    }

    public void TDelete(Feature entity)
    {
        _featuredal.Delete(entity);
    }

    public List<Feature> TGetAllList()
    {
        return _featuredal.GetAllList();
    }

    public Feature TGetById(int Id)
    {
        return _featuredal.GetById(Id);
    }

    public void TUpdate(Feature entity)
    {
        _featuredal.Update(entity);
    }
}
