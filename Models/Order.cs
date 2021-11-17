using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning2.Models
{
    public class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTimeOffset OrderDate { get; set; }

       
        public string Status { get; set; }


        public virtual User User { get; set; }


        [Required]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
