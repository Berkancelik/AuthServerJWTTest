using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;
using UdemyAuthServer.Core.Services;

namespace UdemyAuthServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : CustomBaseController
    {
        private readonly IServiceGeneric<Product, ProductDto> _productService;

        public ProductsController(IServiceGeneric<Product, ProductDto> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return ActionResultInstance(await _productService.GetAllAsync());
            
        }

        [HttpPost]
        public async Task<IActionResult> SaveProducts(ProductDto productDto)
        {
            return ActionResultInstance(await _productService.AddAsync(productDto));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducts(ProductDto productDto)
        {
            return ActionResultInstance(await _productService.Update(productDto,productDto.Id));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            return ActionResultInstance(await _productService.Remove(id));

        }
    }
}
