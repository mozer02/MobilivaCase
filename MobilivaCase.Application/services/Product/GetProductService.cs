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
            //var statusEnum = new StatusEnum();
            try
            {
                response.Data = _productRepository.GetQuery().Where(x => x.Category == request).ToList();
                response.ResultMessage = "İşlem Başarılı";
                response.Status= 100;
                response.ErrorCode = "200";
            }
            catch (Exception)
            {
                response.ResultMessage = "İşlem Başarısız";
                response.Status = 101;
                response.ErrorCode = "400";                
            }

            return response;
        }
    }
}
