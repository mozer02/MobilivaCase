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
    public class EFOrderDetailsRepository : EFBaseRepository<OrderDetail, AppDbContext>, IOrderDetailRepository
    {
        public EFOrderDetailsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
