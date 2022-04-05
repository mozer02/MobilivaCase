using MobilivaCase.Domain;
using MobilivaCase.Domain.models;
using MobilivaCase.Domain.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public CreateOrderService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public string OnProcess(CreateOrderRequestDto request = null)
        {
            decimal TotalPrice = 0;
            var order = new Order();
            order.CustomerEmail = request.CustomerEmail;
            order.CustomerGSM = request.CustomerGSM;
            order.CustomerName = request.CustomerName;

            foreach (var product in request.ProductDetails)
            {
                var detail = new OrderDetail();
                var pro = _productRepository.GetQuery().FirstOrDefault(x => x.Id == product.ProductId);
                var detailPrice = product.Amount * product.UnitPrice;
                TotalPrice += detailPrice;
                detail.Product = pro;
                detail.UnitPrice = detailPrice;
                order.AddOrderDetail(detail);
            }
            order.TotalAmount = TotalPrice;
            _orderRepository.Add(order);
            _orderRepository.Save();

            return order.Id;
        }
    }
}
