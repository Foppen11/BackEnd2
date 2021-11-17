using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning2.Models
{
    public class Product
    {
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
       
        [Required]
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool InStock { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
