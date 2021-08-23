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
    //[Route("api/[controller]")]
    public abstract class APIControllerBase<IEntity, IBaseDto> : ControllerBase
        where IBaseDto : Models.BaseFolder.BaseDto
        where IEntity : Models.TEntity
    {
        public readonly ProjectDbContext _context;
        protected DbSet<IEntity> _dbSet { get; set; }
        private readonly IMapper _mapper;

        public APIControllerBase(ProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<IEntity>();
            _mapper = mapper;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IBaseDto>>> GetAll()
        {
            //var baseDto = new BaseDto();
            //var mappedDto = _mapper.Map<TEntity, BaseDto>(_dbSet, await _dbSet.ToListAsync());

            /*var baseDto = await _dbSet.Select(t => new BaseDto()
            {
                Id = t.Id
            }).ToListAsync();*/

            var entity = await _dbSet.ToListAsync();

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<IBaseDto>>> GetById(int id)
        {
            //var baseDto = await _dbSet.FindAsync(id);
            /*var _baseDto = await _dbSet.Where(u => u.Id == id)
                .Select(t => new BaseDto()
                {
                    Id = t.Id
                })
                .ToListAsync();*/

            var entity = await _dbSet.FindAsync(id);
            

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> PutById(int id, IBaseDto item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            //var entity = new TEntity();
            //var cartItems = await _dbSet.FindAsync(id);
            //var carts = _dbSet.Include(o => o.Id);

            _context.Entry(_mapper.Map<IEntity>(item)).State = EntityState.Modified;

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
        public virtual async Task<ActionResult<BaseDto>> PostItem(IBaseDto item)
        {
            _dbSet.Add(_mapper.Map<IEntity>(item));
            await _context.SaveChangesAsync();

            //new code for DTO
            //_context.Entry(item).Property(x => x.Id);
            //_dbSet.Load();

            /*var dto = new BaseDto()
            {
                Id = item.Id
            };*/

            //var dto = _mapper.Map<BaseDto>(item);
            

           

            return CreatedAtAction("GetById", new { id = item.Id }, item);
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
