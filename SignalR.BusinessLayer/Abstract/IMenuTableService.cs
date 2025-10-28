using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract;

public interface IMenuTableService : IGenericService<MenuTable>
{
    int TTotalMenuTableCount();
    void TChangeMenuTableStatusToTrue(int Id);
    void TChangeMenuTableStatusToFalse(int Id);

}
