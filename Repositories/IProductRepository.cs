using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApiNet.models;
using ShopApiNet.Request.product;

namespace ShopApiNet.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductView>> GeAll();
        Task<ProductModel> Create(CreateProductRequest request);
        Task<ProductModel> GetById(int id);
    }
}