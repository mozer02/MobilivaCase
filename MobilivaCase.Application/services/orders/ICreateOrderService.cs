using MobilivaCase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application
{
    public interface ICreateOrderService : IApplicationService<CreateOrderRequestDto, string>
    {
    }
}
