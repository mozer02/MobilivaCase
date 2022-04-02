using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilivaCase.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilivaCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGetProductService _getProductService;
        public ProductsController(IGetProductService getProductService)
        {
            _getProductService = getProductService;
        }
        [HttpGet("GetProducts")]
        public IActionResult GetProduct(string category)
        {
            var response= _getProductService.OnProcess(category);
            return Ok(response);
        }
    }
}
