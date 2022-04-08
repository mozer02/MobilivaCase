using MobilivaCase.API.ViewModel;
using MobilivaCase.Core.consts;
using MobilivaCase.Core.domain;
using MobilivaCase.Core.entities;
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
        private readonly ISmtpConfiguration _smtpConfig;
        private readonly IPublisherService _publisherService;
        public CreateOrderService(IProductRepository productRepository, IOrderRepository orderRepository, ISmtpConfiguration smtpConfig, IPublisherService publisherService)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _smtpConfig = smtpConfig;
            _publisherService = publisherService;
        }
        private MailMessageData PrepareMessages(PostMailViewModel post,string email)
        {
            var message = new MailMessageData()
            {
                To = email.ToString(),
                From = _smtpConfig.User,
                Subject = post.Post.Title,
                Body = post.Post.Content
            };              
            
            return message;
        }
        public string OnProcess(CreateOrderRequestDto request = null)
        {
            decimal TotalPrice = 0; 
            var order = new Order();
            var post = new PostMailViewModel();
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
            post.Post.Content = "Sipariş Başarılı bir şekilde oluşturulmuştur.";
            post.Post.Title = "Sipariş Detayı";
            //_publisherService.Enqueue(
            //                          PrepareMessages(post, request.CustomerEmail),
            //                          RabbitMQConsts.RabbitMqConstsList.QueueNameEmail.ToString()
            //                        );
            return order.Id;
        }
    }
}
