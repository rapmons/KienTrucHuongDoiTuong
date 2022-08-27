using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.Models
{   
    // [Table("SanPham")]
    public class Categories
    {  // [Key]
    public Categories()
    {
        Product = new List<Product>();
    }
        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]       
   
        public List<Product> Product { get; set; }
    }
}