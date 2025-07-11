﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities;

public class Order
{
    public int OrderId { get; set; }
    public string TableNumber { get; set; }
    [Column (TypeName ="Date")]
    public DateTime OrderDate { get; set; }
    public string Description { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}
