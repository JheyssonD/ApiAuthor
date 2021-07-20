using ApiAuthor.Contexts;
using ApiAuthor.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly ApiDBContext Context;

        public AuthorController(ApiDBContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await  Context.Authors.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Author author)
        {
            Context.Add(author);
            await Context.SaveChangesAsync();
            return Ok();
        }

    }
}
