using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract;

public interface IMenuTableDal : IGenericDal<MenuTable>
{
    int TotalMenuTableCount();
    void ChangeMenuTableStatusToTrue(int Id);
    void ChangeMenuTableStatusToFalse(int Id);
}
