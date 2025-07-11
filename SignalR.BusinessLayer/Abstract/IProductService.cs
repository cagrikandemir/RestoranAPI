﻿using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract;

public interface IProductService : IGenericService<Product>
{
    List<Product> GetAllProductsWithCategory();
      int TProductCount();
    int TProductCountByCategoryNameHamburger();
    int TProductCountByCategoryNameDrink();
    decimal TProductPriceAvg();
    string TProductPriceByMax();
    string TProductPriceByMin();
    decimal TProductAvgPriceByHamburger();
}
