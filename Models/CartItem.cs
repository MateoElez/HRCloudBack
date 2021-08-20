using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class CartItem
    {
        [Key]
        public virtual int itemId { get; set; }
        public virtual int Quantity { get; set; }
    }
}
