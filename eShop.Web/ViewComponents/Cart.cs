using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eShop.Web.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private IOrderApplicationService _IOrderApplicationService;

        public CartViewComponent(IOrderApplicationService IOrderApplicationService)
        {
            _IOrderApplicationService = IOrderApplicationService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Guid UserId = new Guid("C14B6E6F-4F27-4B6A-BE74-03D279AAEABF");
            var productCount = _IOrderApplicationService.GetCartCount(UserId);
            return await Task.FromResult((IViewComponentResult)View("CartBadge", productCount));
        }
    }
}
