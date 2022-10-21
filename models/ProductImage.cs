using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApiNet.models
{
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public bool IsThumb { get; set; }
        public long FileSize { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
    }
}