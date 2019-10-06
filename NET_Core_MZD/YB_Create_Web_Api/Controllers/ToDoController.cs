using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YB_Create_Web_Api.Context;
using YB_Create_Web_Api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YB_Create_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;

            if (_context.Items.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                
                _context.Items.Add(new Item { Name = "Item1" });
                _context.SaveChanges();
            }
        }


        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> AllTodoItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Todo/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> TodoItem(long id)
        {
            var todoItem = await _context.Items.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }

        // PUT: api/Todo/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Item todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

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

        // DELETE: api/Todo/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteTodoItem(long id)
        {
            var todoItem = await _context.Items.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        private bool ItemExists(long id)
        {
            return _context.Items.Any(e => e.Id == id);
        }


    }
}
