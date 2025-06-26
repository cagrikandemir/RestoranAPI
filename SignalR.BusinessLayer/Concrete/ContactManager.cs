using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void TAdd(Contact entity)
    {
        _contactDal.Add(entity);
    }

    public void TDelete(Contact entity)
    {
        _contactDal.Delete(entity);
    }

    public List<Contact> TGetAllList()
    {
        return _contactDal.GetAllList();
    }

    public Contact TGetById(int Id)
    {
       return _contactDal.GetById(Id);
    }

    public void TUpdate(Contact entity)
    {
        _contactDal.Update(entity);
    }
}
