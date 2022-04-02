using MobilivaCase.Application.dtos.api;
using MobilivaCase.Core;
using MobilivaCase.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application
{
    public interface IGetProductService:IApplicationService<string,ApiResponseDto<Product>>
    {
    }
}
