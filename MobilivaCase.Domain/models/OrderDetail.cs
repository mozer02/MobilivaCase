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
        public Product Product { get; set; }
        public OrderDetail()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
