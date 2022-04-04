using Bogus;
using MobilivaCase.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.EF.FakeData
{
    public class FakeData
    {
        private static List<Product> _products;
        private static List<Product> GetProducts()
        {
            //_products=new Faker<Product>()
            //    .RuleFor(x=>x.Category,a=>a.Commerce.ProductName())
            //    .RuleFor(x=>x.CreateDate,a=>a.Date.Between(DateTime.Now.AddYears(-2),DateTime.Now))
            //    .RuleFor(x=>x.Description,a=>a.Name.FullName())
            //    .RuleFor(x=>x.OrderDetails,a=>a.)



            return _products;
        }
    }
}
