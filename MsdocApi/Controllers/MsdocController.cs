using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsdocApi.Models;

namespace MsdocApi.Controllers
{
    [Route("api/msdoc")]
    [ApiController]
    public class MsdocController : ControllerBase
    {
        private readonly MsdocContext _context;

        public MsdocController(MsdocContext context)
        {
            _context = context;
            if(_context.MsdocItems.Count()==0)
            {
                _context.MsdocItems.Add(new MsdocItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        //GET: api/msdoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MsdocItem>>> GetMsdocItems()
        {
            return await _context.MsdocItems.ToListAsync();
        }

        //GET: api/msdoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MsdocItem>> GetMsdocItem(long id)
        {
            var item = await _context.MsdocItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        //POST: api/msdoc
        [HttpPost]
        public async Task<ActionResult<MsdocItem>> PostMsdocItem(MsdocItem item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMsdocItem),new { id = item.Id },item);
        }

        //PUT: api/msdoc/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMsdocItem(long id,MsdocItem item)
        {
            if(id!=item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/msdoc/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMsdocItem(long id)
        {
            var item = await _context.MsdocItems.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.MsdocItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}