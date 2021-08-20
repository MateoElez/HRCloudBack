using ProjectAPI.Models.BaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models.CartFolder
{
    public class CartDto : BaseDto
    {
        public virtual List<CartItem> CartItems { get; set; }

        public CartDto()
        {

        }

        public CartDto(Cart cart)
        {
            Id = cart.Id;
            CartItems = cart.CartItems;
        }
    }
}
