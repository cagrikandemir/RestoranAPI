﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class OrderDetailManager : IOrderDetailService
{
    private readonly IOrderDetailDal _orderDetailDal;

    public OrderDetailManager(IOrderDetailDal orderDetailDal)
    {
        _orderDetailDal = orderDetailDal;
    }

    public void TAdd(OrderDetail entity)
    {
        _orderDetailDal.Add(entity);
    }

    public void TDelete(OrderDetail entity)
    {
        _orderDetailDal.Delete(entity);
    }

    public List<OrderDetail> TGetAllList()
    {
        return _orderDetailDal.GetAllList();
    }

    public OrderDetail TGetById(int Id)
    {
        return _orderDetailDal.GetById(Id);
    }

    public void TUpdate(OrderDetail entity)
    {
        _orderDetailDal.Update(entity);
    }
}
