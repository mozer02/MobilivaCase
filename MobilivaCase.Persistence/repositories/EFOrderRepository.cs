using AgileManagement.Persistence.EF;
using MobilivaCase.Core;
using MobilivaCase.Domain;
using MobilivaCase.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.EF
{
    public  class EFOrderRepository: EFBaseRepository<Order, AppDbContext>, IOrderRepository
    {
        public EFOrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
