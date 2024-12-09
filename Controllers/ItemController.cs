using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return Ok(_context.Items.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Item item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Items.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = item.ItemID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            var item = _context.Items.Find(id);
            if (item == null) return NotFound();

            _context.Entry(item).CurrentValues.SetValues(updatedItem);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null) return NotFound();

            _context.Items.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
