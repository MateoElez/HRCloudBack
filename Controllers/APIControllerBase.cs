using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using ProjectAPI.Models.BaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class APIControllerBase<TEntity> : ControllerBase
        where TEntity : Models.TEntity
    {
        public readonly ProjectDbContext _context;
        protected DbSet<TEntity> _dbSet { get; set; }
        private readonly IMapper _mapper;

        public APIControllerBase(ProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _mapper = mapper;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseDto>>> GetAll()
        {

            var baseDto = await _dbSet.ToListAsync();

            if (baseDto == null)
            {
                return NotFound();
            }

            return Ok(baseDto);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto>> GetById(int id)
        {
            var baseDto = await _dbSet.FindAsync(id);

            if (baseDto == null)
            {
                return NotFound();
            }

            return Ok(baseDto);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutById(int id, TEntity item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TEntity>> PostItem(TEntity item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _dbSet.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }



    }
}
