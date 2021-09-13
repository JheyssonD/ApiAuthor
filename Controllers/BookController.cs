using ApiAuthor.Contexts;
using ApiAuthor.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly ApiDBContext Context;

        public BookController(ApiDBContext context)
        {
            Context = context;
        }

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<Book>> GetById(int id)
        //{
        //    return await Context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        //}

        //[HttpPost]
        //public async Task<ActionResult<Book>> Post(Book book)
        //{
        //    bool existBook = await Context.Authors.AnyAsync(a => a.Id == book.AuthorId);
        //    if (!existBook)
        //    {
        //        return BadRequest($"No existe el Author con el id {book.AuthorId}.");
        //    }
        //    Context.Books.Add(book);
        //    await Context.SaveChangesAsync();
        //    return Ok(book);
        //}
    }
}
