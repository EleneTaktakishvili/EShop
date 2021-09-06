using Microsoft.AspNetCore.Mvc;
using System;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.Web.Models;
using System.Collections.Generic;
using eShop.DataTransferObject.DTOModels;
using eShop.Web.Attributes;

namespace eShop.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderApplicationService _IOrderApplicationService;
        private IProductApplicationService _ProductApplicationService;
        public OrderController(IOrderApplicationService IOrderApplicationService, IProductApplicationService ProductApplicationService)
        {
            _IOrderApplicationService = IOrderApplicationService;
            _ProductApplicationService = ProductApplicationService;
        }

        public IActionResult Index(Guid UserId)
        {

            UserId = new Guid("C14B6E6F-4F27-4B6A-BE74-03D279AAEABF");
            CartWithAddresstModel productsInCarWithAddresstModel = new CartWithAddresstModel();

            List<ProductsInCartModel> productsInCart = new List<ProductsInCartModel>();
            List<UserAddressModel> userAddresses = new List<UserAddressModel>();

            var list = _ProductApplicationService.GetCartDetails(UserId);

            foreach (var item in list.productsInCart)
            {
                productsInCart.Add(new ProductsInCartModel
                {
                    OrderId = item.OrdertId,
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            foreach (var item in list.userAddress)
            {
                userAddresses.Add(new UserAddressModel
                {
                    ID = item.ID,
                    UserId = item.UserId,
                    City = item.City,
                    Address = item.Address

                });
            }

            productsInCarWithAddresstModel.productsInCart = productsInCart;
            productsInCarWithAddresstModel.TotalPrice = list.TotalPrice;
            productsInCarWithAddresstModel.userAddresses = userAddresses;

            return View(productsInCarWithAddresstModel);
        }

        public IActionResult AddToCart(Guid UserId, Guid ProductId, int ProductQuantity)
        {

            UserId =new Guid("C14B6E6F-4F27-4B6A-BE74-03D279AAEABF");

            var result = _IOrderApplicationService.AddOrder(UserId, ProductId, ProductQuantity);
            return Json(new { data = result });
        }

        [HttpPost]
        public IActionResult ApplyOrder(Guid OrderId, Guid AddressId)
        {
            _IOrderApplicationService.ApplyOrder(OrderId, AddressId);

            return View();
        }

        public IActionResult OrderHistory(Guid UserId)
        {
            UserId = new Guid("C14B6E6F-4F27-4B6A-BE74-03D279AAEABF");

            ICollection<OrderModel> list = new List<OrderModel>();

            var result = _IOrderApplicationService.GetOrdersHistory(UserId);

            foreach (var item in result)
            {
                list.Add(new OrderModel
                {
                    Id = item.Id,
                    OrderStatus = item.OrderStatus,
                    TotalPrice = item.TotalPrice,
                    DateCreated = item.DateCreated
                });
            }      

            return View(list);
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            List<OrdeDetailModel> ordeDetailModels = new List<OrdeDetailModel>();
            var result = _IOrderApplicationService.GetOrderDetails(orderId);

            foreach (var item in result)
            {
                ordeDetailModels.Add(new OrdeDetailModel
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }
            return Json(ordeDetailModels);
        }

        [HttpPost]
        public IActionResult AddAddress(UserAddressModel addressModel)
        {
            addressModel.UserId = new Guid("C14B6E6F-4F27-4B6A-BE74-03D279AAEABF");

            UserAddressDTO userAddressDTO = new UserAddressDTO();
            userAddressDTO.ID = addressModel.ID;
            userAddressDTO.UserId = addressModel.UserId;
            userAddressDTO.City = addressModel.City;
            userAddressDTO.Address = addressModel.Address;

            _IOrderApplicationService.AddAddress(userAddressDTO);

            return RedirectToAction("Index", "Order");
        }
    }
}
