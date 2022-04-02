using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.dtos.order
{
    public class ProductDetail
    {
        //ProductDetail objesi: ProductId,UnitPrice,Amount
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
    }
    public class CreateOrderRequestDto
    {
        //CustomerName, CustomerEmail, CustomerGSM, List<ProductDetail>
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }

    }
}
