using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models.CartFolder
{
    public class Cart: TEntity
    {
        
        public virtual User User { get; set; }

        public virtual List<CartItem> CartItems { get; set; }

        public Cart()
        {

        }

        public Cart(CartDto cartDto)
        {
            Id = cartDto.Id;
            CartItems = cartDto.CartItems;
        }
    }
}
