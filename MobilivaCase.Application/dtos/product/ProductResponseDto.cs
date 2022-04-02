using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application
{
    public class ProductResponseDto
    {
        //Id, Description,Category,Unit,UnitPrice
        public string Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Unit { get; set; }
        public decimal UnitPrice { get; set; }
        
    }
}
