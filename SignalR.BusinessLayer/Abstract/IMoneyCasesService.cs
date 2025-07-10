using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract;

public interface IMoneyCasesService : IGenericService<MoneyCase>
{
    decimal TGetTotalMoneyCases();
}
