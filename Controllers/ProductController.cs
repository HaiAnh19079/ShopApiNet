using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApiNet.models;
using ShopApiNet.Repositories;
using ShopApiNet.Request;
using ShopApiNet.Request.product;

namespace ShopApiNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request)
        {
            // foreach (var item in request.Images)
            // {
            //     _logger.LogInformation("file uploaded : " + item.FileName);
            // }
            // foreach (var file in request.Colors)
            // {
            //     _logger.LogInformation("Color : "+file);
            // }
            //  _logger.LogInformation("request: " + request.ToString());
            // we can rest of upload logic here.
            var product = await _productRepository.Create(request);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(product);
        }
    }
}