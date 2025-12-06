using Microsoft.AspNetCore.Mvc;
using CafeInventoryApi.Data;
using CafeInventoryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeInventoryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ItemsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Items.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _db.Items.FindAsync(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            _db.Items.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Item updatedItem)
        {
            var item = await _db.Items.FindAsync(id);
            if (item == null) return NotFound();

            item.Name = updatedItem.Name;
            item.Category = updatedItem.Category;
            item.Quantity = updatedItem.Quantity;
            item.Price = updatedItem.Price;

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Items.FindAsync(id);
            if(item == null) return NotFound();

            _db.Items.Remove(item);

            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
