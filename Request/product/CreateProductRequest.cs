using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApiNet.models;

namespace ShopApiNet.Request.product
{
    public class CreateProductRequest 
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public string ImagePath { get; set; }
        public string[] Colors { get; set; }
        public string[] Sizes { get; set; }
        public IFormFile[]? Images { get; set; }
    }
}