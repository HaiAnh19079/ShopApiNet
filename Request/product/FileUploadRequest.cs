using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApiNet.models;

namespace ShopApiNet.Request
{
    public class FileUploadRequest
    {
        public string Name { get; set; }
        public List<ProductColor>? Colors { get; set; }
        public List<ProductImage>? Images { get; set; }
        public List<ProductSize>? Sizes { get; set; }
    }
}