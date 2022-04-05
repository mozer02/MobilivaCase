using MobilivaCase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Domain.models
{
    public class Order : Entity
    {
        // Id, CustomerName, CustomerEmail, CustomerGSM, TotalAmount 
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public decimal TotalAmount { get; set; }
        private List<OrderDetail> orderDetails = new List<OrderDetail>();
        public IReadOnlyList<OrderDetail> OrderDetails => orderDetails;
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetails.Add(orderDetail);
        }
    }
}
