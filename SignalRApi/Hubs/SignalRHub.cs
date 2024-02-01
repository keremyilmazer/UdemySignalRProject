using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("RecieveCategoryCount", value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("RecieveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("RecieveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("RecievePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("RecieveProductCountByCategoryNameHamburger", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("RecieveProductCountByCategoryNameDrink", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("RecieveProductPriceAvg", value7.ToString("0.00" + "₺"));

            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("RecieveProductNameByMaxPrice", value8);

            var value9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("RecieveProductNameByMinPrice", value9);

            var value10 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("RecieveProductAvgPriceByHamburger", value10.ToString("0.00" + "₺"));

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("RecieveTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("RecieveActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("RecieveLastOrderPrice", value13.ToString("0.00" + "₺"));

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("RecieveTotalMoneyCaseAmount", value14.ToString("0.00" + "₺"));

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("RecieveMenuTableCount", value16);
        }

        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("RecieveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("RecieveActiveOrderCount", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("RecieveMenuTableCount", value3);
        }

        public async Task GetBookingList()
        {
            var values =_bookingService.TGetListAll();
            await Clients.All.SendAsync("RecieveBookingList", values);
        }

        public async Task SendNotification()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("RecieveNotificationCountByFalse", values);

            var notificationListByFalse=_notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("RecieveNotificationListByFalse", notificationListByFalse);
        }
    }
}
