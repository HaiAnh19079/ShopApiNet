using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ShopApiNet.models;
namespace ShopApiNet.models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public virtual ICollection<ProductColor> Colors { get; set; } = new List<ProductColor>();
        public virtual ICollection<ProductSize> Sizes { get; set; } = new List<ProductSize>();
        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public bool IsDeleted { get; set; } = false;
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }

}


