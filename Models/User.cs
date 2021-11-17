using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning2.Models
{
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter an unique & correct email adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a valid password")]
        public string Password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
