using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class SocialMediaManager : ISocialMediaService
{
    private readonly ISocialMediaDal _socialMediaDal;

    public SocialMediaManager(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }

    public void TAdd(SocialMedia entity)
    {
        _socialMediaDal.Add(entity);
    }

    public void TDelete(SocialMedia entity)
    {
        _socialMediaDal.Delete(entity);
    }

    public List<SocialMedia> TGetAllList()
    {
        return _socialMediaDal.GetAllList();
    }

    public SocialMedia TGetById(int Id)
    {
        return _socialMediaDal.GetById(Id);
    }

    public void TUpdate(SocialMedia entity)
    {
        _socialMediaDal.Update(entity);
    }
}
