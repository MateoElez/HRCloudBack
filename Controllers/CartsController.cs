using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using ProjectAPI.Models.CartFolder;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : APIControllerBase<Cart, CartDto>
    {
        //private readonly ProjectDbContext _context;

        public CartsController(ProjectDbContext context, Mapper mapper) : base(context, mapper)
        {
          //  _context = context;
        }

        // GET: api/Carts
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            return await _context.Cart.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }
        */

        [HttpGet("{id}/list")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(int id)
        {
            var cartItems = await _context.Cart.FindAsync(id);
            var carts = _context.Cart.Include(o => o.CartItems).ToList();

            if (cartItems != null)
            {
                return cartItems.CartItems;
            }
            return NotFound();
        }


        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, CartDto cartDto)
        {
            var oldCart = await _context.Cart.FindAsync(id);

            var orders = _context.Cart.Include(o => o.CartItems).ToList();

          /*  if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified; */

            if (oldCart.CartItems == null)
            {
                oldCart.CartItems = new List<CartItem>();
            }


            foreach (var o in cartDto.CartItems)
            {
                oldCart.CartItems.Add(o);

            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }
}
