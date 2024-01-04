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
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
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
        }
    }
}
