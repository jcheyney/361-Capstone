using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>(); // Simulating a database

        // GET: api/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return Ok(items);
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = items.FirstOrDefault(i => i.itemID == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        public ActionResult<Item> CreateItem([FromBody] Item newItem)
        {
            if (newItem == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            newItem.itemID = items.Count > 0 ? items.Max(i => i.itemID) + 1 : 1; // Assign a unique ID
            items.Add(newItem);

            return CreatedAtAction(nameof(GetItem), new { id = newItem.itemID }, newItem);
        }

        // PUT: api/items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            var item = items.FirstOrDefault(i => i.itemID == id);
            if (item == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Update properties
            item.salesID = updatedItem.salesID;
            item.itemWeight = updatedItem.itemWeight;
            item.dimensions = updatedItem.dimensions;
            item.manufacture = updatedItem.manufacture;
            item.itemDescription = updatedItem.itemDescription;
            item.quantity = updatedItem.quantity;
            item.imageURL = updatedItem.imageURL;
            item.sku = updatedItem.sku;
            item.rating = updatedItem.rating;
            item.itemType = updatedItem.itemType;

            return NoContent();
        }

        // DELETE: api/items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var item = items.FirstOrDefault(i => i.itemID == id);
            if (item == null)
                return NotFound();

            items.Remove(item);

            return NoContent();
        }
    }
}
