using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApiNet.models;
using ShopApiNet.Request.product;

namespace ShopApiNet.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLDBContext _context;

        public ProductRepository(MySQLDBContext context)
        {
            _context = context;
        }
        public async Task<ProductModel> Create(CreateProductRequest request)
        {
            var product = new ProductModel()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Status = request.Status,
                Stock = request.Stock,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            if (request.Images != null)
            {
                foreach (var productImage in request.Images)
                {
                    var newImage = new ProductImage()
                    {
                        ImagePath = productImage.FileName,
                        FileSize = productImage.Length,
                        ProductId = product.Id,
                        IsThumb = false
                    };
                    _context.ProductImages.Add(newImage);

                    await _context.SaveChangesAsync();
                    product.Images.Add(newImage);
                }
            }
            if (request.Sizes != null)
            {
                foreach (var productSize in request.Sizes)
                {
                    var newSize = new ProductSize()
                    {
                        SizeName = productSize,
                        ProductId = product.Id

                    };
                     _context.ProductSizes.Add(newSize);

                    await _context.SaveChangesAsync();
                    product.Sizes.Add(newSize);
                }
            }
            if (request.Colors != null)
            {
                foreach (var productColor in request.Colors)
                {
                    var newColor = new ProductColor()
                    {
                        ColorName = productColor,
                        ProductId = product.Id

                    };
                     _context.ProductColors.Add(newColor);

                    await _context.SaveChangesAsync();
                    product.Colors.Add(newColor);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception e)
            {
                var test = e;
                throw;
            }
        }

        public async Task<IEnumerable<ProductView>> GeAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

}