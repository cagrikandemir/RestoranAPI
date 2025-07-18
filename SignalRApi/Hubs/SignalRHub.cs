﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCasesService _moneyCasesService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCasesService moneyCasesService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCasesService = moneyCasesService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveHamburgerProductCount", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveDrinkProductCount", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00")+ "₺");

            var value8 = _productService.TProductPriceByMax();
            await Clients.All.SendAsync("ReceiveProductPriceByMax", value8);

            var value9 = _productService.TProductPriceByMin();
            await Clients.All.SendAsync("ReceiveProductPriceByMin", value9);

            var value10 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.ToString("0.00") + "₺");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + "₺");

            var value14 = _moneyCasesService.TGetTotalMoneyCases();
            await Clients.All.SendAsync("ReceiveTotalMoneyCases", value14.ToString("0.00") + "₺");

            var value15 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value15.ToString("0.00") + "₺");

            var value16 = _menuTableService.TTotalMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);



        }


        public async Task SendProgress()
        {
            var value = _moneyCasesService.TGetTotalMoneyCases();
            await Clients.All.SendAsync("ReceiveMoneyCasesProgress", value.ToString("0.00") + "₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderProgress", value2);

            var value3=_menuTableService.TTotalMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableProgress", value3);
        }

        public async Task GetBookingList()
        {
            var values =_bookingService.TGetAllList();
            await Clients.All.SendAsync("ReceiveBookingList", values);

        }

        public async Task SendNotification()
        {
            var value = _notificationService.TGetNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);
        }

    }
}
