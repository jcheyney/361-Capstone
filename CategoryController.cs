using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly List<Category> _categories;

        public CategoryController()
        {
            // Example in-memory list; replace with a database context for production
            _categories = new List<Category>
            {
                new Category
                {
                    categoryID = 1,
                    categoryName = "Electronics"
                }
            };
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(_categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.categoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category newCategory)
        {
            if (newCategory == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            newCategory.categoryID = _categories.Count + 1;
            _categories.Add(newCategory);

            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.categoryID }, newCategory);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            var category = _categories.FirstOrDefault(c => c.categoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            category.categoryName = updatedCategory.categoryName;

            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.categoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            _categories.Remove(category);

            return NoContent();
        }
    }

    // Category class definition (adjust namespace accordingly)
    public class Category
    {
        public int categoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string categoryName { get; set; }
    }
}

