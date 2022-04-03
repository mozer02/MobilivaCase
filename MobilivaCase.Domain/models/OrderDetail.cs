using MobilivaCase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Domain.models
{
    public class OrderDetail : Entity
    {
        //OrderId, ProductId, UnitPrice
        public decimal UnitPrice { get; set; }
        private List<Product> products = new List<Product>();
        public IReadOnlyList<Product> Products => products;
        private List<Order> orders = new List<Order>();
        public IReadOnlyList<Order> Orders => orders;
        public OrderDetail()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
