using MobilivaCase.Domain.models;
using MobilivaCase.Domain.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application
{
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;       
        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ApiResponseDto<Product> OnProcess(string request = null)
        {
            var response = new ApiResponseDto<Product>();
            try
            {
                response.Data = _productRepository.GetQuery().Where(x => x.Category == request).ToList();
                response.ResultMessage = "İşlem Başarılı";
                response.Status = StatusEnum.Success;
            }
            catch (Exception e)
            {
                response.ResultMessage = "İşlem Başarısız";
                response.Status = StatusEnum.Failed;
                response.ErrorCode = e.Message;                
            }

            return response;
        }
    }
}
