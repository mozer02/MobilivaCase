using AgileManagement.Persistence.EF;
using MobilivaCase.Core;
using MobilivaCase.Domain.models;
using MobilivaCase.Domain.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.EF
{
    public class EFProductRepository : EFBaseRepository<Product, AppDbContext>, IProductRepository
    {
        public EFProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
