using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class BookingManager : IBookingService
{
    private readonly IBookingDal _bookingDal;

    public BookingManager(IBookingDal bookingDal)
    {
        _bookingDal = bookingDal;
    }

    public void TAdd(Booking entity)
    {
        _bookingDal.Add(entity);
    }

    public void TDelete(Booking entity)
    {
        _bookingDal.Delete(entity);
    }

    public List<Booking> TGetAllList()
    {
        return _bookingDal.GetAllList();
    }

    public Booking TGetById(int Id)
    {
        return _bookingDal.GetById(Id);
    }

    public void TUpdate(Booking entity)
    {
        _bookingDal.Update(entity);
    }
}
